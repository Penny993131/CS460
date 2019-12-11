/*$(document).ready(function () {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Athletes/Details",
        success: showTheResults,
        error: errorOnAjax
    });
});*/

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
   $('#racelist').empty();//To be able to make it responsive

    console.log(data["Athletename"][0]);

    var row = document.createElement('tr'); 
    var n1 = document.createElement('th');
    var n1Text = document.createTextNode("Athlete Name");
    n1.append(n1Text);
    n1.style = "width: 150px";
    row.appendChild(n1);

 
    var n2 = document.createElement('th');
    var n2Text = document.createTextNode("Athlete Gender");
    n2.append(n2Text);
    n2.style = "width: 100px";
    row.appendChild(n2);

   
    var n3 = document.createElement('th');
    var n3Text = document.createTextNode("MeetDate");
    n3.append(n3Text);
    n3.style = "width: 200px";
    row.appendChild(n3);

    var n4 = document.createElement('th');
    var n4Text = document.createTextNode("EventTitle");
    n4.append(n4Text);
    n4.style = "width: 100px";
    row.appendChild(n4);

    
    var n5 = document.createElement('th');
    var n5Text = document.createTextNode("MeetTitle");
    n5.append(n5Text);
    n5.style = "width: 200px";
    row.appendChild(n5);

    var n6 = document.createElement('th');
    var n6Text = document.createTextNode("RaceTime");
    n6.append(n6Text);
    n6.style = "width: 100px";
    row.appendChild(n6);


    $('#racelist').append(row);// add the whole row to the table


    for (var i = 0; i < data["Eventtitle"].length; i++) {

        var row = document.createElement('tr'); //Creating a new row for the table
        var aname = document.createElement('td'); //Creating the table cell for athlete name
        var anameText = document.createTextNode(data["Athletename"][0]);
        aname.append(anameText);
        aname.style = "width: 150px";    
        row.appendChild(aname); //Add this cell to my row
       
      
        //$('#racelist').append(aname);//for the Details page to get all the data
       

    
        var agender = document.createElement('td'); //Creating the table cell for athlete gender
        var agenderText = document.createTextNode(data["Athletegender"][0]); //Creates a new text node for the athletes gender
        agender.appendChild(agenderText); // Adds the athlete's gender to the table data
        agender.style = "width: 100px";
        row.appendChild(agender); //Add the gender to the end of the row
        //$('#racelist').append(agender);
    


        var mdate = document.createElement('td');
        var mdateText = document.createTextNode(data["Meetdate"][i]);
        //mdate.sort(function (a, b) { return a - b }); 
        mdate.appendChild(mdateText);
        mdate.style = "width: 200px";
        row.appendChild(mdate);
       
       // $('#resultlist').append(mdate);
     

        
        var etitle = document.createElement('td');
        var etitleText = document.createTextNode(data["Eventtitle"][i]);
        etitle.appendChild(etitleText);
        etitle.style = "width: 100px";
        row.appendChild(etitle);
       // $('#resultlist').append(etitle);
     

   
        var mtitle = document.createElement('td');
        var mtitleText = document.createTextNode(data["Location"][i]);
        mtitle.appendChild(mtitleText);
        mtitle.style = "width: 200px";
        row.appendChild(mtitle);
       // $('#resultlist').append(mtitle);
      
        
        var rtime = document.createElement('td');
        var rtimeText = document.createTextNode(data["Racetime"][i]);
        rtime.appendChild(rtimeText);
        rtime.style = "width: 100px";
        row.appendChild(rtime);
       // $('#resultlist').append(rtime);*/

        //Now we take the row full of our data(name, gender, date, event, location, racetime)
        //And add this row to the table
        $('#racelist').append(row);
    }
}

//-----------------------------------------------------------------

$("#request").click(function () {
    var n = $("#count").val();
    url: "athletes/list?id=" + num,
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "athletes/list?id=" + num,
        success: displayData,
        error: errorOnAjax
    });
});

function errorOnAjax() {
    console.log("ERROR in ajax request.");
}

function displayData(data) {
    console.log(data);
    $('#message').text(data["message"]);
    $('#num').text(data.num);
    $('#numbers').text(data["numbers"]);
    var trace = {
        x: mdate.numbers1,
        y: rtime.numbers,
        mode: 'lines',
        type: 'scatter'
    };
    var plotData = [trace];
    var layout = {};
    Plotly.newPlot('theplot', plotData, layout);
}

function displayRaceChange(data) {
    for (var i = 0; i < data["Eventtitle"].length; i++) {
        $('#mdate').append($('<li>' + data[i] + '</li>'));
    }
}