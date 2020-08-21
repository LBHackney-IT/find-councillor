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

public partial class LLPGscript : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string par = GetParameter();
        
        Lit1.Text = GetCouncilorHTML(par); 
    }

   
    public string GetCouncilorHTML(string AddressOrPostcode)
    {
        LLPGservice.SearchLLPGservice ws = new LLPGservice.SearchLLPGservice();
       // ws.Url = "http://156.61.41.233/TestService/searchLLPG.asmx";
        //ws.Url = "http://156.61.41.233/NLPG/searchLLPG.asmx";
        //ws.Url = "http://lbhgisnetp01/NLPG/searchLLPG.asmx";
        string str = ws.GetCouncilorHTML(AddressOrPostcode);
        string ret = "var contentdiv = document.getElementById('resdiv');" +
                    "contentdiv.innerHTML = \"" + str + "\";" +
                    "contentdiv.style.visibility = 'visible';" +
                    "document.getElementById('bordiv').style.height='210px';";
       

        return ret;
    }

    public string GetParameter()
    {
        string pc = Request.QueryString["inPostcode"];
        if (string.IsNullOrEmpty(pc))
        {
            pc = Request.QueryString["Postcode"];
        }

        if (string.IsNullOrEmpty(pc))
        {
            pc = Request.QueryString["pc"];
        }

        string add = Request.QueryString["inAddress"];
        if (string.IsNullOrEmpty(add))
        {
            add = Request.QueryString["Address"];
        }


        string sUPRN = Request.QueryString["inUPRN"];
        if (string.IsNullOrEmpty(sUPRN))
        {
            sUPRN = Request.QueryString["UPRN"];
        }

        string find = Request.QueryString["find"];
        if (string.IsNullOrEmpty(find))
        {
            find = Request.QueryString["Find"];
        }

        if (!string.IsNullOrEmpty(sUPRN))
        {
            return sUPRN;
        }
        else if (!string.IsNullOrEmpty(pc))
        {
            return pc;

        }
        else if (!string.IsNullOrEmpty(add))
        {
            return add;

        }
        else if (!string.IsNullOrEmpty(find))
        {
            return find;

        }


        return "E8 1EA";



    }
}
