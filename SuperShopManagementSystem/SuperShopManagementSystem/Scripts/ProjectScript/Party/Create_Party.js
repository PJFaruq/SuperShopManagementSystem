/// <reference path="~/Themes/bower_components/jquery/dist/jquery.min.js" />

$(document).ready(function () {


    //Check Party Email Availability
    var isAvaiable = false;
    $("#form").submit(function () {
        if (isAvaiable == true) {
            return false;
        }
    });
    $("#Email").blur(function () {
        CheckEmail();
    });
    $("input[name='Type']").change(function () {
        CheckEmail();
    });
    function CheckEmail() {
        var email = $("#Email").val();
        var type = $("input[name='Type']:checked").val();
        if (email != "" && type != null) {
            $.ajax({
                url: "/Parties/CheckPartyEmail",
                data: { email: email, type: type },
                type: "post",
                success: function (response) {
                    if (response == 1) {
                        
                        if (type == "Customer") {
                            $("#ErrorMsg").text("This Email is Already Exist as a Customer");
                        }
                        if (type == "Supplier") {
                            $("#ErrorMsg").text("This Email is Already Exist as a Supplier");
                        }
                        isAvaiable = true;
                    }
                    else {
                        $("#ErrorMsg").empty();
                        isAvaiable = false;
                    }
                }

            })
        }
    }


    //Generating Random Code for Item
    $("#Name").focus(function () {
        $.ajax({
            url: "/Parties/GetPartyCode",
            method: "post",
            data: "",
            success: function (response) {
                $("input[name='Code']").val(response);
            }
        });
    });
});