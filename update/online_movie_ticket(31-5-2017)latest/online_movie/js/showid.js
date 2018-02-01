function showid() {
    var showid = document.getElementById("showid").value;

    document.getElementById("ERR_006").style.visibility = "hidden";
    document.getElementById("ERR_006.1").style.visibility = "hidden";

    if (showid == "") {
        document.getElementById("ERR_006").style.visibility = "visible";
        return false;
    }

    if (showid != "") {
        if ((/^[0-9]{5}$/).test(showid)) {
            document.getElementById("ERR_006.1").style.visibility = "visible";
            return false;

        }
    }
    else { return true; }
}