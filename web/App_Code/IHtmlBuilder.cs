using System.Drawing;
using System.Web.UI.WebControls;

internal interface IHtmlBuilder
{
    Color ForeColor { get; set; }
    Table GetTable();
    bool ShowColumnHeader { get; set; }
    bool ShowRowHeader { get; set; }
}