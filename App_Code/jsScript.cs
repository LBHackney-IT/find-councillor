using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.IO;

/// <summary>
/// Summary description for jsScript
/// </summary>
public class jsScript
{
    //static string COUNCILORSCRIPT = "http://www.map.hackney.gov.uk/FindCouncillor/LLPGscript.aspx?find=";
    static string COUNCILORSCRIPT = "LLPGscript.aspx?find=";
    public static string PATH = "";
    public jsScript()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string searchCouncilorScript()
    {
        string fn = "";
        fn = getQueryFunction();
        fn += getAjaxFunctions();
        return fn;

    }
    public static string getAjaxFunctions()
    {
    string fn="";

    //string callback =
    //    "function ClientCallback(str)" +
    //    "{" +
    //        "try" +
    //        "{" +
    //            "eval(str);" +
    //        "}" +
    //        "catch(e){}" +
    //    "}";


    //fn = callback;
    
    fn += "function SendAjax(str,context){" +
         "var httpRequest = false;" +
       "if (window.XMLHttpRequest) { // Mozilla, Safari,..." +
            "httpRequest = new XMLHttpRequest();" +
            "if (httpRequest.overrideMimeType) {" +
                "httpRequest.overrideMimeType('text/xml');" +
            "}" +
        "}" +
        "else if (window.ActiveXObject) { // IE" +
            "try {" +
                "httpRequest = new ActiveXObject('Msxml2.XMLHTTP');" +
            "}" +
            "catch (e) {" +
                "try {" +
                    "httpRequest = new ActiveXObject('Microsoft.XMLHTTP');" +
                "}" +
                "catch (e) {}" +
            "}" +
        "}" +

    "httpRequest.onreadystatechange  = function()" +
    "{" +
         "if(httpRequest.readyState  == 4)" +
         "{" +
              "if(httpRequest.status  == 200) eval(httpRequest.responseText);" +
         "}" +
    "}" +

        "httpRequest.open( 'GET', 'http://www.ac-markets.com/Ajax.aspx?convert='+str,  true);" +
        "httpRequest.send(null);"+ 
    "}";

    return fn;

    }

    public static string getQueryFunction()
    {
        string fn = "";
        fn = "function ConvertCouncilor()" +
        "{" +
        "var add = 'E8 1HH';" +
        "SendAjax(add,'NoContextToRefresh');"+
        "}";

        return fn;
    }
    public static string CouncilorScript(HttpBrowserCapabilities browser)
    {
        StreamReader rd = new StreamReader(PATH);
        string script = rd.ReadToEnd();
        rd.Close();
        return script;
    }

    public static string CouncilorScriptOLD(HttpBrowserCapabilities browser)
    {               
        string fn =""+ 
            //"alert('Hello');"+
        
            "document.getElementById('councilDiv').innerHTML="+
            "\"<div id='bordiv' style='z-index: 103; width: 230px; position: relative;"+
        "height: 40px; border-right: #b3b3b3 thin solid; border-top: #b3b3b3 thin solid; border-left: #b3b3b3 thin solid; border-bottom: #b3b3b3 thin solid;'>"+
         //"<h2>Find My Councilor</h2>"+
         //"<h2 style='color:#9C1E3D;font-size:111%;font-weight:normal;margin:0;padding:0 0 5px;text-align:center;'>Find My Councillor</h2>" +
    "<div id='resdiv' style='visibility:hidden; z-index: 100; left: 5px; width: 200px; position: absolute; top: 50px;  height: 135px;font:normal 8pt tahoma,verdana,helvetica;text-align:left;padding:10px;background:#F0F9F7;'>"+
    "</div>"+
   
   
  
    "<input id='Text1' style='z-index: 101; left: 5px; width: 175px; position: absolute;"+
        "top: 10px' type='text' value='Enter postcode or address' class='gtxt' onclick='javascript:cleartxt();' onKeyPress='checkEnter(event)' />" +
    "<input id='Button1' style='z-index: 102; left: 195px; position: absolute; top: 5px; width: 30px; height: 30px;'"+
        "title='GObtn' type='button' value='GO' onclick='javascript:getCouncilor();' />"+
      "</div>\";";
        fn += ScriptChanger(browser);

        return  fn;

    }

