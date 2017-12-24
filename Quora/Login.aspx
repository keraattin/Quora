<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Quora.Login" %>
<%@ Register src="WebUserControlLogin.ascx" tagname="WebUserControlLogin" tagprefix="wuc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/><!--Siteyi Responsive yapar-->
	<link href="css/bootstrap.css" rel="stylesheet" media="screen" />
    <link href="LoginStyle.css" rel="stylesheet" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="container">
                <div class="row">
                 <div class="col-md-2 left">
                     </br>
                     &nbsp&nbsp&nbsp<a href="https://google.com"><img src="images/google.png" id ="google"></a>
					 </br>
                     </br>
					 &nbsp&nbsp&nbsp<a href="https://facebook.com"><img src="images/facebook.png" id="facebook"></a>
                 </div>
                 <div class="col-md-4">
                 </div>
                 <div class="col-md-4"><wuc:WebUserControlLogin ID="WebUserControlLogin" runat="server" />  </div>
                <div class="col-md-2"></div>
               </div><!--row-->
            </div>              
        </div>
	<script src="js/jquery-3.2.1.min.js"></script>
	<script src="js/bootstrap.js"></script>
    </form>
</body>
</html>
