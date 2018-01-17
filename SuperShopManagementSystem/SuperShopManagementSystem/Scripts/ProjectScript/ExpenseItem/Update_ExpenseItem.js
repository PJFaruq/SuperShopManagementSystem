/// <reference path="~/Themes/bower_components/jquery/dist/jquery.min.js" />
$(document).ready(function () {

    //Check Expense Item Name Availability
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
        var CurrentCategoryName = $("#CurrentCategoryName").val();
        var CurrentItemName = $("#CurrentItemName").val();
        var name = $("#Name").val();
        var category = $("#ExpenseCategoryId").val();
        if (name != "" && category != null) {
            $.ajax({
                url: "/ExpenseItems/CheckExpenseItemName",
                data: { expenseItemName: name, expenseCategory: category },
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

});