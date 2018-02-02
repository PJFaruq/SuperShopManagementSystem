/// <reference path="~/Themes/bower_components/jquery/dist/jquery.min.js" />

$(document).ready(function () {


    $("#JoiningDate").datepicker({
        autoclose:true
    });
    var isAvaiable = false;
    $("#form").submit(function () {
        if (isAvaiable == true) {
            return false;
        }
    });
    
    //Check Emloyee Email Availability
    $("#Email").on("blur", function () {
        var email = $("#Email").val();
        $.ajax({
            url: "/Employees/CheckEmployeeEmail",
            method: "post",
            data: { email: email },
            success: function (response) {
                if (response == 1) {
                    $("#ErrorMsgForEmail").html( "This Email is Already Exist");
                    isAvaiable = true;
                }
                else
                {
                    $("#ErrorMsgForEmail").empty();
                    isAvaiable = false;
                }
            }
        });
    })


    //Generating Random Code for Emplyee
    $("#Name").focus(function () {
        $.ajax({
            url: "/Employees/GetEmployeeCode",
            method: "post",
            data: "",
            success: function (response) {
                $("input[name='Code']").val(response);
            }
        });
    });
});