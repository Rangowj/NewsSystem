<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePW.aspx.cs" Inherits="News.UpdatePW" %>

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
        .txt1,.txt2,.txt3{
            width:200px;
            height:25px;
            border-radius:4px;
            border:1px solid #c4c4c4;
            padding-left:5px;
        }
        .div1,.div2,.div3{
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="body">
        <div class="login_container">
            <div class="newUser">密码修改</div>
            <div class="content">
                <div class="div3">
                    <%--<div style="float:left;margin-right:15px;margin-left:5px;"><label>用户名：</label></div>--%>
                    <asp:TextBox ID="tbUserName" CssClass="txt3" placeholder="用户名" runat="server"></asp:TextBox>
                    <p></p>
                </div>
                <div class="div1">
                    <%--<div style="float:left;margin-left:5px;"><label>原密码：</label></div>--%>
                    <asp:TextBox ID="tbOldPW" CssClass="txt1" placeholder="原密码" runat="server" TextMode="Password"></asp:TextBox>
                    <p></p>
                </div>
                <div class="div2">
                    <%--<div style="float:left;margin-right:15px;margin-left:5px;"><label>新密码：</label></div>--%>
                    <asp:TextBox ID="tbNewPW" CssClass="txt2" placeholder="新密码" runat="server" TextMode="Password"></asp:TextBox>
                    <p></p>
                </div>
            </div>
            <asp:Button ID="btnUpdate" CssClass="btn1" runat="server" Text="确认修改" OnClick="btnLogin_Click" />
        </div>
        <div class="right">
            <img src="奔跑.jpg" style="width:500px;height:500px;" />
        </div>
    </div>
    </form>
</body>
</html>
