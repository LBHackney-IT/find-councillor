// JScript File


var lastId;

function checkEnter(e){
    var characterCode;
    if (e && e.which) {
        e = e;
        characterCode = e.which;
    }
    else {
        e = event;
        characterCode = e.keyCode;
    }
    if (characterCode == 13) {
        getCouncilor();
        return false;
    }
    else {
        return true;
    }
}


var cleartxt = function(){

    var t = document.getElementById('Text1');
    var v = t.value;
    if (v == 'Enter postcode or address') {
        t.value = '';
        t.className = 'btxt';
    }
}

function insertSearch(){
    //document.getElementById('councilDiv').innerHTML = "<div id='bordiv' style='z-index: 103; width: 235px; position: relative;" +
    //"height: 40px; border-right: #b3b3b3 thin solid; border-top: #b3b3b3 thin solid; border-left: #b3b3b3 thin solid; border-bottom: #b3b3b3 thin solid;'>" +
    //"<div id='resdiv' style='visibility:hidden; z-index: 100; left: 5px; width: 200px; position: absolute; top: 50px;  height: 135px;font:normal 8pt tahoma,verdana,helvetica;text-align:left;padding:10px;background:#F0F9F7;'>" +
    //"</div>" +
    //"<input id='Text1' style='z-index: 101; left: 5px; width: 175px; position: absolute;" +
    //"top: 10px' type='text' value='Enter postcode or address' class='gtxt' onclick='javascript:cleartxt();' onKeyPress='checkEnter(event)' />" +
    //"<input id='Button1' style='z-index: 102; left: 195px; position: absolute; top: 5px; width: 35px; height: 30px;'" +
    //"title='GObtn' type='button' value='Go' onclick='javascript:getCouncilor();' />" +
    //"</div>";
    document.getElementById('councilDiv').innerHTML = "<div id='bordiv' style='z-index: 103; width: 245px; position: relative;" +
    "height: 40px; border-right: #b3b3b3 thin solid; border-top: #b3b3b3 thin solid; border-left: #b3b3b3 thin solid; border-bottom: #b3b3b3 thin solid;'>" +
    "<div id='resdiv' style='visibility:hidden; z-index: 100; left: 5px; width: 215px; position: absolute; top: 50px;  height: 135px;font:normal 8pt tahoma,verdana,helvetica;text-align:left;padding:10px;background:#F0F9F7;'>" +
    "</div>" +
    "<input id='Text1' style='z-index: 101; left: 5px; width: 190px; position: absolute;" +
    "top: 4px; margin-top:0px; margin-bottom:0px' type='text' value='Enter postcode or address' class='gtxt' onclick='javascript:cleartxt();' onKeyPress='checkEnter(event)' />" +
    "<input id='Button1' style='z-index: 102; left: 204px; position: absolute; top: 5px; width: 35px; height: 30px; margin-top:0px; margin-bottom:0px;'" +
    "title='GObtn' type='button' value='Go' onclick='javascript:getCouncilor();' />" +
    "</div>";
    
}

function scriptLoader(){
    var br = navigator.appName.toLowerCase();
    var ag = navigator.userAgent.toLowerCase();
    var ve = ""
    if (navigator.vendor){
        ve = navigator.vendor.toLowerCase();
        }
    var browser = "";
    if (br.indexOf("microsoft") > -1) {
        browser = "ie"
    }
    else 
        if (ve.indexOf("apple") > -1) {
            browser = "safari"
        }
    
    var st = "a.hk-a:link{text-decoration:none;}" +
    "a.hk-a:visited{text-decoration:none;}" +
    "a.hk-a:hover{text-decoration:underline;}" +
    ".gtxt{color:Gray;}" +
    ".btxt{color:Black;}";
    var Cstyle = document.createElement('style');
    Cstyle.setAttribute('type', 'text/css');
    
    if (browser == "ie") {
        Cstyle.styleSheet.cssText = st;
    }
    else 
        if (browser == "safari") {
            Cstyle.innerText = st;
        }
        else {
            Cstyle.innerHTML = st;
        }
    
    try {
        document.getElementsByTagName('head').item(0).appendChild(Cstyle);
    } 
    catch (e) {
        document.body.appendChild(Cstyle);
    }
    
    insertSearch();
    
    
}

function getCouncilor(str){
    //var COUNCILORSCRIPT = "http://lbhgiswebt01/FindCouncillor/LLPGscript.aspx?find=";
    var COUNCILORSCRIPT = "https://map.hackney.gov.uk/FindCouncillor/LLPGscript.aspx?find=";
    
    if (lastId != null) {
        try {
        
            document.getElementsByTagName('head').item(0).removeChild(document.getElementById(lastId));
        } 
        catch (e) {
            document.body.removeChild(document.getElementById(lastId));
        }
    }
    var dt = new Date();
    lastId = dt.getTime();
    var ft = document.getElementById('Text1').value;
    if (str) {
        document.getElementById('Text1').value = str;
        ft = str;
    };
    var JSONscript = document.createElement('script');
    JSONscript.setAttribute('type', 'text/javascript');
    JSONscript.setAttribute('src', COUNCILORSCRIPT + ft);
    JSONscript.setAttribute('id', lastId);
    try {
        document.getElementsByTagName('head').item(0).appendChild(JSONscript);
    } 
    catch (e) {
        document.body.appendChild(JSONscript);
    }
    
    
}

scriptLoader();

