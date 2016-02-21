<%@ Page Inherits ="Strangelights.HttpHandler.HelloUser" %>

<html>
    <head>
        <title>F# - Hello User</title>
    </head>
    
    <body>
        <p>Hello User</p>
        <form id="theForm" runat="server">
            <asp:Label runat="server"
                ID="OutputControl"
                Text="Enter your name"
                runat="server"></asp:Label>
            <br />
            <asp:TextBox runat="server"
            ID="InputControl"
            runat="server"></asp:TextBox>
            <br />
            <asp:LinkButton runat="server"
                ID="SayHelloButton"
                Text="Say Hello... "
                runat="Server"
                OnClick="SayHelloButton_Click"></asp:LinkButton>
        </form>
    </body>
</html>