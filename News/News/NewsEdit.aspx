<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewsEdit.aspx.cs" Inherits="News.NewsEdit" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .div1{
            font-size:25px;
            margin-top:20px;
            margin-left:40px;
        }
        .div2{
            text-align:center;
        }
        .btn1,.btn2{
            width:100px;
            height:37px;
        }
        .btn1{
            color:white;
            border:1px solid RGB(22,155,213);
            border-radius:4px;
            background-color:RGB(22,155,213);
        }
        .btn2{
            background-color:white;
            border:1px solid #c4c4c4;
            border-radius:4px;
        }
        #table,td{
            border:1px solid black;
            border-collapse:collapse;
            font-size:25px;
            text-align:center;
        }
        #table{
            margin:0 auto;
            margin-top:15px;
            max-height:610px;
        }
        .td1{
            width:150px;                      
        }
        .td2{
            width:600px;   
            padding-bottom:7px;         
        }
        .tb1{
            width:700px; 
            margin-left:10px;
            margin-right:10px; 
            margin-top:5px;          
        }
        .td4{
            padding-bottom:7px;
        }
        .ddl1{
            width:704px;
            padding-top:3px;
            padding-bottom:3px;
            margin-top:5px;
        }
        .td5{
            height:400px;
        }
        .txt1{
            width:580px;
            height:390px;
            border:none;
        }
        #cke_ContentPlaceHolder1_CKEditorControl1{
            width:700px;
            border:none;
            margin:auto;
        }
    </style>
    <link href="kindeditor/plugins/code/prettify.css" rel="stylesheet" type="text/css" />
    <script src="kindeditor/lang/zh_CN.js" type="text/javascript"></script>
    <script src="kindeditor/kindeditor.js" type="text/javascript"></script>
    <script src="kindeditor/plugins/code/prettify.js" type="text/javascript"></script>  
    <script type="text/javascript">
        KindEditor.ready(function (K) {
            var editor = K.create('#content', {
                //上传管理
                uploadJson: 'kindeditor/asp.net/upload_json.ashx',
                //文件管理
                fileManagerJson: 'kindeditor/asp.net/file_manager_json.ashx',
                allowFileManager: true,
                //设置编辑器创建后执行的回调函数
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                },
                //上传文件后执行的回调函数,获取上传图片的路径
                afterUpload : function(url) {
                        alert(url);
                },
                //编辑器高度
                width: '700px',
                //编辑器宽度
                height: '450px;',
                //配置编辑器的工具栏
                items: [
                'source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'code', 'cut', 'copy', 'paste',
                'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent', 'subscript',
                'superscript', 'clearhtml', 'quickformat', 'selectall', '|', 'fullscreen', '/',
                'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
                'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'image', 'multiimage',
                'flash', 'media', 'insertfile', 'table', 'hr', 'emoticons', 'baidumap', 'pagebreak',
                'anchor', 'link', 'unlink', '|', 'about'
                ]
            });
            prettyPrint();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="div1"><b>新闻编辑</b></div>
    <table id="table">
        <tr>
            <td class="td1">新闻标题</td>
            <td class="td2">
                <asp:TextBox ID="tbTitle" CssClass="tb1" runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="td3">新闻分类</td>
            <th class="td4">
                <asp:DropDownList ID="ddlSort" CssClass="ddl1" runat="server"></asp:DropDownList>
            </th>
        </tr>
        <tr>
            <td class="td5">新闻内容</td>
            <td class="td6">
                <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server"></CKEditor:CKEditorControl>
            </td>
        </tr>
    </table>
    <div class="div2">
        <asp:Button ID="btnSave" CssClass="btn1" runat="server" Text="保存" OnClick="btnSave_Click" />
        <asp:Button ID="btnBack" CssClass="btn2" runat="server" Text="返回列表" OnClick="btnBack_Click" />        
    </div>
</asp:Content>
