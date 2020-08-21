// JScript File
var lastId;

function checkEnter(e){
    var characterCode;
    if (e && e.which) {
        characterCode = e.which;
    } else {
        e = event;
        characterCode = e.keyCode;
    }
    if (characterCode == 13) {
        getCouncilor();
        return false;
    } else {
        return true;
    }
}

function insertSearch(){
    document.getElementById('councilDiv').innerHTML = "<div id='bordiv' class='councillors'><div class='councillors__wrapper'><div class='councillors__input-wrapper'>" +
        "<label for='Text1' class='govuk-label lbh-label'>Enter postcode or address</label>" +
        "<input id='Text1' class='govuk-input lbh-input' onKeyPress='checkEnter(event)' /></div>" +
        "<input id='Button1' class='govuk-button lbh-button' title='GObtn' type='button' value='Go' onclick='javascript:getCouncilor();' /></div>" +
        "<div id='resdiv' class='councillors__results'></div>" +
    "</div>";
    
}

function scriptLoader() {    
    var link = document.createElement('link');
    link.setAttribute('rel', 'stylesheet');
    link.setAttribute('type', 'text/css');
    // link.setAttribute('href', 'https://map.hackney.gov.uk/FindCouncillor/lbh-frontend-1.6.3-abridged.min.css');
    link.setAttribute('href', 'https://map.hackney.gov.uk/FindCouncillor/lbh-frontend-3.0.0.min.css');
    document.getElementsByTagName('head')[0].appendChild(link);
    insertSearch();
}

function getCouncilor(str){
    //var COUNCILORSCRIPT = "https://testmap.hackney.gov.uk/FindCouncillor/LLPGscript.aspx?find=";
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

