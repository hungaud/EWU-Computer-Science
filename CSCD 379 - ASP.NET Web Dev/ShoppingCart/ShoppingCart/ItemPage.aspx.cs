using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ItemPage : System.Web.UI.Page {

    private List<Purchase> item;
    private Table tbl;
    private string cartName = "";
    private int cartID = 0, cartQTY = 0;
    private double cartPrice = 0.0, weightPerItem;
    private string id = "";

    protected void Page_Load(object sender, EventArgs e) {

        id = Request.QueryString["ID"];

        if (Session["item"] == null) {
            item = new List<Purchase>();
        } else {
            getSessionSate();
        }
        string connectionPath = "Data Source=SQL5039.site4now.net;Initial Catalog=DB_A38F0D_hungaud;User Id=DB_A38F0D_hungaud_admin;Password=notthesame88;";
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
        conn = new SqlConnection(connectionPath);
        try {
            conn.Open();
            cmd = new SqlCommand("SELECT * FROM Shop WHERE ID = " + id, conn);
            using(reader = cmd.ExecuteReader()) {
                if(reader.Read()) {
                    cartName = reader["Name"].ToString();
                    //            <img class="card-img-top img-fluid" src="http://placehold.it/900x400" alt="">
                    
                    string img = "<img class=\"card-img-top img-fluid\" src=\"" + reader["URL Full"].ToString() + "\" alt=\"\">";
                    string name = "<h2>" + cartName + "</h2>";
                    string desc = reader["Full Description"].ToString();
                    double price = 0.0;
                    string cost = "$";

                    if (Double.TryParse(reader["Cost"].ToString(), out price)) {
                        cartPrice = price;
                        cost = "<h5>" + cost + price.ToString("F") + "</h5>";
                    }
                    weightPerItem = Double.Parse(reader["Weight"].ToString());
                    PlaceHolder1.Controls.Add(new LiteralControl(name));
                    PlaceHolder2.Controls.Add(new LiteralControl(desc));
                    PlaceHolder3.Controls.Add(new LiteralControl(cost));
                    PlaceHolder4.Controls.Add(new LiteralControl(img));
                }
            }


        } catch (Exception err) {
            err.ToString();
        } finally {
            reader = null;
            cmd = null;
            if (conn != null) {
                conn.Close();
            }
        }
    }

    private void saveSessionState() {
        Session["item"] = item;
    }

    private void getSessionSate() {
        this.item = (List<Purchase>)Session["item"];
    }

    protected void addCartButton_Click(object sender, EventArgs e) {
        bool found = false;
        cartQTY = Int32.Parse(dropDownListQTY.SelectedValue);
        foreach (Purchase pur in item) {
            if(pur.ID.Equals(this.id)) {
                found = true;
                pur.Qty += cartQTY;
                pur.Weight = pur.Qty * weightPerItem;
            }
        }
        if(!found) {
            Purchase p = new Purchase(this.id, this.cartName, this.cartPrice, cartQTY, cartQTY * weightPerItem);
            item.Add(p);
        }
        saveSessionState();
        Response.Redirect("Cart.aspx");
    }
}

// button for session state here. look up how to implement session state.

// name <h3 class=\"card-title\">Product Name Worked</h3>"
// description <p class="card-text"> description here </p>
// price               <h4>$24.99</h4>