    public static string ScriptChanger(HttpBrowserCapabilities browser)
    {

        string styles = "";

        bool safari = browser.IsBrowser("Safari");
      

        if (browser.IsBrowser("IE"))
        {
            styles = "Cstyle.styleSheet.cssText =\"" + InsertStyles() + "\";\n";
        }
        else if (safari)
        {
            styles = "Cstyle.innerText=\"" + InsertStyles() + "\";\n";
        }
        else
        {
            styles = "Cstyle.innerHTML=\"" + InsertStyles() + "\";\n";
        }

        string fn = "" +

                "var Cstyle = document.createElement('style');\n" +
            "Cstyle.setAttribute('type','text/css');\n" +
            styles +

            "var Cscript = document.createElement('script');\n" +
            //"alert('Hello');"+
        "Cscript.setAttribute('type','text/javascript');\n" +
       "Cscript.text =\"" + ClearFunction() +



        "var lastId;" +
        "function getCouncilor(str){" +
            //"alert('latId='+lastId);" +
        "if (lastId != null) {" +
            "try {" +
                "document.getElementsByTagName('head').item(0).removeChild(document.getElementById(lastId));" +
            "} catch(e) {" +
                "document.body.removeChild(document.getElementById(lastId));" +
            "}" +
        "}" +
        "var dt = new Date();" +
        "lastId = dt.getTime();" +
         "var ft = document.getElementById('Text1').value;" +
        "if (str){document.getElementById('Text1').value = str;ft=str;};"+      
        "var JSONscript = document.createElement('script');" +
        "JSONscript.setAttribute('type','text/javascript');" +
        "JSONscript.setAttribute('src','"+COUNCILORSCRIPT+"'+ft);" +
        "JSONscript.setAttribute('id',lastId);" +
        "try {" +
        "document.getElementsByTagName('head').item(0).appendChild(JSONscript);" +
        "}" +
        "catch(e) {" +
            "document.body.appendChild(JSONscript);" +
        "}" +
        "}\";" +

        "try {" +
        "document.getElementsByTagName('head').item(0).appendChild(Cscript);" +
        "}" +
        "catch(e) {" +
            "document.body.appendChild(Cscript);" +
        "}"+


        "try {" +
        "document.getElementsByTagName('head').item(0).appendChild(Cstyle);" +
        "}" +
        "catch(e) {" +
            "document.body.appendChild(Cstyle);" +
        "}";


        
        return fn;

    }

    public static string InsertStyles()
    {
        string fn = "" +
        "a.hk-a:link{text-decoration:none;}" +
        "a.hk-a:visited{text-decoration:none;}" +
        "a.hk-a:hover{text-decoration:underline;}"+
        ".gtxt{color:Gray;}" +
        ".btxt{color:Black;}";
            
        //string fn = "";
        return fn;

    }

    public static string InsertStylesOLD()
    {
        string fn = "" +
        "div.cparty{float:right;}" +
            "div.cname{float:left; text-align:left; font-weight:bold;}" +
            "div.lname{font-weight:bold;}" +
            "div.wname h2{color: #9C1E3D; font-size: 111%; text-align:center}" +
            ".hkdetails ul,hkdetails li{list-style-type:none; margin:0; padding:0;clear:both;}" +
            ".gtxt{color:Gray;}" +
            ".btxt{color:Black;}";

        return fn;

    }

    public static string ClearFunction()
    {
        string fn = "" +
       "function cleartxt(){" +
        //"alert('Clear');"+
        "var t = document.getElementById('Text1');" +
        //"alert('t='+t);" +
        "var v = t.value;" +
        //"alert('v='+v);" +
        "if(v == 'Enter postcode or address'){" +
            "t.value = '';" +
            "t.className = 'btxt';" +
        "}" +

        "return false;" +

        "}";
        fn += EnterFunction();
        return fn;
    }

    public static string EnterFunction()
    {
        string fn = ""+
               "function checkEnter(e){"+ 
                "var characterCode;"+ 
                "if (e && e.which){"+ 
                    "e = e;"+
                    "characterCode = e.which;"+ 
                "}"+
                "else {"+
                    "e = event;"+
                    "characterCode = e.keyCode ;"+
                "}"+
                
                "if (characterCode == 13) {"+ 
                    //"alert(\'Enter key pressed\');"+
                     "getCouncilor();"+
                    "return false;"+
                "}"+
                "else {"+
                    "return true;"+
                "}"+
                
            "}";

        return fn;


    }
}
