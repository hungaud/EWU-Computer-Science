using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Confirmation : System.Web.UI.Page {
    private OrderInfo order;
    private List<Purchase> item;
    private string orderID = "";
    private double totalCost, totalWeight, totalShip;
    private int totalQTY;

    protected void Page_Load(object sender, EventArgs e) {
            item = new List<Purchase>();
            getFromSession();
            summaryLabel.Text = "Summary";
            orderIdLabel.Text += orderID;
            initializeTable();
            fillTable();
            shipCostLabel.Text += "$" + totalShip.ToString("F");
            totalCostLabel.Text += "$" + totalCost.ToString("F");
        if (order.Zip != 0) {

            displayShipInfo();
        }

    }

    private void initializeTable() {
        TableRow row = new TableRow();
        //TableCell cell = new TableCell();
        row.Cells.Add(addCell("Name", true));
        row.Cells.Add(addCell("ID", true));
        row.Cells.Add(addCell("Sub Price", true));
        row.Cells.Add(addCell("Quantity", true));
        row.Cells.Add(addCell("Weight", true));
        row.Cells.Add(addCell("Price", true));

        row.Font.Bold = true;
        row.HorizontalAlign = HorizontalAlign.Left;
        row.VerticalAlign = VerticalAlign.Middle;
        row.BorderStyle = BorderStyle.Groove;
        Table1.Rows.Add(row);
        //Table1.BorderStyle = BorderStyle.Double;
        //PlaceHolderTable.Controls.Add(table);
    }

    private void fillTable() {
        foreach (Purchase p in item) {
            TableRow row = new TableRow();
            row.Cells.Add(addCell(p.Name, false));
            row.Cells.Add(addCell(p.ID, false));
            double price = p.Cost;
            int qty = p.Qty;
            double subCost = price * qty;
            double weight = p.Weight;
            subCost += p.Weight * .46;
            row.Cells.Add(addCell("$" + price.ToString("F"), false));
            row.Cells.Add(addCell(qty.ToString(), false));
            row.Cells.Add(addCell(weight.ToString("F"), false));
            row.Cells.Add(addCell("$" + subCost.ToString("F"), false));
            Table1.Rows.Add(row);
        }
        total();
        Table1.BorderStyle = BorderStyle.Ridge;
    }

    private void total() {
        totalCost = 0.0;
        totalQTY = 0;
        totalWeight = 0.0;
        totalShip = 0.0;
        foreach (Purchase p in item) {
            totalQTY += p.Qty;
            totalCost += p.Cost * p.Qty;
            totalWeight += p.Weight;
        }
        totalShip = totalWeight * .46;
        totalCost += totalShip;
        TableRow row = new TableRow();
        row.Cells.Add(addCell("", false));
        row.Cells.Add(addCell("", false));
        row.Cells.Add(addCell("Total: ", false));
        row.Cells.Add(addCell("" + totalQTY, false));
        row.Cells.Add(addCell(totalWeight.ToString("F"), false));
        row.Cells.Add(addCell("$" + totalCost.ToString("F"), false));
        int size = Table1.Rows.Count;
        row.Font.Bold = true;
        row.BorderStyle = BorderStyle.Groove;

        Table1.Rows.AddAt(size, row);
        row = new TableRow();
    }

    private TableCell addCell(String pText, bool isHeader) {
        TableCell cell = new TableCell();
        cell.BorderStyle = BorderStyle.None;

        if (isHeader) {
            if (pText.Equals("Name")) {
                cell.Wrap = true;
            } else {
                cell.Wrap = false;
                cell.Width = 100;
            }
            cell.Font.Bold = true;
        }
        cell.HorizontalAlign = HorizontalAlign.Left;
        cell.Text = pText;
        return cell;
    }

    private void displayShipInfo() {
        if (this.order != null) {
            nameLabel.Text = order.Fname + " " + order.Lname;
            streetLabel.Text = order.Street;
            addressLabel.Text = order.City + ", " + order.State + " " + order.Zip;
            emailLabel.Text = order.Email;
        }
    }


    private void getFromSession() {
        if (Session["item"] != null) {
            this.item = (List<Purchase>)Session["item"];
        } else {
            item = new List<Purchase>();
        }
        if (Session["orderInfo"] != null) {
            this.order = (OrderInfo)Session["orderInfo"];
        } else {
            order = new OrderInfo();
        }
        if (Session["orderID"] != null) {
            this.orderID = (string)Session["orderID"];
        } else {
            orderID = "";
        }
    }

    private void saveSessionState() {
        Session["orderInfo"] = order;
        Session["orderID"] = orderID;
        Session["item"] = item;

    }

    private void clearSessionState() {
        Session["orderInfo"] = null;
        Session["orderID"] = null;
        Session["item"] = null;
        this.order = null;
    }

    protected void confirmButton_Click(object sender, EventArgs e) {
        if (this.order.Zip != 0) {
            string connectionPath = "Data Source=SQL5039.site4now.net;Initial Catalog=DB_A38F0D_hungaud;User Id=DB_A38F0D_hungaud_admin;Password=notthesame88;";
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            conn = new SqlConnection(connectionPath);
            try {
                conn.Open();

                string s = orderID.Substring(orderID.LastIndexOf("_") + 1);
                int count = Int32.Parse(s);
                int year = DateTime.Now.Year;
                orderID = "HEC-" + year + "_" + (count + 1);

                cmd = new SqlCommand("UPDATE OrderDB SET OrderID = @id", conn);
                cmd.Parameters.AddWithValue("@id", orderID);
                cmd.ExecuteNonQuery();
                saveSessionState();
                sendEmail();
            } catch (Exception err) {
                err.ToString();
            } finally {
                reader = null;
                cmd = null;
                if (conn != null) {
                    conn.Close();
                }
            }
        } else {
            Response.Redirect("final.aspx");
        }
    }

    private void sendEmail() {
        MailMessage mail = new MailMessage("postmaster@hungaud.com", order.Email);
        SmtpClient client = new SmtpClient();
        client.Port = 25;
        client.Host = "mail.hungaud.com";
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.Credentials = new System.Net.NetworkCredential("postmaster@hungaud.com", "$Hoopdreams24");
        client.EnableSsl = false;

        mail.Subject = "Order Confirmation";
        string s = "CSCD 379 - ASP.Net Programming with C# \n" +
                    "Your Order has been proccessed! \n\n" +
                    "Order ID: " + orderID + "\n";
           
        s += "Total Shipping Cost: $" + this.totalShip.ToString("F") + "\n" +
            "Total Order Cost: $" + this.totalCost.ToString("F");

        mail.Body = s;
        try {
            client.Send(mail);

        } catch (Exception err) {
            summaryLabel.Text = err.ToString();
        }
        clearSessionState();
        Response.Redirect("Final.aspx");
    }
}