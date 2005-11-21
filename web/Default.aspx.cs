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
    private IMatrix matrix = new Matrix(5);

    Table table2;

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
                this.matrix.AddRow(row);
            }
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        if (Application["matrix"] == null)
            Application.Add("matrix",this.matrix);


        this.matrix = (Matrix)Application.Get("matrix");

        Row row = new Row(new double[] { 9, 9, 9, 9, 9 });
        this.matrix.AddRow(row);

        HtmlBuilder htmlBuilder = new HtmlBuilder(this.matrix);

        Table table = htmlBuilder.GetTable();
        
        Controls.Add(table);

        Application["matrix"] = this.matrix;


        
    }
}
