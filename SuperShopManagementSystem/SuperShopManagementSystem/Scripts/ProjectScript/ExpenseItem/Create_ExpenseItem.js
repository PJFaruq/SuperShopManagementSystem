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
    $("#ExpenseCategoryId").change(function () {
        CheckItemName();
    });
    function CheckItemName() {
        var name = $("#Name").val();
        var category = $("#ExpenseCategoryId").val();
        if (name != "" && category != null) {
            $.ajax({
                url: "/ExpenseItems/CheckExpenseItemName",
                data: { expenseItemName: name, expenseCategory: category },
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
            url: "/ExpenseItems/GetExpenseItemCode",
            method: "post",
            data: "",
            success: function (response) {
                $("input[name='Code']").val(response);
            }
        });
    });
});