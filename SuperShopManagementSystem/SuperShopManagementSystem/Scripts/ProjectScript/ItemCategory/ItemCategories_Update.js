
$("#Image").change(function () {
    $("#CurrentImage").hide();
});
$(document).ready(function () {
    //Check Item Name Availability
    var isAvaiable = false;
    $("#form").submit(function () {
        if (isAvaiable == true) {
            return false;
        }
    });
    //Check Category Name Availability
    $("#Name").blur(function () {
        var name = $("input[name='Name']").val();
        var currentCategoryName = $("#CurrentCategoryName").val();
        $.ajax({
            url: "/ItemCategories/CheckCategoryName",
            method: "post",
            data: { data: name },
            success: function (response) {
                if (response == 1) {
                    if (currentCategoryName == name) {
                        isAvaiable = false;
                        $("#ErrorMsg").empty();
                    }
                    else {
                        $("#ErrorMsg").html("This Name Already Exist");
                        isAvaiable = true;
                    }
                    
                }
                if (response == 0) {
                    isAvaiable = false;
                    $("#ErrorMsg").empty();

                }
            }
        });
    });
});

