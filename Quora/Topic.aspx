<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Topic.aspx.cs" Inherits="Quora.Topic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:85px;">
        <div class="row">
                        <div class="col-md-2"></div>
                            <div class="col-md-8">
                                    <div class="card">
                                    <asp:Repeater ID="RepeaterTopic" runat="server">
                                    <ItemTemplate>
                                      <div class="card-header"><h5><%# Eval("Topic") %></h5></div>
                                      <div class="card-block" style="padding:8px;">
                                        <p><%# Eval("Description") %></p>
                                      </div>
                                   </div>
                                  </ItemTemplate>
                                </asp:Repeater>
                                <div class="card-footer">
                                    <asp:Button ID="ButtonFollow" runat="server" Text="Follow" type="button" class="btn btn-primary" OnClick="ButtonFollow_Click"/>
                                    <asp:Button ID="ButtonUnFollow" runat="server" Text="Unfollow" type="button" class="btn" OnClick="ButtonUnFollow_Click"/>
                                </div>
                                </div>
                           <div class="col-md-2"></div>
        </div>
        <hr />
        <div class="row">
                <asp:Repeater ID="RepeaterQuestions" runat="server">
                        <ItemTemplate>
                        <div class="col-md-2"></div>
                            <div class="col-md-8">
                                    <div class="card" style="margin-top:2%;">
                                      <div class="card-block" style="padding:8px;">
                                        <p><%# Eval("Question") %></p>
                                      </div>
                                        <div class="card-footer">
                                            <a href="Question.aspx?QuestionId=<%# Eval("QuestionId") %>"><%# Eval("Date") %></a> - &nbsp
                                            <a href=""><%# Eval("Name") %> <%# Eval("LastName") %></a>
                                        </div>
                                   </div>

                                </div>
                           <div class="col-md-2"></div>
                        </ItemTemplate>
                    </asp:Repeater>
        </div>
    </div>
</asp:Content>
