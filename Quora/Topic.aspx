<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Topic.aspx.cs" Inherits="Quora.Topic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:85px;">
        <div class="row">
                <asp:Repeater ID="RepeaterTopic" runat="server">
                        <ItemTemplate>
                        <div class="col-md-2"></div>
                            <div class="col-md-8">
                                    <div class="card">
                                      <h5 class="card-header"><%# Eval("Topic") %></h5>
                                      <div class="card-block" style="padding:8px;">
                                        <p><%# Eval("Description") %></p>
                                      </div>
                                   </div>
                                </div>
                           <div class="col-md-2"></div>
                        </ItemTemplate>
                    </asp:Repeater>
        </div>
    </div>
</asp:Content>
