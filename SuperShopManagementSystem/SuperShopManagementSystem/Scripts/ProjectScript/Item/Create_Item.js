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
    $("#ItemCategoryId").change(function () {
        CheckItemName();
    });
    function CheckItemName() {
        var name = $("#Name").val();
        var category = $("#ItemCategoryId").val();
        if (name != "" && category != null) {
            $.ajax({
                url: "/Items/CheckItemName",
                data: { itemName: name, itemCategory: category },
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
            url: "/Items/GetItemCode",
            method: "post",
            data: "",
            success: function (response) {
                $("input[name='Code']").val(response);
            }
        });
    });
});