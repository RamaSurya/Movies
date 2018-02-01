function CancelValidate() {


    var showid = document.getElementById("showid").value;
    var bookid = document.getElementById("bookid").value;
    document.getElementById("ERR_001").style.visibility = "hidden";
   
    document.getElementById("ERR_002").style.visibility = "hidden";
    document.getElementById("ERR_002.1").style.visibility = "hidden";

    if (showid == "") {
        document.getElementById("ERR_002.1").style.visibility = "visible";
        return false;
    }
    else if (showid != "") {
        if (!(/^[0-9]{5}$/).test(showid)) {
            document.getElementById("ERR_002").style.visibility = "visible";
            return false;
        }
        if (bookid == "") {
            document.getElementById("ERR_001").style.visibility = "visible";
            return false;
        }
        
    }
    else { return true;}
}