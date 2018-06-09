using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class _Default : System.Web.UI.Page {

    private List<Purchase> orders;
    protected void Page_UnLoad(object sender, EventArgs e) {
        string s = "Hello";
    }

    protected void Page_Load(object sender, EventArgs e) {
        //this.Controls.con
        //PlaceHolderBasicDescription.Controls.Add(new LiteralControl("<p class=\"card-text\">Lorem ipsum dolor sit amet, consectetur adipisicing elit.Amet numquam aspernatur!</p>"));

        //addPlaceHolderList();

        orders = new List<Purchase>();

        string connectionPath = "Data Source=SQL5039.site4now.net;Initial Catalog=DB_A38F0D_hungaud;User Id=DB_A38F0D_hungaud_admin;Password=notthesame88;";
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
        conn = new SqlConnection(connectionPath);
        
        try {
            conn.Open();
            cmd = new SqlCommand("SELECT * FROM Shop;", conn);
            using (reader = cmd.ExecuteReader()) {
                int n = 0;
                while (reader.Read()) {
                    int id = Int32.Parse(reader["ID"].ToString());
                    string link = "ItemPage.aspx?ID=" + id;
                    string name = "<a href=\"" + link + "\">" + reader["Name"].ToString() + "</a>";

                    double price = 0.0;
                    string cost = "";
                    if (Double.TryParse(reader["Cost"].ToString(), out price)) {
                       cost = price.ToString("F");
                    } 
                    cost = "<h5> $" + cost + "</h5>";
                    string desc = "<p class=\"card-text\">" + reader["Basic Description"] + " </p>";
                    if (n == 0) inputBasic(name, cost, desc, link);
                    else if (n == 1) inputPremium(name, cost, desc, link);
                    else if (n == 2) inputExecutive(name, cost, desc, link);
                    else if (n == 3) inputOne(name, cost, desc, link);
                    else if (n == 4) inputTwo(name, cost, desc, link);
                    else if (n == 5) inputThree(name, cost, desc, link);
                    n++;
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

    protected void Page_PreRender(object sender, EventArgs e) {
        Session["package"] = this.orders;
    }

    public List<Purchase> getOrders() {
        return this.orders;
    }

    private void inputBasic(string name, string cost, string desc, string link) {
        PlaceHolderName1.Controls.Add(new LiteralControl(name));
        PlaceHolderCost1.Controls.Add(new LiteralControl(cost));
        PlaceHolderDesc1.Controls.Add(new LiteralControl(desc));
        string temp = "./resources/itemPicture/basicicon.jpg";
        string img = "<a href=\"" + link + "\"><img class=\"card-img-top\" src=\"" + temp + "\" alt=\"\"></a>";
        PlaceHolderImg1.Controls.Add(new LiteralControl(img));
    }

    private void inputPremium(string name, string cost, string desc, string link) {
        PlaceHolderName2.Controls.Add(new LiteralControl(name));
        PlaceHolderCost2.Controls.Add(new LiteralControl(cost));
        PlaceHolderDesc2.Controls.Add(new LiteralControl(desc));
        string temp = "./resources/itemPicture/cheericon.jpg";
        string img = "<a href=\"" + link + "\"><img class=\"card-img-top\" src=\"" + temp + "\" alt=\"\"></a>";
        PlaceHolderImg2.Controls.Add(new LiteralControl(img));
    }

    private void inputExecutive(string name, string cost, string desc, string link) {
        PlaceHolderName3.Controls.Add(new LiteralControl(name));
        PlaceHolderCost3.Controls.Add(new LiteralControl(cost));
        PlaceHolderDesc3.Controls.Add(new LiteralControl(desc));
        string temp = "./resources/itemPicture/bushidoicon.jpg";
        string img = "<a href=\"" + link + "\"><img class=\"card-img-top\" src=\"" + temp + "\" alt=\"\"></a>";
        PlaceHolderImg3.Controls.Add(new LiteralControl(img));
    }
    private void inputOne(string name, string cost, string desc, string link) {
        PlaceHolderName4.Controls.Add(new LiteralControl(name));
        PlaceHolderCost4.Controls.Add(new LiteralControl(cost));
        PlaceHolderDesc4.Controls.Add(new LiteralControl(desc));
        string temp = "./resources/itemPicture/watericon.jpg";
        string img = "<a href=\"" + link + "\"><img class=\"card-img-top\" src=\"" + temp + "\" alt=\"\"></a>";
        PlaceHolderImg4.Controls.Add(new LiteralControl(img));
    }


    private void inputTwo(string name, string cost, string desc, string link) {
        PlaceHolderName5.Controls.Add(new LiteralControl(name));
        PlaceHolderCost5.Controls.Add(new LiteralControl(cost));
        PlaceHolderDesc5.Controls.Add(new LiteralControl(desc));
        string temp = "./resources/itemPicture/picicon.jpg";
        string img = "<a href=\"" + link + "\"><img class=\"card-img-top\" src=\"" + temp + "\" alt=\"\"></a>";
        PlaceHolderImg5.Controls.Add(new LiteralControl(img));
    }
    private void inputThree(string name, string cost, string desc, string link) {
        PlaceHolderName6.Controls.Add(new LiteralControl(name));
        PlaceHolderCost6.Controls.Add(new LiteralControl(cost));
        PlaceHolderDesc6.Controls.Add(new LiteralControl(desc));
        string temp = "./resources/itemPicture/specialicon.jpg";
        string img = "<a href=\"" + link + "\"><img class=\"card-img-top\" src=\"" + temp + "\" alt=\"\"></a>";
        PlaceHolderImg6.Controls.Add(new LiteralControl(img));
    }


}



//PlaceHolder1.Controls.Add(new LiteralControl("<a href=\"#\"><img class=\"card-img-top\" src=\"http://placehold.it/700x400\" alt=\"\"></a>"));
// img <a href="#"><img class="card-img-top" src="http://placehold.it/700x400" alt=""></a>
// desc <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!</p>
// price                   <h5>$24.99</h5>
// name                     <a href="#">Item Six</a>

