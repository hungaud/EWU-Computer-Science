<%@ Page Title="" Language="C#" MasterPageFile="MasterPageItem.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderProductName" Runat="Server">
    <div class="col-lg-9">

        <div class="card-BODY"" >
            <div class="card-body" style ="text-align:center">
                <div class="card-body" style ="text-align:center">
                    <div class="card-body" style ="text-align:center">
                        <form runat="server">
                        <asp:Table ID="Table1" runat="server" CellPadding="10" CellSpacing="1">
                       
                        </asp:Table>
                            <br />
                        <asp:Table ID="Table2" runat="server" CellPadding="10" CellSpacing="1">
                        </asp:Table>

                        </form>
                    </div>
                </div>
                <h3>
                    <asp:Label ID="cartErrorLabel" runat="server" Text="" ForeColor="Red" Font-Italic="True"></asp:Label>
                </h3>
            </div>

        </div>
    </div>
</asp:Content>

