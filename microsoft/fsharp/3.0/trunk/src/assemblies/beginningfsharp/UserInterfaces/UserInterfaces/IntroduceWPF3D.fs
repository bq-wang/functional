module IntroduceWPF3D

// what will be covered in this chapter include the following 
//  1. how to work with WPF 3d with FSharp 

#I @"C:\Program Files\Reference Assemblies\Microsoft\Framework\v3.0" ;;
#r "System.Xaml.dll"
#r "PresentationFramework.dll"
#r "PresentationCore.dll"
#r "WindowsBase.dll"
#r "System.Xml.dll"

open System
open System.Collections.Generic
open System.Windows
open System.Windows.Markup
open System.Windows.Media
open System.Windows.Media.Media3D
open System.Windows.Threading
open System.Xml

let createWindow(file : string) = 
    using (XmlReader.Create(file)) 
        (fun stream ->
            let temp = XamlReader.Load(stream) :?> Window
            temp.Height <- 400.0
            temp.Width <- 400.0
            temp.Title <- "F# meets Xaml"
            temp)
// finds all the MeshGeometry3D in a given 3D view port
// aobut the special use of the syntax ":? ", please try to find details on chapter 
//   "Pattern matching on .NET types"
let findMeshes(viewport : System.Windows.Controls.Viewport3D) = 
    viewport.Children
    |> Seq.choose (function :? ModelVisual3D as c -> Some(c.Content) | _ -> None) 
    |> Seq.choose (function :? Model3DGroup as mg -> Some(mg.Children) | _ -> None) 
    |> Seq.concat
    |> Seq.choose
        (function :? GeometryModel3D as mg -> Some(mg.Geometry) | _ -> None)
    |> Seq.choose
        (function :? MeshGeometry3D as mv -> Some(mv) | _ -> None)

// loop function to create all items necessary for a plane
let createPlaneItemList f (xRes : int) (yRes : int) = 
    let list = new List<_> () 
    for x = 0 to xRes - 1 do 
        for y = 0 to yRes - 1 do 
            f list x y 
    list

// function to initialize a point
let point x y = new Point(x, y )

// function to initialize a "d point
let point3D x y = new Point3D(x, y, 0.0)


// createa all the points necessary for a square in the plane 
let createSquare 
    f (xStep : float) (yStep: float) (list : List<_>) (x : int) (y: int) =  
    let x' = float x * xStep
    let y' = float y * yStep
    list.Add(f x' y')
    list.Add(f (x' + xStep) y')
    list.Add(f (x' + xStep) (y' + yStep))
    list.Add(f (x' + xStep) (y' + yStep))
    list.Add(f x' (y' + yStep))
    list.Add(f x' y')

(*
this function has the curried function which can carry the xStep and the yStep function forwards
*)
// create all the itmes in a plane
let createPlanePoints f xRes yRes = 
    let xStep = 1.0 / float xRes
    let yStep = 1.0 / float yRes
    createPlaneItemList (createSquare f xStep yStep) xRes yRes

// create the 3D positions for a plane, i.e., the thing that says where
// the plane will be in 3D space
let createPlanePositions xRes yRes = 
    let list =createPlanePoints point3D xRes yRes
    new Point3DCollection(list)

// create the texture mapping for a plane, i.e. the thing that
// maps the 2D images to the 3D plane
let createPlaneTextures xRes yRes = 
    let list = createPlanePoints point xRes yRes
    new PointCollection(list)

(*
create an indices plane, what is the use of this plane?
*)
// create indices list for all our triangles
let createIndicesPlane width height = 
    let list = new System.Collections.Generic.List<int>()
    for index = 0 to width * height * 6 do 
        list.Add(index)
    new Int32Collection(list)

// center the plane in the field of view
let mapPositionsCenter (positions : Point3DCollection) =
    let newPositions = 
        positions 
        |> Seq.map 
            (fun position -> 
                new Point3D(
                    (position.X - 0.5) * -1.0,
                    (position.Y - 0.5) * -1.0,
                    position.Z))
    new Point3DCollection(newPositions)


