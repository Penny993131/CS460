$(document).ready(function () {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Athletes/Details",
        success: showTheResults,
        error: errorOnAjax
    });
});

function getResults(num) {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "athletes/list?id=" + num,
        success: showTheResults,
        error: errorOnAjax
    });
}

function errorOnAjax() {
    console.log("ERROR FROM THE AJAX CALL");
}

function showTheResults(data) {
    //console.log(data["Athletename"]);
    //$('#resultlist').empty();
    console.log(data["Athletename"][0]);

    for (var i = 0; i < data["Eventtitle"].length; i++) {
        var aname = document.createElement('p');
        var anameText = document.createTextNode(data["Athletename"][0]);
        aname.append(anameText);
        $('#resultlist').append(aname);

        var agender = document.createElement('p');
        var agenderText = document.createTextNode(data["Athletegender"][0]);
        agender.appendChild(agenderText);
        $('#resultlist').append(agender);

        var mdate = document.createElement('p');
        var mdateText = document.createTextNode(data["Meetdate"][i]);
        mdate.appendChild(mdateText);
        $('#resultlist').append(mdate);

        var etitle = document.createElement('p');
        var etitleText = document.createTextNode(data["Eventtitle"][i]);
        etitle.appendChild(etitleText);
        $('#resultlist').append(etitle);


        var mtitle = document.createElement('p');
        var mtitleText = document.createTextNode(data["Location"][i]);
        mtitle.appendChild(mtitleText);
        $('#resultlist').append(mtitle);



        var rtime = document.createElement('p');
        var rtimeText = document.createTextNode(data["Racetime"][i]);
        rtime.appendChild(rtimeText);
        $('#resultlist').append(rtime);
    }
}
