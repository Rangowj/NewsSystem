<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registered.aspx.cs" Inherits="News.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        .body{
            width:1349px;
            height:961px;
            background:linear-gradient(#ffffff,#808080);
        }
        .login_container{
            width:300px;
            height:400px;
            margin-left:100px;
            margin-top:100px;
            background:linear-gradient(#c4c4c4,#808080);
            border-radius:5px;
            text-align:center;
            float:left;
        }
        .newUser{
            width:100%;
            height:50px;
            line-height:50px;
            background-color:RGB(254,153,0);
            border-radius:5px;
            margin-bottom:40px;
        }
        .tb1,.tb2,.tb3,.tb4{
            width:200px;
            height:25px;
            border-radius:4px;
            border:1px solid #c4c4c4;
            padding-left:5px;
        }
        .div1,.div2,.div3,.div4{
            width:100%;
            height:50px;
        }
        p{
            margin:0px;
            padding-left:50px;
            color:#808080;
        }
        .btn1{
            width:200px;
            height:50px;
            background-color:RGB(254,153,0);
            border:1px solid RGB(254,153,0);
            border-radius:4px;
            color:aliceblue;
            font-weight:bold;
            font-size:20px;
            margin-top:10px;
        }
        .registered{
            margin-top:20px;
        }
        .right{
            float:left;
            margin-left:250px;
            margin-top:30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="body">
        <div class="login_container">
        <div class="newUser">新用户注册</div>
        <div class="content">
            <div class="div1">
                <asp:TextBox ID="tbUserName" CssClass="tb1" placeholder="用户名" runat="server"></asp:TextBox>
            </div>
            <div  class="div4">
                <asp:TextBox ID="tbPhone" CssClass="tb4" placeholder="手机" runat="server"></asp:TextBox>
            </div>
            <div class="div2">
                <asp:TextBox ID="tbPassWord1" CssClass="tb2" placeholder="密码" runat="server" TextMode="Password"></asp:TextBox>
                <p></p>
             </div>
            <div class="div3"> 
                <asp:TextBox ID="tbPassWord2" CssClass="tb3" placeholder="确认密码" runat="server" TextMode="Password"></asp:TextBox>
            </div>
        </div>
        <div class="registered"><a href="Login.aspx" style="text-decoration:none;color:#808080;">老用户登录</a></div>
        <asp:Button ID="btnLogin" CssClass="btn1" runat="server" Text="立即注册" OnClick="btnLogin_Click1"  />
    </div>
        <div class="right">
            <img src="奔跑.jpg" style="width:500px;height:500px;" />
        </div>
    </div>
    </form>
</body>
</html>
