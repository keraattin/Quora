<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Followers.aspx.cs" Inherits="Quora.Followers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link href="ProfileStyle.css" rel="stylesheet" media="screen" />
    <div class="container" style="margin-top:85px;">
        <div class="row ust">
            <div class="col-md-1"></div>
             <div class="col-md-3"><!--Profil resmi -->
                    <asp:Image ID="ImageProfile" runat="server" Height="120px" Width="120px" ImageAlign="AbsMiddle" />
             </div>
             <div class="col-md-5"> <!--Name, Credential, Description, Followers -->
                 <asp:Repeater ID="RepeaterCredentials" runat="server">
                     <ItemTemplate>
                    <asp:Label ID="LabelNameSurname" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Black" text=""><%# Eval("Name") %> <%# Eval("LastName") %></asp:Label><br />
                    <asp:Label ID="LabelCredential" runat="server" Text="" Font-Size="Large"></asp:Label><%# Eval("ProfileCredential") %><br />
                    <asp:Label ID="LabelDescription" runat="server" Text="" Font-Size="Medium"><%# Eval("Description") %></asp:Label><br />
                 <br />
                     </ItemTemplate>
                     </asp:Repeater>
                   <asp:button ID="ButtonFollow" runat="server" text="Follow" type="button" class="btn btn-primary" OnClick="ButtonFollow_Click"/>
                   <asp:button ID="ButtonUnFollow" runat="server" text="Unfollow" type="button" class="btn" OnClick="ButtonUnFollow_Click" /> <button type="button" class="btn">Followers <asp:Label ID="LabelButtonFollowers" runat="server" Text=""></asp:Label><%# Eval("Description") %></button>
              </div>
            <div class="col-md-3"><!--Credentials And Highlights-->
                <div class="panel panel-default">
                      <div class="panel-heading">
                        <h5 class="panel-title"><b>Credential And Highlights</b><hr /></h5>
                      </div>
                      <div class="panel-body">
                          <asp:BulletedList ID="BulletedListLocation" runat="server">
                          </asp:BulletedList> 
                          <asp:BulletedList ID="BulletedListSchool" runat="server">
                          </asp:BulletedList>
                          <asp:BulletedList ID="BulletedListWork" runat="server">
                          </asp:BulletedList>
                      </div>
                    </div>
              </div><!--Col-md-3 sonu -->
        </div><!--Row üst sonu-->
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-3"><hr /></div>
            <div class="col-md-5"><hr /></div>
            <div class="col-md-3"></div>
        </div>
        <div class="row alt">
            <div class="col-md-1"></div>
            <div class="col-md-3"><!--Feeds-->
                    <div class="panel panel-default">
                      <div class="panel-heading">
                        <h5 class="panel-title"><b>Feeds</b><hr /></h5>
                      </div>
                      <div class="panel-body">
                          <ul>
                              <li>
                                  <a href="">Answers <asp:Label ID="LabelAnswers" runat="server" Text="0"></asp:Label></a>
                              </li>
                              <li>
                                  <a href="">Questions <asp:Label ID="LabelQuestions" runat="server" Text="0"></asp:Label></a>
                              </li>
                              <li>
                                  <a href="">Activity</a>
                              </li>
                              <li>
                                  <a href="">Posts</a>
                              </li>
                              <li>
                                  <a href="">Blogs</a>
                              </li>
                              <li>
                                  <a href="">Followers <asp:Label ID="LabelFollowers" runat="server" Text="0"></asp:Label></a>
                              </li>
                              <li>
                                  <a href="">Following <asp:Label ID="LabelFollowing" runat="server" Text="0"></asp:Label></a>
                              </li>
                              <li>
                                  <a href="">Topics <asp:Label ID="LabelTopics" runat="server" Text="0"></asp:Label></a>
                              </li>
                              <li>
                                  <a href="">Edits</a>
                              </li>
                          </ul>
                      </div>
                    </div>
            </div>
            <div class="col-md-5">
                <h5>Following<hr /></h5>
                <asp:Repeater ID="RepeaterFollowing" runat="server">
                    <ItemTemplate>
                        <div class="form-group">
                        <b><a href="User.aspx?UserId=<%# Eval("UserId") %>"><%# Eval("Name") %> <%# Eval("LastName") %></a></b><hr />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col-md-3"><!--Knows About-->
                <div class="panel panel-default">
                      <div class="panel-heading">
                        <h5 class="panel-title"><b>Knows About</b><hr /></h5>
                      </div>
                      <div class="panel-body">
                          <asp:BulletedList ID="BulletedListKnowsAbout" runat="server">
                          </asp:BulletedList>
                      </div>
                    </div>
            </div>
        </div>
    </div>
</asp:Content>
