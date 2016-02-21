// Learn more about F# at http://fsharp.net

module Program

open System
open System.Windows
open System.Windows.Forms

[<STAThread>]
Application.Run(Strangelights.Fibonacci.form)