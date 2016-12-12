<%@ Page Title="" Language="C#" MasterPageFile="~/Reception.Master" AutoEventWireup="true" CodeBehind="NewsContent.aspx.cs" Inherits="News.NewsContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        *{
            margin:auto;
        }
        #ContentPlaceHolder1_lbContent{
            position:relative;
            top:30px;
        }
        .content{
            text-align:center;
            width:100%;
            margin-top:30px;
        }
        .newsContent{
            width:940px;
            margin:auto;
            margin-bottom:30px;
        }
        #ContentPlaceHolder1_lbTitle{
            font-weight:bold;
        }
        .comment{
            width:100%;
            height:100px;
            border:1px solid #c4c4c4;   
            border-radius:5px;
            margin-top:20px;
        }
        .comment_container{
            width:940px;
            height:auto;
            border-top:1px dashed #808080;
        }
        .btn1{
            width:70px;
            height:35px;
            border:1px solid RGB(22,155,213);
            background-color:RGB(22,155,213);
            border-radius:4px;
            color:white;
            float:right;
        }
        .btnContainer{
            text-align:center;
            margin-top:100px;
        }
        .btnOnce,.btnBeforePage,.btnNextPage,.btnLastPage{
            padding:10px 20px 10px 20px;
            background-color:RGB(22,155,213);
            border:1px solid RGB(22,155,213);
            border-radius:4px;
            margin-right:15px;
        }
        .tabComment{
            width:700px;
            height:auto;
            float:none;
        }
        .td1{
            padding-top:15px;
        }
        .td2{
            text-align:right;
            border-bottom:1px dashed #c4c4c4;
            padding-bottom:20px;
        }
        .head_comment{
            color:#ff0000;
            border:1px solid #ff0000;
            width:70px;
            height:30px;
            line-height:30px;
            text-align:center;
            font-weight:bold;
            border-top-left-radius:10px;
            border-top-right-radius:10px;
            border-bottom:none;
            float:left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <asp:Label ID="lbTitle" CssClass="lb1" runat="server" ></asp:Label>
    <br />
    <br />
    <asp:Label ID="lbCreatedTime" CssClass="lb2" runat="server" ></asp:Label>
    </div>
    <div class="newsContent">
        <asp:Label ID="lbContent" runat="server" ></asp:Label>
    </div>
    <br /><br /><br />
    <div class="comment_container">
        <div class="comment">
            <textarea id="txtComment" cols="20" rows="2" runat="server" style="overflow:auto;width:910px;height:70px;margin-left:12px;margin-top:12px;outline:none;border:0px;font-size:10px;"></textarea>
        </div>
        <br />
        <asp:Button ID="btnReply" CssClass="btn1" runat="server" Text="回复" OnClick="btnReply_Click" />
        <br /><br /><br />
        <div style="float:left;width:700px;height:30px;margin-bottom:20px;">
            <div class="head_comment">评论</div>
            <div style="width:628px;border-bottom:1px solid #ff0000;height:30px;float:right;"></div>
        </div>

        <div class="comment_list"></div>
        
        <div class="btnContainer">
            <button class="btnOnce" type="button">首页</button>
            <button class="btnBeforePage" type="button">上页</button>
            <button class="btnNextPage" type="button">下页</button>
            <button class="btnLastPage" type="button">尾页</button>
        </div>
    </div>
    <script src="jquery-3.1.1.min.js"></script>
    <script>
        
        var pagesize = 10;
        var pageCount = 1;
        var pageIndex = 1;
        var id = 0;
        if(getQueryString("id") == null){
            id = 0;
        }
        else {
            id = getQueryString("id");
        }

        createList();

        $(".btnOnce").click(function () {
            if (pageIndex > 1) {
                pageIndex = 1;
            }
            createList();
        })

        $(".btnBeforePage").click(function () {
            if (pageIndex > 1) {
                pageIndex = pageIndex - 1;
            }
            createList();
        })

        $(".btnNextPage").click(function () {
            if (pageIndex < pageCount) {
                pageIndex = pageIndex + 1;
                createList();
            }
        })

        $(".btnLastPage").click(function () {
            if (pageIndex < pageCount) {
                pageIndex = pageCount;
                createList();
            }
        })


        function createList() {
            $.ajax({
                url: "HdrComment.ashx",
                type: "post",
                data: {pSize:pagesize,pIndex:pageIndex,pId:id},
                success: function (result) {
                    var commentList = $.parseJSON(result);
                    pageCount = commentList.PageCount;
                    var list = commentList.List
                    var table = "<table class='tabComment'>";
                    for (i = 0; i < list.length; i++) {
                        table = table + "<tr>" + "<td class='td1'>" + list[i].CommentedContent + "</td>" + "</tr>"
                                + "<tr>" + "<td class='td2'>" + "评论时间：" + list[i].CreatedTime + "  访客IP：" + list[i].UserIP + "</td>" + "</tr>";
                    }
                    table + "</table>";
                    $(".comment_list").html(table);
                }
            }) 
        }



        function getQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }

    </script>


</asp:Content>
