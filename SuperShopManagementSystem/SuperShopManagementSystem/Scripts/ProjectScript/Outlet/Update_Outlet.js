/// <reference path="~/Themes/bower_components/jquery/dist/jquery.min.js" />
$(document).ready(function () {

    //Check Outlet Name Availability
    var isAvaiable = false;
    $("#form").submit(function () {
        if (isAvaiable == true) {
            return false;
        }
    });
    $("#Name").blur(function () {
        CheckOutletName();
    });
    $("#OrganizationId").change(function () {
        CheckOutletName();
    });
    function CheckOutletName() {
        var CurrentOrganizationName = $("#CurrentOrganizationName").val();
        var CurrentOutletName = $("#CurrentOutletName").val();
        var name = $("#Name").val();
        var organization = $("#OrganizationId").val();
        if (name != "" && organization != null) {
            $.ajax({
                url: "/Outlets/CheckOutletName",
                data: { outletName: name, organizationName: organization },
                type: "post",
                success: function (response) {
                    if (response == 1) {
                        if (CurrentOrganizationName == organization && CurrentOutletName == name) {
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