using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page 
{
    private SimplexField field = new SimplexField(5);

    protected void Page_Load(object sender, EventArgs e)
    {

        //if (!IsPostBack)
        {
            Row[] rows = new Row[2];
            rows[0] = new Row(new double[] { 1, 2, 3, 4, 5 });
            rows[1] = new Row(new double[] { 6, 7, 8, 9, 10 });
            rows[1] = new Row(new double[] { 11, 12, 13, 14, 15 });

            foreach (Row row in rows)
            {
                this.field.AddRow(row);
            }
        }

        string state = Application["state"] as string;
       
        switch (state)
        {
            case "phase3":
                this.MultiView1.SetActiveView(this.View3);
                break;
            case "phase2":
                this.MultiView1.SetActiveView(this.View2);
                break;
            case "start":
            default:
                Application["state"] = "start";
                this.MultiView1.SetActiveView(this.View1);
                break;
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        Row row = new Row(new double[] { 9, 9, 9, 9, 9 });
        HtmlBuilder htmlBuilder;
        
        if (Application["field"] == null)
            Application.Add("field", this.field);


        this.field = (SimplexField)Application.Get("field");
        this.field.AddRow(row);
        this.field.PivotColumn = Convert.ToInt32(this.PivotColumn.Text);
        this.field.PivotRow = Convert.ToInt32(this.PivotRow.Text);

        htmlBuilder = new HtmlBuilder(this.field);
        htmlBuilder.ShowColumnHeader = true;
        htmlBuilder.ShowRowHeader = true;
        htmlBuilder.ForeColor = Color.Orange;
        Table table = htmlBuilder.GetTable();

        this.Panel1.Controls.Add(table);

        Application["field"] = this.field;
        Application["state"] = "phase3";
        
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (this.RadioButtonList1.SelectedValue)
        {
            case "3":
                this.MultiView1.SetActiveView(this.View3);
                break;
            case "2":
                this.MultiView1.SetActiveView(this.View2);
                break;
            case "1":
            default:
                this.MultiView1.SetActiveView(this.View1);
                break;
        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Application["state"] = "phase2";
        
        int x = Convert.ToInt32(this.VariablesTextBox.Text);
        int y = Convert.ToInt32(this.BaseVarsTextBox.Text);


        Table table = new Table();
        
        for (int i = 0; i < y; i++)
        {

            TableRow trow = new TableRow();

            
            for (int i2 = 0; i2 < x; i2++)
            {
                TableCell cell = new TableCell();
                Label label = new Label();
                label.Text = "x" + i.ToString();
                cell.Controls.Add(new TextBox());
                cell.Controls.Add(label);

                trow.Cells.Add(cell);
            }

            TableCell cell1 = new TableCell();
            Label label1 = new Label();
            label1.Text = " = ";
            
            cell1.Controls.Add(label1);
            TextBox box = new TextBox();
            box.Width = 10;
            cell1.Controls.Add(new TextBox());
            trow.Cells.Add(cell1);

            
            table.Rows.Add(trow);
        }

        this.View2.Controls.Add(table);
    
        
     }
}
