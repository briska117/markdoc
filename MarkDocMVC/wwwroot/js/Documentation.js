$(document).ready(function () {

    
    //Set buttton action
    $("#btnSave").click(function () {
        sendDocumentation();
    });
});

function sendDocumentation() {
    var content = {
        "DocumentContent": $("#inp_editor1").val()
    };
    $.ajax({

        // The URL for the request
        url: "/Home/SaveDocumentation",

        // The data to send (will be converted to a query string)
        data: JSON.stringify(content),

        // Whether this is a POST or GET request
        type: "POST",

        // The type of data we expect back
        dataType: "text",
        contentType: 'application/json'

    })
    // Code to run if the request succeeds (is done);
    // The response is passed to the function
    .done(function (json) {
        alert(json);
    })
    // Code to run if the request fails; the raw request and
    // status codes are passed to the function
    .fail(function (xhr, status, errorThrown) {
        alert("Sorry, there was a problem!");
        console.log("Error: " + errorThrown);
        console.log("Status: " + status);
        console.dir(xhr);
    });
}
