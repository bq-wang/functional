
// what will be covered in this chapter include the following 
//  1. 

#I "C:\\ProgramFiles\\FSharpPowerPack-2.0.0.0\\bin"
#r "FSharp.Powerpack.dll"

open System
open System.ComponentModel
open System.IO
open System.Net.Sockets
open System.Threading
open System.Windows.Forms

let form =
    // create the form  
    let form = new Form(Text = "F# Talk Client") 
    // text box to show the message received
    let output = 
        new TextBox(Dock = DockStyle.Fill,
                    ReadOnly = true,
                    Multiline = true)
    form.Controls.Add(output) 

    // text box to allow the user to send messages
    let input = new TextBox(Dock = DockStyle.Bottom, Multiline = true)
    form.Controls.Add(input)

    // create a new tcp client to handle the network connections 
    let tc = new TcpClient()
    tc.Connect("localhost", 4243)

    // loop that handles reading frmo the tcp client
    let load() = 
        let run() = 
            let sr = new StreamReader(tc.GetStream())
            while (true) do 
                let text = sr.ReadLine()
                if text <> null && text <> "" then 
                    // we need to invoke back to the "gui thread"
                    // to be able to safely interact with the controls (* the method invoker is more like Action in C# era *)
                    form.Invoke(new MethodInvoker(fun () ->
                        output.AppendText(text + Environment.NewLine)
                        output.SelectionStart <- output.Text.Length))
                    |> ignore
        // create a new Thread to run this loop 
        let t = new Thread(new ThreadStart(run))
        t.Start()
    // start the loop that handles reading from the tcp client
    // when the form has loaded
    form.Load.Add(fun _ -> load())

    let sw = new StreamWriter(tc.GetStream())

    // handles the key up event - if the user has entered a line 
    // of text then send the message to the server
    let keyUp () = 
        if (input.Lines.Length > 1) then 
            let text = input.Text
            if (text <> null && text <> "") then 
                try 
                    sw.WriteLine(text) 
                    sw.Flush()
                with err ->
                    MessageBox.Show(sprintf "Server errror\n\n%O" err) 
                    |> ignore 
                input.Text <- ""
    // wire up the key up event handler
    input.KeyUp.Add(fun _ -> keyUp())

    // when the form closes it is necessary to explicitly exit the app
    // as there are other threads in the background
    form.Closing.Add(fun _ ->
        Application.Exit()
        Environment.Exit(0))

    // return theform to the top level 
    form

[<STAThread>]
do Application.Run(form)

//form.Show()
//form.Visible <- true 

