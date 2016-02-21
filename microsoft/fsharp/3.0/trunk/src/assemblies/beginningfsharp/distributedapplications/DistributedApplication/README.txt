
-- what will be included in this chapter 


1.  you will need to start first debugging the CSharpDistributedApplication 
2. and then from the browser, type in the following address 
	http://localhost:14385/WebServices.asmx?op=Addition
3. you will see the WebServices_asmx.png file 
4. and then you will get the response from another window from the iexplorer 

	http://localhost:14385/WebServices.asmx/Addition 

the content of the response is like below.

<int xmlns="http://strangelights.com/FSharp/Foundations/WebServices">74</int>


to test the DnaWebService, you will do the following seqence 
1.
you download the .xsd file

rnam1.xsd 
http://www-lbit.iro.umontreal.ca/rnaml/current/rnaml.xsd
from the website
	http://www-lbit.iro.umontreal.ca/rnaml/
2. you can run the following command to generate a .net class 

xsd.exe rnamel.xsd /classes 


if you do a dir then you will get something 
dir 

rnamel.cs

3. you may probably need to change the some contents of the file such as following. 


public partial class coordinates {
    
    private System.Xml.XmlAttribute[] anyAttrField;
    
    //private float[] textField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAnyAttributeAttribute()]
    public System.Xml.XmlAttribute[] AnyAttr {
        get {
            return this.anyAttrField;
        }
        set {
            this.anyAttrField = value;
        }
    }
    
    ///// <remarks/>
    //[System.Xml.Serialization.XmlTextAttribute()]
    //public float[] Text {
    //    get {
    //        return this.textField;
    //    }
    //    set {
    //        this.textField = value;
    //    }
    //}

}

it seems that it has problem handling the case of float[] with the xml attribute XmlTextAttribute on it .


4.  you then compile the code into a dll file 

 csc /out:rnamel.dll /target:library rnmal.cs

 and then you will do a dir and you will get 

 rnamel.dll

 5. add that rnamel.dll as a reference to the DistributedApplication's reference tab

 and then you can do the compilation 

 6. start the debugger and you can type this into the brower address bar

 
 
 http://localhost:14385/DnaWebServices.asmx?op=GetYeastMolecule

 the tips on how to create a wcf service and integrate that with the webserver, you will need to create a .svc file 
 here is the details on how to do that: 

1. first you will create a simple .svc file, with the following contents to instruct to tells the web server which type it should use.


<% @ServiceHost Debug="true" Service="Strangelights.Services.GreetingService" %>

this is the same as the .asmx file that you found before 


2.you must as well configure the service. here is an sample configuration 


<configuration>

  <system.web>
    <compilation debug="true" targetFramework="4.0" />
  </system.web>

  
  <!-- this is the wcf configuration that you might be using wcf services -->

  <system.serviceModel>
    <services>
      <service
        name="Strangelights.Services.GreetingService"
        behaviorConfiguration="MyServiceTypeBehavior">
        <endpoint
          contract="Strangelights.Services.IGreetingService"
          binding="wsHttpBinding" />
        <endpoint
          contract="Strangelights.Services.IGreetingService"
          binding="mexHttpBinding" address="mex" />
      </service>
    </services>
    <behaviors>
      <serviceBehaviors>
        <behavior name="MyServiceTypeBehavior">
          <serviceDebug includeExceptionDetailInFaults="true"/>
          <serviceMetadata httpGetEnabled="true"/>
        </behavior>
      </serviceBehaviors>
    </behaviors>
  </system.serviceModel>
</configuration>

3. now you can launch the server (the local server) 

4. then you can use the svcutil.exe to open address in question 

svcutil.exe http://localhost:1033/WCFService/Service.svc?wsdl

5. now you have a proxy, compile that into .dll that can be used by the Fsharp program

6. add the proxy reference to the FSharp project and then you code up the client code 

