--  README
DistributedApplicationsClient.


which will demonstrate the use of the WCF programming model 


in this book, we will examing creating a Windows Communication Foudation chapter and show you how 



the program that you can do is as follow. 

svcutil.exe http://localhost:14385/GreetingService.svc?wsdl

--

the returned results of the command 

svcutil.exe http://localhost:14385/GreetingService.svc?wsdl


--

and then it will create two files, one is called

正在尝试使用 WS-Metadata Exchange 或 DISCO 从“http://localhost:14385/GreetingSe
rvice.svc?wsdl”下载元数据。
正在生成文件...
C:\dev\functional\microsoft\fsharp\3.0\trunk\src\assemblies\BeginningFSharp\DistributedApplications\CSharpDistributedApplications\GreetingService.cs
C:\dev\functional\microsoft\fsharp\3.0\trunk\src\assemblies\BeginningFSharp\DistributedApplications\CSharpDistributedApplications\output.config



it generates two files , once is called GreetingService.cs - it contains the client code to the WCF service 
output.config , which has the reference configuration for the Service configuration .
--

then you will compile the code with the 

csc /out:greetingServiceClient.dll /target:library GreetingService.cs

--

how to start the debugging

1. you first will start the CSharpDistributedApplications
2. open a browser, and type in the browser the following address
	http://localhost:14385/GreetingService.svc

the screen shot is shown as GreetingService.svc.png file 
3. then you start the DistributedApplicationClient project, remember to modify the app.config, otherwise it will complains the Multiple end-point errors.


--

how to debug the WCF services that are hosted in any program  

1. you will first start the HostingWCFServices.fsx script 
2. however, this is a lazy service, you may need to open the browser, and type in the following address 
	http://localhost:14385/GreetingService.svc
3. then you wil start the prgram from the console.
	DistributedApplicationsClient.exe


