<%@ Page Title="" Language="C#" MasterPageFile="./MasterPageItem.master" AutoEventWireup="true" CodeFile="CheckOut.aspx.cs" Inherits="CheckOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderProductName" Runat="Server">
    <div class="col-lg-7">

        <div class="card mt-3">

            <div class="card-body" style ="text-align:center"?>
                <h1 class="my-4">
                    <asp:Label ID="OrderNumLabel" runat="server" Text="Order ID: "></asp:Label>
                </h1>
            </div>
            <div class="card-body" style ="text-align:left"?>
                <form id="form1" runat="server">
                    First Name:
                    <br />
                    <input type = "text" id="firstNameInput" autofocus="autofocus" required = "required" runat="server" />
                    <br />
                    <br />
                    Last Name:
                    <br />
                    <input type = "text" id="lastNameInput" autofocus="autofocus" required = "required" runat="server" />
                    <br />
                    <br />
                    Street:
                    <br />
                    <input type = "text" id="streetInput" autofocus="autofocus" required = "required" runat="server" />
                    <br />
                    <br />
                    City:
                    <br />
                    <input type = "text" id="cityInput" autofocus="autofocus" required = "required" runat="server" />
                    <br />
                    <br />
                    State:
                    <br />
                    <asp:DropDownList ID="dropdownStates" runat="server" Width="100%" Height="40px">
                        <asp:ListItem Value="AL">Alabama</asp:ListItem>
	                    <asp:ListItem Value="AK">Alaska</asp:ListItem>
	                    <asp:ListItem Value="AZ">Arizona</asp:ListItem>
	                    <asp:ListItem Value="AR">Arkansas</asp:ListItem>
	                    <asp:ListItem Value="CA">California</asp:ListItem>
	                    <asp:ListItem Value="CO">Colorado</asp:ListItem>
	                    <asp:ListItem Value="CT">Connecticut</asp:ListItem>
	                    <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
	                    <asp:ListItem Value="DE">Delaware</asp:ListItem>
	                    <asp:ListItem Value="FL">Florida</asp:ListItem>
	                    <asp:ListItem Value="GA">Georgia</asp:ListItem>
	                    <asp:ListItem Value="HI">Hawaii</asp:ListItem>
	                    <asp:ListItem Value="ID">Idaho</asp:ListItem>
	                    <asp:ListItem Value="IL">Illinois</asp:ListItem>
	                    <asp:ListItem Value="IN">Indiana</asp:ListItem>
	                    <asp:ListItem Value="IA">Iowa</asp:ListItem>
	                    <asp:ListItem Value="KS">Kansas</asp:ListItem>
	                    <asp:ListItem Value="KY">Kentucky</asp:ListItem>
	                    <asp:ListItem Value="LA">Louisiana</asp:ListItem>
	                    <asp:ListItem Value="ME">Maine</asp:ListItem>
	                    <asp:ListItem Value="MD">Maryland</asp:ListItem>
	                    <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
	                    <asp:ListItem Value="MI">Michigan</asp:ListItem>
	                    <asp:ListItem Value="MN">Minnesota</asp:ListItem>
	                    <asp:ListItem Value="MS">Mississippi</asp:ListItem>
	                    <asp:ListItem Value="MO">Missouri</asp:ListItem>
	                    <asp:ListItem Value="MT">Montana</asp:ListItem>
	                    <asp:ListItem Value="NE">Nebraska</asp:ListItem>
	                    <asp:ListItem Value="NV">Nevada</asp:ListItem>
	                    <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
	                    <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
	                    <asp:ListItem Value="NM">New Mexico</asp:ListItem>
	                    <asp:ListItem Value="NY">New York</asp:ListItem>
	                    <asp:ListItem Value="NC">North Carolina</asp:ListItem>
	                    <asp:ListItem Value="ND">North Dakota</asp:ListItem>
	                    <asp:ListItem Value="OH">Ohio</asp:ListItem>
	                    <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
	                    <asp:ListItem Value="OR">Oregon</asp:ListItem>
	                    <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
	                    <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
	                    <asp:ListItem Value="SC">South Carolina</asp:ListItem>
	                    <asp:ListItem Value="SD">South Dakota</asp:ListItem>
	                    <asp:ListItem Value="TN">Tennessee</asp:ListItem>
	                    <asp:ListItem Value="TX">Texas</asp:ListItem>
	                    <asp:ListItem Value="UT">Utah</asp:ListItem>
	                    <asp:ListItem Value="VT">Vermont</asp:ListItem>
	                    <asp:ListItem Value="VA">Virginia</asp:ListItem>
	                    <asp:ListItem Value="WA">Washington</asp:ListItem>
	                    <asp:ListItem Value="WV">West Virginia</asp:ListItem>
	                    <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
	                    <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    Zip:
                    <br />
                    <input type = "text" id="zipInput" autofocus="autofocus" required = "required" runat="server" />
                    <br />
                    <br />
                    Email:
                    <br />
                    <input type ="text" id="emailInput" placeholder="Enter your email address" required = "required" runat="server"  multiple="multiple" />
                    <br />
                    <br />
                        
                    <asp:Button ID="continuePayButton" runat="server" Text="Continue" Width="100%" Height="40" OnClick="continuePayButton_Click" />
                       
                    <style>
                        input[type=email] {
                            width: 100%;
                            height:40px;
                            box-sizing: border-box;
                        }
                        input[type=text] {
                            width: 100%;
                            height:40px;
                            box-sizing: border-box;
                        }
                    </style>

                </form>
            </div>
        </div>
    </div>
</asp:Content>

