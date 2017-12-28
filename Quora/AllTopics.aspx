<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="AllTopics.aspx.cs" Inherits="Quora.AllTopics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:85px;>
  <div class="row">
      <button type="button" class="btn btn-primary" data-toggle="modal" data-target=".bd-example-modal-lg">Add Topic</button>
                    
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
    <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
           <div class="modal-body">
               <asp:TextBox ID="TextBoxTopic" runat="server" class="form-control" placeholder="Topic" autofocus=""></asp:TextBox>
               <hr />
               <asp:TextBox ID="TextBoxDescription" runat="server" class="form-control" placeholder="Description" Height="200px"></asp:TextBox>
            </div>
            <div class="modal-footer">
                <asp:Button ID="ButtonAddTopic" runat="server" Text="Add Topic" type="button" class="btn btn-primary" OnClick="ButtonAddTopic_Click"/>
            </div>
         </div>
      </div>
    </div>
</asp:Content>
