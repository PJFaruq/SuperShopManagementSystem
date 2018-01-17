/// <reference path="~/Themes/bower_components/jquery/dist/jquery.min.js" />
$(document).ready(function () {
    $("#Image").change(function () {
        $("#CurrentImage").hide();
    });


    //Check Organization Name Availability
    var isAvaiable = false;
    $("#form").submit(function () {
        if (isAvaiable == true) {
            return false;
        }
    });
    $("#Name").blur(function () {
        CheckOrganizationName();
    });
    function CheckOrganizationName() {
        var CurrentOrganizationName = $("#CurrentOrganizationName").val();
        var name = $("#Name").val();
        if (name != "") {
            $.ajax({
                url: "/Organizations/CheckOrganizationName",
                data: { organizationName: name },
                type: "post",
                success: function (response) {
                    if (response == 1) {
                        if (CurrentOrganizationName == name) {
                            $("#ErrorMsg").empty();
                            isAvaiable = false;
                        }
                        else {
                            $("#ErrorMsg").text("This Name is Already Exist");
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