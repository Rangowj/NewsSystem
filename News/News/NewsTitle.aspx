 <%@ Page Title="" Language="C#" MasterPageFile="~/Reception.Master" AutoEventWireup="true" CodeBehind="NewsTitle.aspx.cs" Inherits="News.NewsTitle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .tbNews{
            border:1px solid #000000;
            border-collapse:collapse;
            text-align:center;
            width:940px;
        }
        .tbNews th,.tbNews td{
            border:1px solid #000000;
        }
        .tbNews th{
            padding-left:20px;
            padding-right:20px;
        }
        .thTime{
            width:200px;
        }
        .pNewsList table,.pNewsList tr,.pNewsList td{
            border:1px solid #000000;
            border-collapse:collapse;
        }
        .pNewsList{
            margin:0px;
        }
        .pNewsList table{
            margin-left:29px;
            margin-top:30px;
            position:absolute;
        }
        .tdTime{
            width:200px;
        }
        .btnContainer{
            text-align:center;
            margin-top:410px;
        }
        .btnOnce,.btnBeforePage,.btnNextPage,.btnLastPage{
            padding:10px 20px 10px 20px;
            background-color:RGB(22,155,213);
            border:1px solid RGB(22,155,213);
            border-radius:4px;
            margin-right:15px;
        }
        .pNewsList .tbNews a{
            text-decoration:none;
            color:#000000;
        }
        .pNewsList .tbNews a:hover{
            color:#c4c4c4;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <p class="pNewsList"></p>
    <div class="btnContainer">
        <button class="btnOnce" type="button">首页</button>
        <button class="btnBeforePage" type="button">上页</button>
        <button class="btnNextPage" type="button">下页</button>
        <button class="btnLastPage" type="button">尾页</button>
    </div>
    <script src="jquery-3.1.1.min.js"></script>
    <script>
        var pageSize = 10;
        var pageIndex = 1;
        var pageCount = 1;
        var id = null;
        if (getQueryString("id") == null)
        {
            id = 0;
        }
        else {
            id = getQueryString("id");
        }
        getList();

        //$(".btnOnce").click(function () {
        //    getList();
        //})
        
        $(".btnNextPage").click(function () {
            if (pageIndex < pageCount) {
                pageIndex = pageIndex + 1;
                getList();
            }
        })

        $(".btnBeforePage").click(function () {
            if (pageIndex > 1) {
                pageIndex = pageIndex - 1;
                getList();
            }
        })

        $(".btnOnce").click(function () {
            if (pageIndex > 1) {
                pageIndex = 1;
                getList();
            }
        })

        $(".btnLastPage").click(function () {
            if (pageIndex < pageCount) {
                pageIndex = pageCount;
                getList();
            }
        })

        function getList() {
            $.ajax({
                url: "HdrNews.ashx",
                type: "POST",
                data: { pSize: pageSize, pIndex: pageIndex, nSortId: id },
                success: function (result) {
                    var newsContent = $.parseJSON(result);
                    var table = "<table class='tbNews'>";
                    var list = newsContent.List;
                    pageCount = newsContent.PageCount;
                    for (i = 0; i < list.length; i++) {
                        var url = "NewsContent.aspx?id="+list[i].ID;
                        table = table + "<tr>" +
                                "<td>" + "<a href = '"+url+"'>" + list[i].NewsTitle + "</a>" + "</td>" +
                                "<td class='tdTime'>" + list[0].CreatedTime + "</td>" + 
                                "</tr>";
                    }
                    table + "</table>";
                    $(".pNewsList").html(table);
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
