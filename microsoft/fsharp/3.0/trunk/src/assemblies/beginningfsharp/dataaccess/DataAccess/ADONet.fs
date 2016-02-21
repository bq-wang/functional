module ADONet

// http://msdn.microsoft.com/en-us/library/dd233198.aspx
//     Flexible Types (F#)
(*

A flexible type annotation indicates that a parameter, variable, or value has a type that is compatible with a specifed type, where compatibility is determined by position in an object-oriented hierarchy of classes or interfaces. Flexible types are useful specifically when the automatic conversion to types higher in the type hierarchy does not occur but you still want to enable your functionality to work with any type in the hierarchy or any type that implements an interface.

*)

(*
you can check the "Object-Oriented Programming"  on part: "Type Annotations for Subtyping" 

as a summary :

the upcast operator: 
    showForm (myForm :> Form)
and the derived type annotation operator: 
    let showFormRevised (form : #Form) =
        form.Show()
*)


open System.Configuration
open System.Data
open System.Data.SqlClient

// get the connection string 
let connectionString = 
    let connectionSetting = 
        ConfigurationManager.ConnectionStrings.["MyConnection"]
    connectionSetting.ConnectionString


let main() = 
    // create a connection 
    use connection = new SqlConnection(connectionString)
    // create a command 
    let command = 
        connection.CreateCommand(CommandText = "select * from Person.Contact", 
                                CommandType = CommandType.Text)

    // open the connection 
    connection.Open()

    // open a reader to read data from the DB
    use reader = command.ExecuteReader()

    // fetch the ordinal 
    let title =reader.GetOrdinal("Title");
    let firstName =  reader.GetOrdinal("FirstName")
    let lastName = reader.GetOrdinal("LastName")


    // function to read strings from the data reader
    let getString(r : #IDataReader) x = 
        if r.IsDBNull(x) then ""
        else r.GetString(x) 

    // read all the items 
    while reader.Read() do 
        printfn "%s %s %s" 
            (getString reader title) 
            (getString reader firstName) 
            (getString reader lastName)
main() 