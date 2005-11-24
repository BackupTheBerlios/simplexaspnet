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
        if (!this.IsPostBack)
        {
            // Initialize controls number.
            // Used to create control id
            this.Session.Add("LastControl", 2);
        }
        else
        {
            // Recreate controls created on previous roundtrips
            if (Session["VarTextBoxes"] != null)
            {
                this.VarTextBoxes = (TextBox[,])Session["VarTextBoxes"];
                foreach (TextBox box in this.VarTextBoxes)
                {
                    this.View2.Controls.Add(box);
                }

            }
            //RecreatePersistedControls();
        }

        if (Session["state"] == null)
        {
            Session["state"] = "start";
            this.MultiView1.SetActiveView(this.View1);
        }
        //if (this.VarTextBoxes != null)
        //{
        //    int count = this.VarTextBoxes.Length;
        //}
    }

    private void GenerateField()
    {
        int columns = this.VarTextBoxes.GetLength(0);


        this.field = new SimplexField(columns);

        Row[] rows = new Row[this.VarTextBoxes.GetLength(1)];

        for (int y = 0; y < this.VarTextBoxes.GetLength(1); y++ )
        {
            double[] drow = new double[this.VarTextBoxes.GetLength(0)];

            for (int x = 0; x < this.VarTextBoxes.GetLength(0);x++ )
            {
                if (this.VarTextBoxes[x, y]== null )
                {
                    drow[x] = 0;
                }
                else
                {
                    try
                    {
                        drow[x] = Convert.ToDouble(this.VarTextBoxes[x, y].Text);
                    }
                    catch
                    {
                        drow[x] = 0;
                    }
                }
            }
            rows[y] = new Row(drow);
        }


        //Row[] rows = new Row[3];
        //rows[0] = new Row(new double[] { 1, 2, 3, 4, 5 });
        //rows[1] = new Row(new double[] { 6, 7, 8, 9, 10 });
        //rows[2] = new Row(new double[] { 11, 12, 13, 14, 15 });


        foreach (Row row in rows)
        {
            this.field.AddRow(row);
        }

        Session["field"] = this.field;
    }

    private void ShowView()
    {
        string state = Session["state"] as string;

        switch (state)
        {
            case "phase3nextstep":
                this.field = (SimplexField)Session["field"];

                Simplex simplex = new Simplex(this.field);
                simplex.NextSetp();
                this.field = simplex.Field;

                this.DrawField();
                this.MultiView1.SetActiveView(this.View3);
                Session["field"]=this.field;
                break;
            case "phase3refresh":
                this.field = (SimplexField)Session["field"];
                this.DrawField();
                this.MultiView1.SetActiveView(this.View3);
                break;
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

        if (Session["VarTextBoxes"] != null)
            this.VarTextBoxes = (TextBox[,])Session["VarTextBoxes"];
        else
            this.VarTextBoxes = new TextBox[x + 1,y + 1];

        Table table = new Table();

        for (int i = 0; i < y + 1; i++)
        {
            TableRow trow = new TableRow();


            for (int i2 = 0; i2 < x + 1; i2++)
            {
                TableCell cell = new TableCell();
                Label label = new Label();

                if (VarTextBoxes[i2, i]==null)
                    VarTextBoxes[i2, i] = new TextBox();

                VarTextBoxes[i2, i].Width = 30;
                VarTextBoxes[i2, i].ID = "var[" + i2.ToString() + "," + i.ToString() + "]";
                VarTextBoxes[i2, i].TextChanged += new EventHandler(TextBox_TextChanged);


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

        Session["VarTextBoxes"] = VarTextBoxes;
        this.View2.Controls.Add(table);
        this.ShowView();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Session["state"] = "phase3";
        // int count = this.VarTextBoxes.Length;
        this.ShowView();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Session["state"] = null;
        //  this.ShowView();
    }

    #region Event Handlers for new controls

    private void Button_Click(object sender, EventArgs e)
    {
        this.lblResult.Text = ((Button) sender).Text + " clicked";
    }

    private void TextBox_TextChanged(object sender, EventArgs e)
    {
        this.lblText.Text = ((TextBox) sender).Text + " text changed";
    }

    #endregion

    //vielleicht:
    protected override void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        //    this.cmdAdd.Click += new System.EventHandler(this.Button1_Click);
        //    this.TextBox1.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
        //this.Button1.Click += new System.EventHandler(this.Button_Click);
        this.Load += new EventHandler(this.Page_Load);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["state"] = "phase3refresh";
        // int count = this.VarTextBoxes.Length;
        this.ShowView();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Session["state"] = "phase3nextstep";
        // int count = this.VarTextBoxes.Length;
        this.ShowView();
    }
}