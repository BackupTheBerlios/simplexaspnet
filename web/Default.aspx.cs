using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

public partial class _Default : System.Web.UI.Page 
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

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        if (Application["field"] == null)
            Application.Add("field", this.field);


        this.field = (SimplexField)Application.Get("field");

        Row row = new Row(new double[] { 9, 9, 9, 9, 9 });

        this.field.AddRow(row);
        this.field.PivotColumn = Convert.ToInt32(this.PivotColumn.Text);
        this.field.PivotRow = Convert.ToInt32(this.PivotRow.Text);


        HtmlBuilder htmlBuilder = new HtmlBuilder(this.field);
        htmlBuilder.ShowColumnHeader = true;
        htmlBuilder.ShowRowHeader = true;
        htmlBuilder.ForeColor = Color.Orange;
        Table table = htmlBuilder.GetTable();

        this.Panel1.Controls.Add(table);

        Application["field"] = this.field;
        
    }
}
