/// <reference path="~/Themes/bower_components/jquery/dist/jquery.min.js" />
$(document).ready(function () {

    //Random Code Generating 
    $("#Name").focus(function () {
        $.ajax({
            url: "/Organizations/GetOrganizationCode",
            method: "post",
            data: "",
            success: function (response) {
                $("input[name='Code']").val(response);
            }
        });
    });


    //Check Oranization Name Availability
    var isValid = false;
    $("#form").submit(function () {
        if (isValid == true) {
            return false;
        }
    });
    $("#Name").blur(function () {
        var name = $("input[name='Name']").val();
        $.ajax({
            url: "/Organizations/CheckOrganizationName",
            method: "post",
            data: { organizationName: name },
            success: function (response) {
                if (response == 1) {
                    $("#ErrorMsg").html("This Name is Already Exist");
                    isValid = true;
                }
                if (response == 0) {
                    isValid = false;
                    $("#ErrorMsg").empty();

                }
            }
        });
    });

});