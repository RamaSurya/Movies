function MainFormValidate() {

    var userid = document.getElementById("userid").value;
    var password = document.getElementById("password").value;
    document.getElementById("ERR_001").style.visibility = "hidden";
    document.getElementById("ERR_001.1").style.visibility = "hidden";
    document.getElementById("ERR_002").style.visibility = "hidden";
    document.getElementById("ERR_002.1").style.visibility = "hidden";

    if (userid == "") {
        document.getElementById("ERR_001").style.visibility = "visible";
        return false;
    }
    else if (userid != "") {
        if (!(/^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/).test(userid)) {
            document.getElementById("ERR_001.1").style.visibility = "visible";
            return false;
        }
    }
    if (password == "") {
        document.getElementById("ERR_002").style.visibility = "visible";
        return false;
    }
     if (password != "") {
        if (password.length > 20 || password.length < 8) {
            document.getElementById("ERR_002.1").style.visibility = "visible";

            return false;
        }


    }
    else {
        return true;
    }

}