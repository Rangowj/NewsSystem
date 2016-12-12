<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="News.UserLogin" %>

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
            height:350px;
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
        .txt1,.txt2{
            width:200px;
            height:25px;
            border-radius:4px;
            border:1px solid #c4c4c4;
            padding-left:5px;
        }
        .div1,.div2{
            width:100%;
            height:50px;
        }
        p{
            margin:0px;
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
            margin-top:50px;
        }
        .registered{
            margin-top:20px;
        }
        .right{
            float:left;
            margin-left:250px;
            margin-top:30px;
        }
        .registered,.updatePW{
            width:50%;
            height:18px;
            float:left;
            margin:0px;
        }
        .showPW{
            margin-bottom:20px;
            color:#808080;
        }
        #cbShowPW{
            width:15px;
            height:15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="body">
        <div class="login_container">
            <div class="newUser">用户登录</div>
            <div class="content">
                <div class="div1">
                    <asp:TextBox ID="tbUserName" CssClass="txt1" placeholder="用户名" runat="server" ></asp:TextBox>
                    <p></p>
                </div>
                <div class="div2">
                    <asp:TextBox ID="tbPassWord1" CssClass="txt2" placeholder="密码" runat="server" TextMode="Password"></asp:TextBox>
                    <p></p>
                </div>
                <div class="registered"><a  href="Registered.aspx" style="text-decoration:none;color:#808080;">注册新用户</a></div>
                <div class="updatePW"><a  href="UpdatePW.aspx" style="text-decoration:none;color:#808080;">修改密码</a></div>
            </div>
            <asp:Button ID="btnLogin" CssClass="btn1" runat="server" Text="登录" OnClick="btnLogin_Click" />
        </div>
        <div class="right">
            <img src="奔跑.jpg" style="width:500px;height:500px;" />
        </div>
    </div>
    </form>
</body>
</html>
