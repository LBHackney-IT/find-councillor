using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

//A reference to this page is put on the desired webpage as a script tag element
//which causes the output of this page to be inserted and executed.
//This causes the input html to be inserted as well as a function that will
//insert a script tag with the necessary parameters to 
//call the LLPGscript page that does the address search,
//returns the html results and removes the script element that was created before

public partial class CouncilorScript : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        
        HttpBrowserCapabilities b = Request.Browser;
        jsScript.PATH = Server.MapPath(@"js/getcouncillor.js");
        Lit1.Text = jsScript.CouncilorScript(b);
    }
}
