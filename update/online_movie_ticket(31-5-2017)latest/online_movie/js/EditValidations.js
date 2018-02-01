function EditValidate() {
  

    var name = document.getElementById("name").value;
    var mobilenumber = document.getElementById("mobilenumber").value;
  
    var password = document.getElementById("password").value;
    var answer = document.getElementById("answer").value;

    document.getElementById("ERR_001").style.visibility = "hidden";
    document.getElementById("ERR_002").style.visibility = "hidden";
    document.getElementById("ERR_001.1").style.visibility = "hidden";
    document.getElementById("ERR_004").style.visibility = "hidden";
    document.getElementById("ERR_004.1").style.visibility = "hidden";
    document.getElementById("ERR_005").style.visibility = "hidden";
    document.getElementById("ERR_005.1").style.visibility = "hidden";


    if (name == "") {
        document.getElementById("ERR_001").style.visibility = "visible";
        return false;
    }
    else if (name != "") {
        if (name.length > 25 || name.length < 3) {
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
        if (name.length > 25 || name.length < 5) {
            document.getElementById("ERR_004.1").style.visibility = "visible";
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

    else {
        return true;
    }
}