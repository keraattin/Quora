<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControlLogin.ascx.cs" Inherits="Quora.WebUserControlLogin" %>

<style type="text/css">
body {
  padding-top: 40px;
  padding-bottom: 40px;
  background-color: #eee;
}

.form-signin {
  max-width: 330px;
  padding: 15px;
  margin: 0 auto;
}
.form-signin .form-signin-heading,
.form-signin .checkbox {
  margin-bottom: 10px;
}
.form-signin .checkbox {
  font-weight: 400;
}
.form-signin .form-control {
  position: relative;
  box-sizing: border-box;
  height: auto;
  padding: 10px;
  font-size: 16px;
}
.form-signin .form-control:focus {
  z-index: 2;
}
.form-signin input[type="email"] {
  margin-bottom: -1px;
  border-bottom-right-radius: 0;
  border-bottom-left-radius: 0;
}
.form-signin input[type="password"] {
  margin-bottom: 10px;
  border-top-left-radius: 0;
  border-top-right-radius: 0;
}
h2{
    font-weight:bold;
	color:#b30000;
}
</style>

<asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        </br>
        </br>
        <h2>Quora</h2>
        <asp:TextBox ID="TextBoxEmail" runat="server" autofocus="" class="form-control" placeholder="Email address" required="" type="email"></asp:TextBox>
        </br>
        <asp:TextBox ID="TextBoxPassword" runat="server" class="form-control" placeholder="Password" required="" type="password"></asp:TextBox>
        </br>
        <asp:Button ID="LoginButton" runat="server" class="btn btn-lg btn-primary btn-block" OnClick="LoginButton_Click" Text="Sign In" />
        </br>
        <asp:Label ID="LabelResult" runat="server" ForeColor="#CC0000"></asp:Label>
        </br>
    </ContentTemplate>
</asp:UpdatePanel>
