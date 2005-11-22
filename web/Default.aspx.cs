using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    private SimplexField field;
    private TextBox[,] VarTextBoxes;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["state"] == null)
        {
            Session["state"] = "start";
            this.MultiView1.SetActiveView(this.View1);
        }
        if (this.VarTextBoxes != null)
        {
            int count = this.VarTextBoxes.Length;
        }
    }

    private void GenerateField()
    {
        //this.field = new SimplexField(5);
        //Row[] rows = new Row[3];
        //rows[0] = new Row(new double[] { 1, 2, 3, 4, 5 });
        //rows[1] = new Row(new double[] { 6, 7, 8, 9, 10 });
        //rows[2] = new Row(new double[] { 11, 12, 13, 14, 15 });

        //foreach (Row row in rows)
        //{
        //    this.field.AddRow(row);
        //}


        
        int columns = this.VarTextBoxes.Length;
       

        this.field = new SimplexField(columns);
        Row[] rows = new Row[3];
        rows[0] = new Row(new double[] {1, 2, 3, 4, 5});
        rows[1] = new Row(new double[] {6, 7, 8, 9, 10});
        rows[2] = new Row(new double[] {11, 12, 13, 14, 15});

        foreach (Row row in rows)
        {
            this.field.AddRow(row);
        }
    }

    private void ShowView()
    {
        string state = Session["state"] as string;

        switch (state)
        {
            case "phase3":
                this.GenerateField();
                this.DrawField();
                this.MultiView1.SetActiveView(this.View3);
                break;
            case "phase2":
                this.MultiView1.SetActiveView(this.View2);
                break;
            case "start":
            case null:
            default:
                Application["state"] = "start";
                this.MultiView1.SetActiveView(this.View1);
                break;
        }
    }

    private void DrawField()
    {
        HtmlBuilder htmlBuilder;

        if (Session["field"] == null)
            Session.Add("field", this.field);


        this.field = (SimplexField) Session["field"];


        this.field.PivotColumn = Convert.ToInt32(this.PivotColumn.Text);
        this.field.PivotRow = Convert.ToInt32(this.PivotRow.Text);

        htmlBuilder = new HtmlBuilder(this.field);
        htmlBuilder.ShowColumnHeader = true;
        htmlBuilder.ShowRowHeader = true;
        htmlBuilder.ForeColor = Color.Orange;
        Table table = htmlBuilder.GetTable();

        this.Panel1.Controls.Add(table);

        Session["field"] = this.field;
    }

    protected void GenerateTextboxes(object sender, EventArgs e)
    {
        Session["state"] = "phase2";

        int x = Convert.ToInt32(this.VariablesTextBox.Text);
        int y = Convert.ToInt32(this.BaseVarsTextBox.Text);

        VarTextBoxes = new TextBox[x + 1,y + 1];

        Table table = new Table();

        for (int i = 0; i < y + 1; i++)
        {
            TableRow trow = new TableRow();


            for (int i2 = 0; i2 < x + 1; i2++)
            {
                TableCell cell = new TableCell();
                Label label = new Label();


                VarTextBoxes[i2, i] = new TextBox();
                VarTextBoxes[i2, i].Width = 30;
                VarTextBoxes[i2, i].ID = "var[" + i2.ToString() + "," + i.ToString() + "]";


                if (i2 == x)
                {
                    label.Text = " = ";
                    cell.Controls.Add(label);
                }

                cell.Controls.Add(VarTextBoxes[i2, i]);

                if (i2 < x)
                {
                    label.Text = "x" + (i2 + 1).ToString();
                    cell.Controls.Add(label);
                }

                trow.Cells.Add(cell);
            }

            table.Rows.Add(trow);
        }

        this.View2.Controls.Add(table);
        this.ShowView();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Session["state"] = "phase3";
        int count = this.VarTextBoxes.Length;
        this.ShowView();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Session["state"] = null;
        //  this.ShowView();
    }
}