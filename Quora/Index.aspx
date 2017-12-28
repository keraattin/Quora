<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Quora.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="IndexStyle.css" rel="stylesheet" media="screen" />
    <div class="container" style="margin-top:85px;">
        <div class="row">
            <div class="col-md-3">
                    <div class="panel panel-default">
                      <div class="panel-heading">
                        <h5 class="panel-title"><b>Feeds</b><hr /></h5>
                      </div>
                      <div class="panel-body">
                          <ul>
                              <li>
                                  <a href="">Top story</a>
                              </li>
                              <li>
                                  <a href="">New Answers</a>
                              </li>
                              <li>
                                  <a href="">New Questions</a>
                              </li>
                              <li>
                                  <a href="">Bookmarked Answers</a>
                              </li>
                          </ul>
                      </div>
                    </div>
            </div>
            <div class="col-md-6">
                    <div class="card">
                      <div class="card-block baslik">
                        <a href="Profile.aspx"><asp:Label ID="LabelNameSurname" runat="server" Text=""></asp:Label></a><br />
                        <a class="h5" href="#" onclick="$('#myModal').modal('show')">What is your question?</a>
                      </div>
                   </div>
                     <asp:Repeater ID="RepeaterTopic" runat="server">
                        <ItemTemplate>
                        <div class="card" style="margin-top:5px;">
                            <div class="card-header">
                                <a href="Topic.aspx?TopicId=<%# Eval("TopicId") %>"><h5><%# Eval("Topic") %></h5></a>
                             </div>
                            <div class="card-block" style="padding:5px;">
                                 <p><%# Eval("Description") %></p>
                            </div>
                        </div>
                       </ItemTemplate>
                    </asp:Repeater>
            </div>
            <div class="col-md-3">
                <div class="card" style="width:180px;">
              <h5 class="card-header">Set Up Your Account</h5>
              <div class="card-block" style="text-align:left; padding:12px; padding-left:14px;">
                <a href="#">Visit your feed<span class="glyphicon glyphicon-ok"></span></a><br />
                <br /><a href="#">Follow 20 more topics<span class="glyphicon glyphicon-ok"></span></a><br />
                <br /><a href="#">Find your friends on quora<span class="glyphicon glyphicon-ok"></span></a><br />
                <br /><a href="#">Upvote 5 more good answers<span class="glyphicon glyphicon-ok"></span></a><br />
                <br /><a href="#">Ask your first question<span class="glyphicon glyphicon-ok"></span></a><br />
                <br /><a href="#">Add 3 credentials<span class="glyphicon glyphicon-ok"></span></a><br />
                <br /><a href="#">Answer a question<span class="glyphicon glyphicon-ok"></span></a><br />
              </div>
            </div>
            </div>
        </div>
    </div>
</asp:Content>

