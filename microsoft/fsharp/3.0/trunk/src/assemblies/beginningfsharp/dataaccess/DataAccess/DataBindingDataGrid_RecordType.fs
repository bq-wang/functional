module DataBindingDataGrid_RecordType


(*
you may start by doing the sqlcmd to create database and others. 
    http://stackoverflow.com/questions/8693561/how-to-use-sqlcmd-to-create-a-database


you can use the sqlcmd -i command to run a script 


    sqlcmd -i C:\path\to\file.sql
 
SQL Server books online: 
      http://msdn.microsoft.com/en-us/library/ms162773.aspx

More options can be found in SQL Server books online.



e.g

CREATE DATABASE dbName
ON (
  NAME = dbName_dat,
  FILENAME = 'D:\path\to\dbName.mdf'
)
LOG ON (
  NAME = dbName_log,
  FILENAME = 'D:\path\to\dbName.ldf'
)

find more details on which tables are available from the database you can do the following. 

   Learn About Databases - SQL Server:  http://www.ubercode.com/learn-about-databases-sql-server.html


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



// what will be covered in this chapter incldue the following 
//   1. how to use the FSharp reflection for data binding 

open System
open System.Collections.Generic
open System.Configuration
open System.Data
open System.Data.SqlClient
open Microsoft.FSharp.Reflection


// a command that returns dynamically created stongly typed collection

let execCommand<'a> commandString : seq<'a> = 
    // the opener that executes the command 
    let opener() = // it will be error if you try to do "let opener = "
        // read the connection string 
        let connectionSetting = 
            ConfigurationManager.ConnectionStrings.["MyConnection"]

        // create the connection and open it 
        let conn = new SqlConnection(connectionSetting.ConnectionString)
        conn.Open()

        // execute the cmmand, ensuring the read close teh collectoin 
        let cmd = conn.CreateCommand(CommandType  = CommandType.Text, 
                                    CommandText = commandString) 
        cmd.ExecuteReader(CommandBehavior.CloseConnection)

    // the generator, that generates an strongly typed object for each 
    let generator (reader : IDataReader) = 
        if reader.Read() then 
            // get the type object and its properties
            let t = typeof<'a>
            // get the values for the row from the reader
            let values = Array.create reader.FieldCount (new obj())

            reader.GetValues(values) |> ignore 
            let convertVals x = match box x with | :? DBNull -> null | _ -> x 
            let values = Array.map convertVals values
            // create the record and return it 
            Some(FSharpValue.MakeRecord(t, values) :?> 'a) 
        else 
            None

    // generate the sequence
    Seq.generate
        opener
        generator
        (fun r -> r.Dispose())


// since that we already have the generic version of the code, let's define some data that can work with the Generic 

open System
open System.Windows.Forms
//open Strangelights.DataTools

// a type that mirros the type of row being created 
type Contact = 
    { ContactID: Nullable<int>;
        NameStyle: Nullable<bool>;
        Title: string;
        FirstName: string;
        MiddleName: string;
        LastName: string;
        Suffix: string;
        EmailAddress: string;
        EmailPromotion: Nullable<int>;
        Phone: string;
        PasswordHash: string;
        PasswordSalt: string;
        AdditionalContactInfo: string;
        rowguid: Nullable<Guid>;
        ModifiedDate: Nullable<DateTime> }

// a form containing a data bound data grid
let form = 
    let temp = new Form() 
    let grid = new DataGridView(Dock = DockStyle.Fill)
    temp.Controls.Add(grid)
    let contacts =  
//        execCommand<Contact> "select top 10 * from Person.Contact"
          execCommand<Contact> "select top 10 * from Contact"
    let contactsArray = contacts |> Seq.toArray
    grid.DataSource  <- contactsArray 
    temp 

// show the form 
//Application.Run(form) 