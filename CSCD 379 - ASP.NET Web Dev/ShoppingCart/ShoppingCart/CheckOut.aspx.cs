using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class CheckOut : System.Web.UI.Page {
    private OrderInfo order;
    private string orderID;


    protected void Page_Load(object sender, EventArgs e) {
        emailInput.Attributes["type"] = "email";
        //zipInput.Attributes["type"] = "number";
        string connectionPath = "Data Source=SQL5039.site4now.net;Initial Catalog=DB_A38F0D_hungaud;User Id=DB_A38F0D_hungaud_admin;Password=notthesame88;";
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
        conn = new SqlConnection(connectionPath);
        try {
            conn.Open();
            cmd = new SqlCommand("SELECT * FROM OrderDB;", conn);
            using(reader = cmd.ExecuteReader()) {
                if(reader.Read()) {
                    string s = reader["OrderID"].ToString();
                    s = s.Substring(s.LastIndexOf("_") + 1);
                    int count = Int32.Parse(s);
                    int year = DateTime.Now.Year;
                    orderID = "HEC-" + year + "_" + count;
                    OrderNumLabel.Text += orderID;
                    saveSessionState();
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

    protected void continuePayButton_Click(object sender, EventArgs e) {
        string fname, lname, street, city, state, email;
        int zip;
        fname = firstNameInput.Value;
        lname = lastNameInput.Value;
        street = streetInput.Value;
        city = cityInput.Value;
        state = dropdownStates.Text;
        zip = Int32.Parse(zipInput.Value);
        //zip = zipInput.Value;
        email = emailInput.Value;
        order = new OrderInfo(fname, lname, street, city, state, zip, email);
        saveSessionState();
        Response.Redirect("Confirmation.aspx");
    }

    private void saveSessionState() {
        Session["orderInfo"] = order;
        Session["orderID"] = orderID;
    }

}