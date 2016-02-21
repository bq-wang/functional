module ADONet_Library


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



open System.Configuration
open System.Collections.Generic
open System.Data
open System.Data.SqlClient
open System.Data.Common
open System

/// create and open an SqlConnection object using the connection string found
/// in the configuration file for the given connection name
let openSQLConnection(connName : string ) =
    let connSetting = ConfigurationManager.ConnectionStrings.[connName]
    let conn = new SqlConnection(connSetting.ConnectionString)
    conn.Open()
    conn

/// create and execute a read command for a connection using
/// the connection string found in the configuration file
/// for the given connection name
let openConnectionReader connName cmdString =
    let conn = openSQLConnection(connName)
    let cmd = conn.CreateCommand(CommandText=cmdString,
                                CommandType = CommandType.Text)
    let reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
    reader
/// read a row from the data reader
let readOneRow (reader: #DbDataReader) = 
    if reader.Read() then 
        let dict = new Dictionary<string, obj>()
        for x in [ 0 .. (reader.FieldCount - 1) ] do 
            dict.Add(reader.GetName(x), reader.[x])
        Some(dict)
    else 
        None

/// execute a command using the Seq.generate
let execCommand(connName : string) (cmdString : string) = 
    Seq.generate  
        // This function gets called to open a connection and create a reader
        (fun () -> openConnectionReader connName cmdString)
        // this function gets called to read a single iem in 
        // the enumerate for a reader/connection pair 
        (fun reader -> readOneRow(reader))
        (fun reader -> reader.Dispose())

/// open the contacts table
let contactsTable =
    execCommand  
        "MyConnection"
        "select * from Person.Contact"

// print out the data retrieved from the database
for row in contactsTable do   
    for col in row.Keys do 
        printfn "%s = %O" col (row.Item(col))


(*

you should especially avoid any user interfaction with collection with the collection. for the 
same reason, for the same reason, for example. the following examples, which rewrites the previous example so the user can move on to
the next record by pressing Enter. 

for row in contactsTable do 
    for col in row.Keys do 
        printfn "Press <enter> to see next record"
        read_line() |> ignore 


*)