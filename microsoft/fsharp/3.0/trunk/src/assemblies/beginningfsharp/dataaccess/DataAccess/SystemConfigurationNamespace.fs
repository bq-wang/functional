module SystemConfigurationNamespace

// what will be covered in this chapter include the followihng 
//    1. how to write one and load one settings from the configuration section 
//    2. load and display the connnection string settings from the app.config 
//    3. Load configuration file associated with other program, web application, or even machine .config file 

(*

<configuration>
    <appSettings>
        <add key="MySetting" value="An important string" />
    </appSettings>
</configuration>

*)

open System.Configuration

// read an application settings
let setting = ConfigurationManager.AppSettings.["MySetting"]

// print the settings
printfn "%s" setting


(*

<configuration>
    <connectionStrings>
    <add
        name="MyConnectionString"
        connectionString=" Data Source=server;
            Initial Catalog=pubs;
            Integrated Security=SSPI;"
        providerName="System.Data.SqlClient" />
    </connectionStrings>
</configuration>

*)

open System.Configuration


// get the connection string
let connectionStringDetails = 
    ConfigurationManager.ConnectionStrings.["MyConnectionString"]

// print the details 
printfn "%s\r\n%s" 
    connectionStringDetails.ConnectionString
    connectionStringDetails.ProviderName


open System.Configuration
// open the machihne config 
let config = 
    ConfigurationManager.OpenMachineConfiguration()

// print the names of all sections 
for x in config.Sections do 
    printfn "%s" x.SectionInformation.Name
