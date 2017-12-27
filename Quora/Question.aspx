<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="Quora.Question" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container" style="margin-top:85px;">
        <div class="row">
            <div class="col-md-2"></div>
             <div class="col-md-6">
                  <div class="panel panel-default">
                      <div class="panel-heading">
                  <asp:Repeater ID="RepeaterQuestionTopic" runat="server">
                      <ItemTemplate>
                       <a href="Topic.aspx?TopicId=<%# Eval("TopicId") %>"><input type="button" class="btn btn-primary" value="<%# Eval("Topic") %>" style="padding:0px" /></a>
                       </ItemTemplate>
                  </asp:Repeater>
                          </div>
                <asp:Repeater ID="RepeaterQuestion" runat="server">
                        <ItemTemplate>
                                      <div class="panel-body" style="padding:8px;">
                                        <b><h3><%# Eval("Question") %></h3></b>
                                      </div>
                        </ItemTemplate>
                    </asp:Repeater>
                  <div class="panel-footer">
                      <asp:Repeater ID="RepeaterQuestionUser" runat="server">
                          <ItemTemplate>
                            <a href=""><%# Eval("Name") %> <%# Eval ("LastName") %></a>
                          </ItemTemplate>
                      </asp:Repeater>
                   </div>
                 </div>
               </div>
        <div class="col-md-4"></div>
        </div>
        <hr />
        <div class="row">
                <asp:Repeater ID="RepeaterAnswers" runat="server">
                        <ItemTemplate>
                        <div class="col-md-2"></div>
                            <div class="col-md-6">
                                    <div class="panel panel-default" style="margin-top:2%;">
                                       <div class="panel-heading">
                                            <a href=""><%# Eval("Name") %> <%# Eval("LastName") %></a> 
                                        </div>
                                      <div class="panel-body" style="padding:8px;">
                                        <p><%# Eval("Answer") %></p>
                                      </div>
                                       <div class="panel-footer" style="padding-bottom:8px;">
                                           <a href="" style="float:right;"><%# Eval("Date") %></a>
                                       </div>
                                   </div>
                                <hr />
                                </div>
                           <div class="col-md-4"></div>
                        </ItemTemplate>
                    </asp:Repeater>
        </div>
        <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-header">
                            <a href="Profile.aspx?UserId=<%# Session["UserId"] %>"><asp:Label ID="LabelUserName" runat="server" Text=""></asp:Label></a>
                        </div>
                        <div class="card-block" style="margin-top:5px;">
                            <asp:TextBox ID="TextBoxAnswer" runat="server" class="form-control input-lg" required=""></asp:TextBox>
                        </div>
                        <div class="card-footer">
                            <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" class="btn btn-primary" OnClick="ButtonSubmit_Click"/>
                        </div>
                    </div>
                </div>
                <div class="col-md-4"></div>           
         </div>
    </div>
</asp:Content>
