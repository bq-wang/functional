module FSharpPowerPack_Math

// what will be covered in this chapter 
//  1. Microsoft.FSharp.Math namespace and its function 

(*

what might be covered in the Math 

BigInt
BigNum 

Matrix, Vector, RowVector, and Notations all contains operations related to matrices and vectors. 
There is a module, Complex, for working with Complex numbers. 

*)


(*
what we will show how to draw the most famous factal of all, the Mandelbrot set. 

Cn+1 = Cn2 + c

If repeated iteration of this equation stays between the complex number C(1, 1i) and C(–1, –1i), then the original complex number is a member of the Mandelbrot set.

*)

(*

check method will check if a complex number can be member to the Mandelbrot comlex numbers. 
*)
(*
open Microsoft.FSharp.Math
// there is no such namespace 
//    open Microsoft.FSharp.Math.Notation

let cMax = complex 1.0 1.0 
let cMin = complex -1.0 -1.0 
let iterations = 18 
let isInMandelbrotSet c0 = 
    let rec check n c = 
        (n = iterations)
        or (cMin < c) && (c < cMax) && check(n + 1) ((c * c) + c0)
    check 0 c0 

open Microsoft.FSharp.Math
//open Microsoft.FSharp.Math.Notation

let scalingFactor = 1.0 / 200.0
let offset = -1.0 

let mapPlane(x, y) = 
    let fx = ((float x) * scalingFactor) + offset
    let fy = ((float y) * scalingFactor) + offset
    complex fx fy 
*)

(* 
you will need to reference the fSharp types, in order to use it 

and some reference sites: 

tryfsharp: http://www.cnblogs.com/tryfsharp
fsharp_net的专栏: http://blog.csdn.net/fsharp_net
F# Math - Numerical computing and F# PowerPack: http://tomasp.net/blog/powerpack-introduction.aspx/
*)

#r "FSharp.PowerPack.dll"

open System
open System.Drawing
open System.Windows.Forms
open Microsoft.FSharp.Math
let cMax = complex 1.0 1.0 
let cMin = complex -1.0 -1.0

let iterations = 18 
let isInMandelbrotSet c0 = 
    let rec check n c = 
        (n = iterations) 
        || (cMin < c) 
        && (c < cMax) 
        && check(n + 1) ((c * c) + c0)
    check 0 c0

let scalingFactor = 1.0 / 200.0 
let offset = -1.0 

let mapPlane(x, y) = 
    let fx = ((float x) * scalingFactor) + offset
    let fy = ((float y) * scalingFactor) + offset
    complex fx fy 

let form = 
    let image = new Bitmap(400, 400)
    for x = 0 to image.Width - 1 do 
        for y = 0 to image.Height - 1 do 
            let isMember = isInMandelbrotSet(mapPlane(x, y))
            if isMember then 
                image.SetPixel(x, y, Color.Black)
    let temp = new Form() in 
    temp.Paint.Add(fun e -> e.Graphics.DrawImage(image, 0, 0))
    temp

[<STAThread>]
do Application.Run(form)


