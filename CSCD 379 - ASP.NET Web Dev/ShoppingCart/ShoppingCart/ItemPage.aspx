<%@ Page Title="" Language="C#" MasterPageFile="./MasterPageItem.master" AutoEventWireup="true" CodeFile="ItemPage.aspx.cs" Inherits="ItemPage" %>

<%-- Add content controls here --%>

        <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderProductName" runat="server">
            <div class="col-lg-8">

                <div class="card mt-4">
                    <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
                <div class="card-body" style ="text-align:center"?>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </div>
                <div class="card-body">
              
                   <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                   <div class="card-body" style ="text-align:center"?>
                        <span class="text-warning">&#9733; &#9733; &#9733; &#9733; &#9734;</span>
                        <br />
                        4.0 stars
                   </div>
                   <div class="" style ="text-align:center"?>
                       <form runat="server">
                           <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>

                           Quantity: 
                           &nbsp;
                           <asp:DropDownList ID="dropDownListQTY" runat="server">
                               <asp:ListItem Value="1"></asp:ListItem>
                               <asp:ListItem Value="2"></asp:ListItem>
                               <asp:ListItem Value="3"></asp:ListItem>
                               <asp:ListItem Value="4"></asp:ListItem>
                           </asp:DropDownList>
                      
                           &nbsp;&nbsp;
                       
                      
                           <asp:Button ID="addCartButton" runat="server" Text="Add to Cart" BorderWidth="1px" CssClass="btn" OnClick="addCartButton_Click" />
                           <br />
                           <br />
                           <br />
                           <br />



                       </form>
                   </div>
               
                </div>
              </div>
            </div>
        </asp:Content>





