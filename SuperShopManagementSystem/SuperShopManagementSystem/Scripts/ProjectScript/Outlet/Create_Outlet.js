/// <reference path="~/Themes/bower_components/jquery/dist/jquery.min.js" />

$(document).ready(function () {


    //Check Item Name Availability
    var isAvaiable = false;
    $("#form").submit(function () {
        if (isAvaiable == true) {
            return false;
        }
    });
    $("#Name").blur(function () {
        CheckItemName();
    });
    $("#OrganizationId").change(function () {
        CheckItemName();
    });
    function CheckItemName() {
        var name = $("#Name").val();
        var organization = $("#OrganizationId").val();
        if (name != "" && organization != null) {
            $.ajax({
                url: "/Outlets/CheckOutletName",
                data: { outletName: name, organization: organization },
                type: "post",
                success: function (response) {
                    if (response == 1) {
                        $("#ErrorMsg").text("This Name is Already Exist");
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
            url: "/Outlets/GetOutletCode",
            method: "post",
            data: "",
            success: function (response) {
                $("input[name='Code']").val(response);
            }
        });
    });
});