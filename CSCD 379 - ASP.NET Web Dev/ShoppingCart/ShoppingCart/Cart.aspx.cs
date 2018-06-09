using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart : System.Web.UI.Page {

    List<Purchase> item = new List<Purchase>();
    Table table;

    protected void Page_Load(object sender, EventArgs e) {
        item = new List<Purchase>();
        table = new Table();
        initializeTable();
        if (Session["item"] != null) {
            getSessionSate();
            //PlaceHolderTable.Controls.Add(new LiteralControl(item[0].ID.ToString()));

            // name id price qty subcost action

            fillTable();
        } else {
            total();
        }
        
        //Table table = new Table();
        //TableRow row = table.Rows[1];
        //string n = row.Cells[3].ToString();
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
        row.Cells.Add(addCell("Action", true));
        row.Cells.Add(addCell("", true));

        row.Font.Bold = true;
        row.HorizontalAlign = HorizontalAlign.Left;
        row.VerticalAlign = VerticalAlign.Middle;
        row.BorderStyle = BorderStyle.Groove;
        Table1.Rows.Add(row);
        //Table1.BorderStyle = BorderStyle.Double;
        //PlaceHolderTable.Controls.Add(table);
    }


    private TableCell addCell(String pText, bool isHeader) {
        TableCell cell = new TableCell();
        cell.BorderStyle = BorderStyle.None;
        
        if(isHeader) {
            if(pText.Equals("Name")) {
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

    private void saveSessionState() {
        Session["item"] = this.item;
    }
    private void getSessionSate() {
        this.item = (List<Purchase>)Session["item"];
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

            row.Cells.Add(addCell("$" + price.ToString("F"), false));
            row.Cells.Add(addCell(qty.ToString(), false));
            row.Cells.Add(addCell(weight.ToString("F"), false));
            row.Cells.Add(addCell("$" + subCost.ToString("F"), false));

            Button button = createButton("add_" + p.ID, "Add More");
            button.Click += new EventHandler(buttonAddMore_Click);
            TableCell cell = new TableCell();
            cell.HorizontalAlign = HorizontalAlign.Left;
            cell.Controls.Add(button);
            row.Cells.Add(cell);

            button = createButton(p.ID, "Remove Item");
            button.Click += new EventHandler(buttonRemove_Click);
            cell = new TableCell();
            cell.HorizontalAlign = HorizontalAlign.Left;
            cell.Controls.Add(button);
            row.Cells.Add(cell);
            Table1.Rows.Add(row);

        }
        total();
        Table1.BorderStyle = BorderStyle.Ridge;

    }

    private void total() {
        double totalCost = 0.0;
        int totalQTY = 0;
        double totalWeight = 0.0;
        foreach (Purchase p in item) {
            totalQTY += p.Qty;
            totalCost += p.Cost * p.Qty;
            totalWeight += p.Weight;
        }
        totalCost += totalWeight * .46;
        TableRow row = new TableRow();
        row.Cells.Add(addCell("", false));
        row.Cells.Add(addCell("", false));
        row.Cells.Add(addCell("Total: ", false));
        row.Cells.Add(addCell("" + totalQTY, false));
        row.Cells.Add(addCell(totalWeight.ToString("F"), false));
        row.Cells.Add(addCell("$" + totalCost.ToString("F"), false));
        int size = Table1.Rows.Count;
        row.Font.Bold = true;
        row.Cells.Add(addCell("Shipping Included", false));
        row.Cells.Add(addCell("", false));

        row.BorderStyle = BorderStyle.Groove;

        Table1.Rows.AddAt(size, row);
        row = new TableRow();

        Button button = createButton("ButtonContinue", "Continue Shopping");
        button.Click += new EventHandler(buttonContinue_Click);
        TableCell cell = new TableCell();
        cell.Controls.Add(button);
        row.Cells.Add(cell);

        button = createButton("buttonCheckOut", "Check Out");
        button.Click += new EventHandler(buttonCheckOut_Click);
        cell = new TableCell();
        cell.Controls.Add(button);
        row.Cells.Add(cell);
        Table2.Rows.Add(row);
        Table2.HorizontalAlign = HorizontalAlign.Right;
    }

    private Button createButton(string id, string text) {
        Button button = new Button();
        button.ID = id;
        button.Text = text;
        button.Attributes.Add("runat", "server");
        return button;
    }

    private void buttonContinue_Click(object sender, EventArgs e) {
        Button button = sender as Button;
        saveSessionState();
        Response.Redirect("Default.aspx");
    }

    protected void buttonRemove_Click(object sender, EventArgs e) {
        Button button = sender as Button;
        string buttonID = button.ID;
        for (int i = 0; i < this.item.Count; i++) {
            if (item[i].ID.Equals(buttonID)) {
                item.RemoveAt(i);
            }
        }
        saveSessionState();
        Response.Redirect("Cart.aspx");
    }

    protected void buttonCheckOut_Click(object sender, EventArgs e) {
        Button button = sender as Button;
        if (item.Count > 0) {
            saveSessionState();
            //if (Session["orderID"] != null) {
            //    Response.Redirect("Confirmation.aspx");
            //} else {
            Response.Redirect("CheckOut.aspx");
            //}
        } else {
            cartErrorLabel.Text = "Cart is Empty!";
        }
    }

    protected void buttonAddMore_Click(object sender, EventArgs e) {
        Button button = sender as Button;
        string buttonID = button.ID;
        string itemID = buttonID.Substring(buttonID.LastIndexOf("_") + 1);
        saveSessionState();
        Response.Redirect("ItemPage.aspx?ID=" + itemID);
    }
}

  
