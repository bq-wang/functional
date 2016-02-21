module DataBinding

(*

for details on how to connect and configures the data source, you can try this: 

Microsoft SQL Server Management Studio Express:

    http://www.microsoft.com/zh-cn/download/confirmation.aspx?id=8961


如何使用vs.net2010自带的sqlexpress
    http://blog.csdn.net/xemexeme/article/details/5567488



*)
#nowarn "9"

//namespace Microsoft.FSharp.Compatibility.OCaml
open System.Collections.Generic
[<RequireQualifiedAccess>]
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Seq = 
    let generate openf compute closef = 
        seq { let r = openf()
            try 
                let x = ref None
                while (x := compute r; (!x).IsSome) do 
                    yield (!x).Value
            finally 
                closef r }


open System 
open System.Collections.Generic
open System.Configuration
open System.Data
open System.Data.SqlClient
open System.Windows.Forms


// create a connectio then execute the given command on it 
let opener commandString = 
    // read the connection string 
    let connectionSetting = 
        ConfigurationManager.ConnectionStrings.["MyConnection"]

    // create the connection and open it 
    let conn = new SqlConnection(connectionSetting.ConnectionString)
    conn.Open()

    // execute the commad , ensuring the read willl close the connection  
    let cmd = conn.CreateCommand(CommandType =CommandType.Text,
                                 CommandText = commandString)
    cmd.ExecuteReader(CommandBehavior.CloseConnection)
// reader each row from the data reader tointo the a dictionary 
let generator (reader: IDataReader) = 
    if reader.Read() then 
        let dict = new Dictionary<string, obj>()
        for x in [ 0 .. (reader.FieldCount - 1) ] do 
            dict.Add(reader.GetName(x), reader.Item(x)) 
        Some(dict)
    else
        None

// execute a data command returning a sequence containing the results 
let execCommand commandString = 
    Seq.generate 
        (fun () -> opener commandString )
        (fun r -> generator r)
        (fun r -> r.Dispose())

// get the contents of the contracts table
let contactsTable = 
    (execCommand  "select top 10 * from Contact") 

// create a list of first and last names
let contacts = 
    [| for row in contactsTable ->
        Printf.sprintf "%O %O"
            (row.["FirstName"])
            (row.["LastName"]) |]

// create a list of first and last names 
let form = 
    let temp = new Form()
    let combo = new ComboBox(Top = 8, Left = 8, DataSource = contacts) 
    temp.Controls.Add(combo)
    temp 

// show the form 
//Application.Run(form)