// create a plane and add it to the given mesh
let addPlaneToMesh(mesh : MeshGeometry3D) xRes yRes = 
    mesh.Positions <- mapPositionsCenter 
                        (createPlanePositions xRes yRes)
    mesh.TextureCoordinates <- createPlaneTextures xRes yRes
    mesh.TriangleIndices <- createIndicesPlane xRes yRes


let movingWaves (t : float) x y  = 
    (Math.Cos((x + t) * Math.PI * 4.0) / 3.0) *
    (Math.Cos(y * Math.PI * 2.0) / 3.0)


// create our window
let window = createWindow @"C:\dev\workspaces\functional\microsoft\fsharp\3.0\trunk\src\assemblies\beginningfsharp\UserInterfaces\UserInterfaces\Window2.xaml"
//let window = createWindow "Window2.xaml"

let mesh = 
    // grab the 3D view port 
    let viewport = window.FindName("ViewPort") :?> System.Windows.Controls.Viewport3D
    // find all the meshs and get the first one
    let meshes = findMeshes viewport
    let mesh = Seq.head meshes
    // add plane to the mesh 
    addPlaneToMesh mesh 20 20 
    mesh 

let changePositions () =
    let dispatcherTimer = new DispatcherTimer()
    dispatcherTimer.Tick.Add
    (fun e ->
        let t = (float DateTime.Now.Millisecond) / 2000.0
        let newPositions = 
            mesh.Positions
            |> Seq.map 
                (fun position ->
                    let z = movingWaves t position.X position.Y
                    new Point3D(position.X, position.Y, z))
        mesh.Positions <- new Point3DCollection(newPositions))
    dispatcherTimer.Interval <- new TimeSpan(0, 0, 0, 0, 1000)
    dispatcherTimer.Start()

let main() = 
    let app = new Application()
    changePositions()
    // show the window 
    app.Run(window) |> ignore

changePositions()
window.Visibility <- Visibility.Visible



(*

this is how you can run the same program under the FSI 


*)

#I @"C:\Program Files\Reference Assemblies\Microsoft\Framework\v3.0" ;;
#r @"PresentationCore.dll" ;;
#r @"PresentationFramework.dll" ;;
#r @"WindowsBase.dll" ;;

(*
you can alter the changePositions function to use a mutable function:


*)
// mutable function that is used within changePositions function
let mutable f = (fun (t : float) (x : float) (y : float) -> 0.0)

// function for changing the plane over time
let changePositions () =
    let dispatcherTimer = new DispatcherTimer()
    dispatcherTimer.Tick.Add
        (fun e ->
            let t = (float DateTime.Now.Millisecond) / 2000.0
            let newPositions =
                mesh.Positions
                |> Seq.map
                    (fun position ->
                        let z = f t position.X position.Y
                        new Point3D(position.X, position.Y, z))
            mesh.Positions <- new Point3DCollection(newPositions))
    dispatcherTimer.Interval <- new TimeSpan(0,0,0,0,100)
    dispatcherTimer.Start()

(*

finally , you show the window using the .Show() method rather thatn the Application class's Run method 
; be careful that you set this Topmost property to true so that it is easy to interact with the window 
and see the results

*)

// show the window, set it the top, and activate the function that will
// set it moving 
window.Show()
window.Topmost <- true 
changePositions()


(*
finally you can define some other function to map across the plane. This can be any function that takes three floating -points numbers
(the first rerpesenting the time and the next two representing the X and Y coordinates, respectively) 
*)
let cosXY _ x y = 
    Math.Cos(x * Math.PI) * Math.Cos(y * Math.PI)

let movingCosXY (t : float) x y = 
    Math.Cos((x + t) * Math.PI) * Math.Cos (( y - t) * Math.PI)

f <- movingCosXY


[<STAThread>]
do main()   