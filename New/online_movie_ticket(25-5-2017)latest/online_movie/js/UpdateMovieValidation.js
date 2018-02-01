function UpdateMovieValidate() {


   
    var moviename = document.getElementById("moviename").value;
    var date = document.getElementById("date").value;
    var starttime = document.getElementById("starttime").value;
    var endtime = document.getElementById("endtime").value;

    document.getElementById("ERR_001").style.visibility = "hidden";
    document.getElementById("ERR_002").style.visibility = "hidden";
    document.getElementById("ERR_003").style.visibility = "hidden";
    document.getElementById("ERR_004").style.visibility = "hidden";
  


    if (moviename == "") {
        document.getElementById("ERR_001").style.visibility = "visible";
        return false;

    }

    if (date == "") {

        document.getElementById("ERR_002").style.visibility = "visible";
        return false;
    }



    if (starttime == "") {
        document.getElementById("ERR_003").style.visibility = "visible";
        return false;
    }
    if (endtime == "") {
        document.getElementById("ERR_004").style.visibility = "visible";
        return false;

    }
    else {
        return true;
    }
}