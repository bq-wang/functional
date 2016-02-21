// Learn more about F# at http://fsharp.net

module Program

(*


the following code is take from the SystemConfigurationNamepace.fs file 

open System.Configuration

// read an application settings
let setting = ConfigurationManager.AppSettings.["MySetting"]

// print the settings
printfn "%s" setting

*)

(*

Read the connection string configuration

*)

open System.Configuration

// get the connection string
let connectionStringDetails = 
    ConfigurationManager.ConnectionStrings.["MyConnectionString"]

// print the details 
printfn "%s\r\n%s" 
    connectionStringDetails.ConnectionString
    connectionStringDetails.ProviderName

(*
Data Source=server;
Initial Catalog=pubs;
Integrated Security=SSPI;
System.Data.SqlClient
*)



(*

open machine config 

*)


open System.Configuration
// open the machihne config 
let config = 
    ConfigurationManager.OpenMachineConfiguration()

// print the names of all sections 
for x in config.Sections do 
    printfn "%s" x.SectionInformation.Name

(*

the following wil be printed 

system.data
windows
system.webServer
mscorlib
system.data.oledb
system.data.oracleclient
system.data.sqlclient
configProtectedData
satelliteassemblies
system.data.dataset
startup
system.data.odbc
system.diagnostics
runtime
system.codedom
system.runtime.remoting
connectionStrings
assemblyBinding
appSettings
system.windows.forms


*)
