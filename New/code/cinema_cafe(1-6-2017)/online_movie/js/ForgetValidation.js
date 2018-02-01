function ForgetFormValidate() {

    var userid = document.getElementById("userid").value;
    var answer = document.getElementById("answer").value;

    document.getElementById("ERR_003").style.visibility = "hidden";
    document.getElementById("ERR_003.1").style.visibility = "hidden";
    document.getElementById("ERR_005").style.visibility = "hidden";
    document.getElementById("ERR_005.1").style.visibility = "hidden";
    document.getElementById("ERR_005.2").style.visibility = "hidden";

    if (userid == "") {
        document.getElementById("ERR_003").style.visibility = "visible";
        return false;
    }
    else if (userid != "") {
        if (!(/^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/).test(userid)) {
            document.getElementById("ERR_003.1").style.visibility = "visible";
            return false;
        }
    }


    if (answer == "") {
        document.getElementById("ERR_005").style.visibility = "visible";
        return false;
    }
    if (!(/^[a-zA-Z-,](\s{0,1}[a-zA-Z-, ])*[^\s]$/).test(answer)) {
        document.getElementById("ERR_005.1").style.visibility = "visible";
        return false;
    }
    if (answer != "") {

        if (answer.length > 100 || answer.length < 5) {
            document.getElementById("ERR_005.2").style.visibility = "visible";
            return false;
        }
    }
}
