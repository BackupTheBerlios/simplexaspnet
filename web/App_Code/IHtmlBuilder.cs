using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
interface IHtmlBuilder
{
    void Build(IMatrix matrix);

    string GetHtml();

    Table GetTable();
    
}
