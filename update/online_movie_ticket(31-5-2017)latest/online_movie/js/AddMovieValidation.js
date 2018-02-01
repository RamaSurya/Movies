function AddMovieValidate() {
    

    var showid = document.getElementById("showid").value;
    var moviename = document.getElementById("moviename").value;
    var date = document.getElementById("date").value;
    var starttime = document.getElementById("starttime").value;
    var endtime = document.getElementById("endtime").value;

    document.getElementById("ERR_001").style.visibility = "hidden";
    document.getElementById("ERR_001.1").style.visibility = "hidden";
    //document.getElementById("ERR_001.2").style.visibility = "hidden";
    document.getElementById("ERR_002").style.visibility = "hidden";
    document.getElementById("ERR_002.1").style.visibility = "hidden";
    //document.getElementById("ERR_002.2").style.visibility = "hidden";
    document.getElementById("ERR_003").style.visibility = "hidden";
    document.getElementById("ERR_004").style.visibility = "hidden";
    document.getElementById("ERR_005").style.visibility = "hidden";

    if (showid == "") {
        document.getElementById("ERR_001").style.visibility = "visible";
        return false;
    }
    else if (showid != "") {
        if (!(/^[0-9]{5}$/).test(showid)) {
            document.getElementById("ERR_001.1").style.visibility = "visible";
            return false;
        }
    }
    ///^[0-9]{5}$/
            //if (showid.lenght < 5 || showid.lenght > 0) {
            //    document.getElementById("ERR_001.2").style.visibility = "visible";
            //    return false;
            //}
        
 if (moviename == "") {
        document.getElementById("ERR_002").style.visibility = "visible";
        return false;
    }
    
             if (!(/^([a-zA-Z0-9_-]){3,50}$/).test(moviename)) {
                document.getElementById("ERR_002.1").style.visibility = "visible";
                return false;
            }
        
            //else if (moviename != "") {
            //    if (moviename.length > 50 || moviename.lenght < 3) {
            //        document.getElementById("ERR_002.2").style.visibility = "visible";
            //        return false;
            //    }
            //}
        if (date == "") {

            document.getElementById("ERR_003").style.visibility = "visible";
            return false;
        }
        if (starttime == "") {
        document.getElementById("ERR_004").style.visibility = "visible";
        return false;
    }
        if (endtime == "") {
        document.getElementById("ERR_005").style.visibility = "visible";
        return false;

    }
    else {
        return true;
    }
}