/*


<wsdl:definitions xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/" xmlns:wsx="http://schemas.xmlsoap.org/ws/2004/09/mex" xmlns:wsa10="http://www.w3.org/2005/08/addressing" xmlns:wsp="http://schemas.xmlsoap.org/ws/2004/09/policy" xmlns:msc="http://schemas.microsoft.com/ws/2005/12/wsdl/contract" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/" xmlns:wsap="http://schemas.xmlsoap.org/ws/2004/08/addressing/policy" xmlns:wsaw="http://www.w3.org/2006/05/addressing/wsdl" xmlns:soap12="http://schemas.xmlsoap.org/wsdl/soap12/" xmlns:tns="http://tempuri.org/" xmlns:wsa="http://schemas.xmlsoap.org/ws/2004/08/addressing" xmlns:i1="http://schemas.microsoft.com/ws/2005/02/mex/bindings" xmlns:wsu="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd" xmlns:i0="http://strangelights.com/FSharp/Foundations/WCFServices" xmlns:wsam="http://www.w3.org/2007/05/addressing/metadata" xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/" name="GreetingService" targetNamespace="http://tempuri.org/">
<wsp:Policy wsu:Id="WSHttpBinding_IGreetingService_policy">
<wsp:ExactlyOne>
<wsp:All>
<sp:SymmetricBinding xmlns:sp="http://schemas.xmlsoap.org/ws/2005/07/securitypolicy">
<wsp:Policy>
<sp:ProtectionToken>
<wsp:Policy>
<sp:SecureConversationToken sp:IncludeToken="http://schemas.xmlsoap.org/ws/2005/07/securitypolicy/IncludeToken/AlwaysToRecipient">
<wsp:Policy>
<sp:RequireDerivedKeys/>
<sp:BootstrapPolicy>
<wsp:Policy>
<sp:SignedParts>
<sp:Body/>
<sp:Header Name="To" Namespace="http://www.w3.org/2005/08/addressing"/>
<sp:Header Name="From" Namespace="http://www.w3.org/2005/08/addressing"/>
<sp:Header Name="FaultTo" Namespace="http://www.w3.org/2005/08/addressing"/>
<sp:Header Name="ReplyTo" Namespace="http://www.w3.org/2005/08/addressing"/>
<sp:Header Name="MessageID" Namespace="http://www.w3.org/2005/08/addressing"/>
<sp:Header Name="RelatesTo" Namespace="http://www.w3.org/2005/08/addressing"/>
<sp:Header Name="Action" Namespace="http://www.w3.org/2005/08/addressing"/>
</sp:SignedParts>
<sp:EncryptedParts>
<sp:Body/>
</sp:EncryptedParts>
<sp:SymmetricBinding>
<wsp:Policy>
<sp:ProtectionToken>
<wsp:Policy>
<sp:SpnegoContextToken sp:IncludeToken="http://schemas.xmlsoap.org/ws/2005/07/securitypolicy/IncludeToken/AlwaysToRecipient">
<wsp:Policy>
<sp:RequireDerivedKeys/>
</wsp:Policy>
</sp:SpnegoContextToken>
</wsp:Policy>
</sp:ProtectionToken>
<sp:AlgorithmSuite>
<wsp:Policy>
<sp:Basic256/>
</wsp:Policy>
</sp:AlgorithmSuite>
<sp:Layout>
<wsp:Policy>
<sp:Strict/>
</wsp:Policy>
</sp:Layout>
<sp:IncludeTimestamp/>
<sp:EncryptSignature/>
<sp:OnlySignEntireHeadersAndBody/>
</wsp:Policy>
</sp:SymmetricBinding>
<sp:Wss11>
<wsp:Policy/>
</sp:Wss11>
<sp:Trust10>
<wsp:Policy>
<sp:MustSupportIssuedTokens/>
<sp:RequireClientEntropy/>
<sp:RequireServerEntropy/>
</wsp:Policy>
</sp:Trust10>
</wsp:Policy>
</sp:BootstrapPolicy>
</wsp:Policy>
</sp:SecureConversationToken>
</wsp:Policy>
</sp:ProtectionToken>
<sp:AlgorithmSuite>
<wsp:Policy>
<sp:Basic256/>
</wsp:Policy>
</sp:AlgorithmSuite>
<sp:Layout>
<wsp:Policy>
<sp:Strict/>
</wsp:Policy>
</sp:Layout>
<sp:IncludeTimestamp/>
<sp:EncryptSignature/>
<sp:OnlySignEntireHeadersAndBody/>
</wsp:Policy>
</sp:SymmetricBinding>
<sp:Wss11 xmlns:sp="http://schemas.xmlsoap.org/ws/2005/07/securitypolicy">
<wsp:Policy/>
</sp:Wss11>
<sp:Trust10 xmlns:sp="http://schemas.xmlsoap.org/ws/2005/07/securitypolicy">
<wsp:Policy>
<sp:MustSupportIssuedTokens/>
<sp:RequireClientEntropy/>
<sp:RequireServerEntropy/>
</wsp:Policy>
</sp:Trust10>
<wsaw:UsingAddressing/>
</wsp:All>
</wsp:ExactlyOne>
</wsp:Policy>
<wsp:Policy wsu:Id="WSHttpBinding_IGreetingService_Greet_Input_policy">
<wsp:ExactlyOne>
<wsp:All>
<sp:SignedParts xmlns:sp="http://schemas.xmlsoap.org/ws/2005/07/securitypolicy">
<sp:Body/>
<sp:Header Name="To" Namespace="http://www.w3.org/2005/08/addressing"/>
<sp:Header Name="From" Namespace="http://www.w3.org/2005/08/addressing"/>
<sp:Header Name="FaultTo" Namespace="http://www.w3.org/2005/08/addressing"/>
<sp:Header Name="ReplyTo" Namespace="http://www.w3.org/2005/08/addressing"/>
<sp:Header Name="MessageID" Namespace="http://www.w3.org/2005/08/addressing"/>
<sp:Header Name="RelatesTo" Namespace="http://www.w3.org/2005/08/addressing"/>
<sp:Header Name="Action" Namespace="http://www.w3.org/2005/08/addressing"/>
</sp:SignedParts>
<sp:EncryptedParts xmlns:sp="http://schemas.xmlsoap.org/ws/2005/07/securitypolicy">
<sp:Body/>
</sp:EncryptedParts>
</wsp:All>
</wsp:ExactlyOne>
</wsp:Policy>
<wsp:Policy wsu:Id="WSHttpBinding_IGreetingService_Greet_output_policy">
<wsp:ExactlyOne>
<wsp:All>
<sp:SignedParts xmlns:sp="http://schemas.xmlsoap.org/ws/2005/07/securitypolicy">
<sp:Body/>
<sp:Header Name="To" Namespace="http://www.w3.org/2005/08/addressing"/>
<sp:Header Name="From" Namespace="http://www.w3.org/2005/08/addressing"/>
<sp:Header Name="FaultTo" Namespace="http://www.w3.org/2005/08/addressing"/>
<sp:Header Name="ReplyTo" Namespace="http://www.w3.org/2005/08/addressing"/>
<sp:Header Name="MessageID" Namespace="http://www.w3.org/2005/08/addressing"/>
<sp:Header Name="RelatesTo" Namespace="http://www.w3.org/2005/08/addressing"/>
<sp:Header Name="Action" Namespace="http://www.w3.org/2005/08/addressing"/>
</sp:SignedParts>
<sp:EncryptedParts xmlns:sp="http://schemas.xmlsoap.org/ws/2005/07/securitypolicy">
<sp:Body/>
</sp:EncryptedParts>
</wsp:All>
</wsp:ExactlyOne>
</wsp:Policy>
<wsdl:import namespace="http://strangelights.com/FSharp/Foundations/WCFServices" location="http://localhost:14385/GreetingService.svc?wsdl=wsdl0"/>
<wsdl:import namespace="http://schemas.microsoft.com/ws/2005/02/mex/bindings" location="http://localhost:14385/GreetingService.svc?wsdl=wsdl1"/>
<wsdl:types/>
<wsdl:binding name="WSHttpBinding_IGreetingService" type="i0:IGreetingService">
<wsp:PolicyReference URI="#WSHttpBinding_IGreetingService_policy"/>
<soap12:binding transport="http://schemas.xmlsoap.org/soap/http"/>
<wsdl:operation name="Greet">
<soap12:operation soapAction="http://strangelights.com/FSharp/Foundations/WCFServices/IGreetingService/Greet" style="document"/>
<wsdl:input>
<wsp:PolicyReference URI="#WSHttpBinding_IGreetingService_Greet_Input_policy"/>
<soap12:body use="literal"/>
</wsdl:input>
<wsdl:output>
<wsp:PolicyReference URI="#WSHttpBinding_IGreetingService_Greet_output_policy"/>
<soap12:body use="literal"/>
</wsdl:output>
</wsdl:operation>
</wsdl:binding>
<wsdl:service name="GreetingService">
<wsdl:port name="WSHttpBinding_IGreetingService" binding="tns:WSHttpBinding_IGreetingService">
<soap12:address location="http://localhost:14385/GreetingService.svc"/>
<wsa10:EndpointReference>
<wsa10:Address>http://localhost:14385/GreetingService.svc</wsa10:Address>
<Identity xmlns="http://schemas.xmlsoap.org/ws/2006/02/addressingidentity">
<Upn>YJ104\Administrator</Upn>
</Identity>
</wsa10:EndpointReference>
</wsdl:port>
<wsdl:port name="MetadataExchangeHttpBinding_IGreetingService" binding="i1:MetadataExchangeHttpBinding_IGreetingService">
<soap12:address location="http://localhost:14385/GreetingService.svc/mex"/>
<wsa10:EndpointReference>
<wsa10:Address>http://localhost:14385/GreetingService.svc/mex</wsa10:Address>
</wsa10:EndpointReference>
</wsdl:port>
</wsdl:service>
</wsdl:definitions>

*/
