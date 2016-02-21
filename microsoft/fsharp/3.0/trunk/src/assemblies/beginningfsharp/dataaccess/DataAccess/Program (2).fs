// 在 http://fsharp.net 网站上了解有关 F# 的更多信息

module Program

open System.Windows.Forms
open System;

[<STAThread>]
do Application.Run(DataBinding.form)