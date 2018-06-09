<%@ Page Title="" Language="C#" MasterPageFile="MasterPageItem.master" AutoEventWireup="true" CodeFile="Confirmation.aspx.cs" Inherits="Confirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderProductName" Runat="Server">
    <div class="col-lg-7">

        <div class="card-BODY"" >
            <div class="card-body" style ="text-align:center">
                <div class="card-body" style ="text-align:center">
                    <div class="card-body" style ="text-align:left">
                            <h1><asp:Label ID="summaryLabel" runat="server" Text="Order ID: "></asp:Label></h1>
                            <h4 class="my-4">
                                <asp:Label ID="orderIdLabel" runat="server" Text="Order ID: "></asp:Label>
                            </h4>
                        
                        <form runat="server">
                            <asp:Table ID="Table1" runat="server" CellPadding="10" CellSpacing="1"> </asp:Table>
                            <h4>
                                <asp:Label ID="shipCostLabel" runat="server" Text="Shipping Cost: &nbsp;&nbsp;&nbsp "></asp:Label>
                                <br />
                                <asp:Label ID="totalCostLabel" runat="server" Text="Total: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; "></asp:Label>
                            </h4>
                        <br />
                        <br />
                        <h1>Shipping Information</h1>
                        <br />
                        <h4>
                            <asp:Label ID="nameLabel" runat="server" Text=""></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="streetLabel" runat="server" Text=""></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="addressLabel" runat="server" Text=""></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="emailLabel" runat="server" Text=""></asp:Label>
                            <br />
                            <br />
                        </h4>
                        <asp:Button ID="confirmButton" runat="server" Text="Confirm Order" Width="100%" OnClick="confirmButton_Click" Height="40px" />
                                                    </form>

                    </div>
                </div>
            </div>

        </div>
    </div>



</asp:Content>

