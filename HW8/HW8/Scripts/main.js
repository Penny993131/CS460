$(document).ready(function () {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Athletes/Details",
        success: showTheResults,
        error: errorOnAjax
    });
});

function getResults() {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "athletes/list",
        success: showTheResults,
        error: errorOnAjax
    });
}

function errorOnAjax() {
    console.log("ERROR FROM THE AJAX CALL");
}

function showTheResults(data) {
    console.log(data);
}