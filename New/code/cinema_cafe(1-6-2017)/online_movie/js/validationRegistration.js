﻿function FormValidate() {

    var name = document.getElementById("name").value;
    var mobilenumber = document.getElementById("mobilenumber").value;
    var userid = document.getElementById("userid").value;
    var password = document.getElementById("password").value;
    var answer = document.getElementById("answer").value;

    //atpos = userid.indexOf("@");
    //dotpos = userid.lastIndexOf(".");
    //var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;


    document.getElementById("ERR_001").style.visibility = "hidden";
    document.getElementById("ERR_001.1").style.visibility = "hidden";
    document.getElementById("ERR_001.2").style.visibility = "hidden";
    document.getElementById("ERR_002").style.visibility = "hidden";
    document.getElementById("ERR_003").style.visibility = "hidden";
    document.getElementById("ERR_003.1").style.visibility = "hidden";
    document.getElementById("ERR_003.2").style.visibility = "hidden";
    document.getElementById("ERR_004").style.visibility = "hidden";
    document.getElementById("ERR_004.1").style.visibility = "hidden";
    document.getElementById("ERR_005").style.visibility = "hidden";
    document.getElementById("ERR_005.1").style.visibility = "hidden";
    document.getElementById("ERR_005.2").style.visibility = "hidden";

    if (userid == "") {
        document.getElementById("ERR_003").style.visibility = "visible";
        //alert("user is blank");
        return false;
    }
    else if (userid != "") {
        if (!(/^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/).test(userid)) {
            document.getElementById("ERR_003.2").style.visibility = "visible";
            return false;
        }
    }

    if (userid.length > 50 || userid.lenth < 8) {
        document.getElementById("ERR_003.1").style.visibility = "visible";
        return false;
    }



    if (name == "") {
        document.getElementById("ERR_001").style.visibility = "visible";
        return false;

    }
    if (!(/^[a-zA-Z-,](\s{0,1}[a-zA-Z-, ])*[^\s]$/).test(name)) {
        document.getElementById("ERR_001.2").style.visibility = "visible";
        return false;
    }
    else if (name != "") {
        if (name.length > 20 || name.length < 5) {
            document.getElementById("ERR_001.1").style.visibility = "visible";
            return false;
        }
    }



    if (mobilenumber != "") {
        if (!(/^[1-9]{1}[0-9]{9}$/).test(mobilenumber)) {

            document.getElementById("ERR_002").style.visibility = "visible";
            return false;
        }
    }


    if (password == "") {
        document.getElementById("ERR_004").style.visibility = "visible";
        return false;
    }
    else if (password != "") {
        if (password.length > 20 || password.length < 8) {
            document.getElementById("ERR_004.1").style.visibility = "visible";
            return false;
        }


    }
    if (answer == "") {
        document.getElementById("ERR_005").style.visibility = "visible";
        return false;

    }
    if (!(/^[a-zA-Z-,](\s{0,1}[a-zA-Z-, ])*[^\s]$/).test(answer)) {
        document.getElementById("ERR_005.2").style.visibility = "visible";
        return false;
    }
    if (answer != "") {

        if (answer.length > 100 || answer.length < 5) {
            document.getElementById("ERR_005.1").style.visibility = "visible";
            return false;
        }
    }


    else {
        return true;
    }
}