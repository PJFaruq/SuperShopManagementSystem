/// <reference path="~/Themes/bower_components/jquery/dist/jquery.min.js" />
$(document).ready(function () {
    $("#Image").change(function () {
        $("#CurrentImage").hide();
    });


    //Check Item Name Availability
    var isAvaiable = false;
    $("#form").submit(function () {
        if (isAvaiable == true) {
            return false;
        }
    });

    function CheckItemName() {
        var CurrentCategoryName = $("#CurrentCategoryName").val();
        var CurrentItemName = $("#CurrentItemName").val();
        var name = $("#Name").val();
        var category = $("#ItemCategoryId").val();
        if (name != "" && category != null) {
            $.ajax({
                url: "/Items/CheckItemName",
                data: { itemName: name, itemCategory: category },
                type: "post",
                success: function (response) {
                    if (response == 1) {
                        if (CurrentCategoryName == category && CurrentItemName == name) {
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

    //Check Emloyee Email Availability
    $("#Email").on("blur", function () {
        var email = $("#Email").val();
        var currentEmail = $("#CurrentEmail").val();
        $.ajax({
            url: "/Employees/CheckEmployeeEmail",
            method: "post",
            data: { email: email },
            success: function (response) {
                if (response == 1) {
                    if (currentEmail == email) {
                        $("#ErrorMsgForEmail").empty();
                        isAvaiable = false;
                    }
                    else {
                        $("#ErrorMsgForEmail").html("This Email is Already Exist");
                        isAvaiable = true;
                    }
                    
                }
                else {
                    $("#ErrorMsgForEmail").empty();
                    isAvaiable = false;
                }
            }
        });
    });

});