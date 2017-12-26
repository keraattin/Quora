<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="AllTopics.aspx.cs" Inherits="Quora.AllTopics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="margin-top:85px;>
  <div class="row">
                 <asp:Repeater ID="RepeaterTopic" runat="server">
                        <ItemTemplate>
                        <div class="col-md-4"></div>
                            <div class="col-md-4">
                                    <div class="card" style="margin-left:38%; width:600px; margin-top:2%;">
                                      <h5 class="card-header"><a href="Topic.aspx?TopicId=<%# Eval("TopicId") %>"> <%# Eval("Topic") %> </a></h5>
                                      <div class="card-block" style="padding:8px;">
                                        <p><%# Eval("Description") %></p>
                                      </div>
                                   </div>
                                </div>
                           <div class="col-md-4"></div>
                        </ItemTemplate>
                    </asp:Repeater>
   </div><!--Row sonu-->
</div>
</asp:Content>
