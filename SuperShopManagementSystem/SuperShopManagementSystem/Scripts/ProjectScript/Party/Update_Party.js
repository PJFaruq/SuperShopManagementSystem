/// <reference path="~/Themes/bower_components/jquery/dist/jquery.min.js" />
$(document).ready(function () {
    $("#Image").change(function () {
        $("#CurrentImage").hide();
    });


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
        var CurrentEmail = $("#CurrentEmail").val();
        var CurrentType = $("#CurrentType").val();

        if (email != "" && type != null) {
            $.ajax({
                url: "/Parties/CheckPartyEmail",
                data: { email: email, type: type },
                type: "post",
                success: function (response) {
                    if (response == 1) {
                        if (email == CurrentEmail && type == CurrentType) {
                            isAvaiable = false;
                            $("#ErrorMsg").empty();
                        }
                        else {
                            if (type == "Customer") {
                                $("#ErrorMsg").text("This Email is Already Exist as a Customer");
                            }
                            if (type == "Supplier") {
                                $("#ErrorMsg").text("This Email is Already Exist as a Supplier");
                            }
                            isAvaiable = true;
                        }

                    }
                    else {
                        $("#ErrorMsg").empty();
                        isAvaiable = false;
                    }
                }

            })
        }
    }

});