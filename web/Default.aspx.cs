using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

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
        this.field.PivotColumn = 1;
        this.field.PivotRow = 1;


        HtmlBuilder htmlBuilder = new HtmlBuilder(this.field);

        Table table = htmlBuilder.GetTable();
        
        Controls.Add(table);

        Application["field"] = this.field;


        
    }
}
