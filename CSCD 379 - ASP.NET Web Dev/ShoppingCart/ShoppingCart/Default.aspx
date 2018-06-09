<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%-- Add content controls here --%>

    
        <%-- basic entourage --%>
        <asp:Content ID ="Content1" ContentPlaceHolderID ="ContentPlaceHolderBasic" runat="server">
            <div class="col-lg-4 col-md-6 mb-4">
              <div class="card h-100">
                <asp:PlaceHolder ID="PlaceHolderImg1" runat="server"></asp:PlaceHolder>
                <div class="card-body"style ="background-color:aliceblue">
                  <h4 class="card-title">
                    <asp:PlaceHolder ID="PlaceHolderName1" runat="server"></asp:PlaceHolder>
                  </h4>
                  <h5><asp:PlaceHolder ID="PlaceHolderCost1" runat="server"></asp:PlaceHolder></h5>
                  <asp:PlaceHolder ID="PlaceHolderDesc1" runat="server"></asp:PlaceHolder>
                </div>
                <div class="card-footer">
                  <small class="text-muted">&#9733; &#9733; &#9733; &#9733; &#9734;</small>
                </div>
              </div>
            </div>
        </asp:Content>       

        <%-- premium entourage --%>
        <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPremium" runat="server">
            <div class="col-lg-4 col-md-6 mb-4">
              <div class="card h-100">
                <asp:PlaceHolder ID="PlaceHolderImg2" runat="server"></asp:PlaceHolder>
                <div class="card-body"style ="background-color:aliceblue">
                  <h4 class="card-title">
                    <asp:PlaceHolder ID="PlaceHolderName2" runat="server"></asp:PlaceHolder>
                  </h4>
                  <h5><asp:PlaceHolder ID="PlaceHolderCost2" runat="server"></asp:PlaceHolder></h5>
                  <asp:PlaceHolder ID="PlaceHolderDesc2" runat="server"></asp:PlaceHolder>
                </div>
                <div class="card-footer">
                  <small class="text-muted">&#9733; &#9733; &#9733; &#9733; &#9734;</small>
                </div>
              </div>
            </div>
        </asp:Content>

        <%-- executive entourage --%>
        <asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderExecutive" runat="server">
            <div class="col-lg-4 col-md-6 mb-4">
              <div class="card h-100">
                <asp:PlaceHolder ID="PlaceHolderImg3" runat="server"></asp:PlaceHolder>
                <div class="card-body"style ="background-color:aliceblue">
                  <h4 class="card-title">
                    <asp:PlaceHolder ID="PlaceHolderName3" runat="server"></asp:PlaceHolder>
                  </h4>
                  <h5><asp:PlaceHolder ID="PlaceHolderCost3" runat="server"></asp:PlaceHolder></h5>
                  <asp:PlaceHolder ID="PlaceHolderDesc3" runat="server"></asp:PlaceHolder>
                </div>
                <div class="card-footer">
                  <small class="text-muted">&#9733; &#9733; &#9733; &#9733; &#9734;</small>
                </div>
              </div>
            </div>
        </asp:Content>

        <%-- add on water --%>
        <asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderAddOn1" runat="server">
            <div class="col-lg-4 col-md-6 mb-4">
              <div class="card h-100">
                <asp:PlaceHolder ID="PlaceHolderImg4" runat="server"></asp:PlaceHolder>
                <div class="card-body"style ="background-color:aliceblue">
                  <h4 class="card-title">
                    <asp:PlaceHolder ID="PlaceHolderName4" runat="server"></asp:PlaceHolder>
                  </h4>
                  <h5><asp:PlaceHolder ID="PlaceHolderCost4" runat="server"></asp:PlaceHolder></h5>
                  <asp:PlaceHolder ID="PlaceHolderDesc4" runat="server"></asp:PlaceHolder>
                </div>
                <div class="card-footer">
                  <small class="text-muted">&#9733; &#9733; &#9733; &#9733; &#9734;</small>
                </div>
              </div>
            </div>
        </asp:Content>

        <%-- add on pictures --%>
        <asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderAddOn2" runat="server">
            <div class="col-lg-4 col-md-6 mb-4">
              <div class="card h-100">
                <asp:PlaceHolder ID="PlaceHolderImg5" runat="server"></asp:PlaceHolder>
                <div class="card-body"style ="background-color:aliceblue">
                  <h4 class="card-title">
                    <asp:PlaceHolder ID="PlaceHolderName5" runat="server"></asp:PlaceHolder>
                  </h4>
                  <h5><asp:PlaceHolder ID="PlaceHolderCost5" runat="server"></asp:PlaceHolder></h5>
                  <asp:PlaceHolder ID="PlaceHolderDesc5" runat="server"></asp:PlaceHolder>
                </div>
                <div class="card-footer">
                  <small class="text-muted">&#9733; &#9733; &#9733; &#9733; &#9734;</small>
                </div>
              </div>
            </div>
        </asp:Content>

        <%-- add on stealing --%>
        <asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderAddOn3" runat="server">
            <div class="col-lg-4 col-md-6 mb-4">
              <div class="card h-100">
                <asp:PlaceHolder ID="PlaceHolderImg6" runat="server"></asp:PlaceHolder>
                <div class="card-body"style ="background-color:aliceblue">
                  <h4 class="card-title">
                    <asp:PlaceHolder ID="PlaceHolderName6" runat="server"></asp:PlaceHolder>
                  </h4>
                  <h5><asp:PlaceHolder ID="PlaceHolderCost6" runat="server"></asp:PlaceHolder></h5>
                  <asp:PlaceHolder ID="PlaceHolderDesc6" runat="server"></asp:PlaceHolder>
                </div>
                <div class="card-footer">
                  <small class="text-muted">&#9733; &#9733; &#9733; &#9733; &#9734;</small>
                </div>
              </div>
            </div>
        </asp:Content>
