﻿/// <reference path="../../jquery-1.10.2.min.js" />


$(document).ready(function () {

    //Parent Category Hide
    $("#ParentCategoryDiv").hide();
    $("input[name='Category']").on("change", function () {

        var radioBtnValue = $("input[name='Category']:checked").val();
        if (radioBtnValue == "RootCategory") {
            $("#ParentCategoryDiv").hide();
        }
        if (radioBtnValue == "ChildCategory") {
            $.ajax({
                url: "/ItemCategories/GetParentCategories",
                type: "post",
                data: "",
                success: function (response) {
                    if (response != null) {
                        $("#ParentId").empty();
                        $("#ParentId").html("<option>---Select Option---</Option>");
                        $.each(response, function (index, value) {

                            $("#ParentId").append("<option value='" + value.Id + "'>" + value.Name + "</option>");
                        });
                    }
                }
            });

            $("#ParentCategoryDiv").show();
        }
    })


    //Random Code Generating 
    $("#Name").focus(function () {
        $.ajax({
            url: "/ItemCategories/GetCategoryCode",
            method: "post",
            data: "",
            success: function (response) {
                $("input[name='Code']").val(response);
            }
        });
    });


    //Check Category Name Availability
    $("#Name").blur(function () {
        var name = $("input[name='Name']").val();
        $.ajax({
            url: "/ItemCategories/CheckCategoryName",
            method: "post",
            data: { data : name },
            success: function (response) {
                if (response == 1) {
                    $("#ErrorMsg").html("This Category Name is Already Exist");
                    $("#btnSubmit").attr("disabled", "true");
                }
                if (response == 0) {
                    $("#btnSubmit").removeAttr("disabled");
                    $("#btnSubmit").attr("enabled", "true");
                    $("#ErrorMsg").empty();
                    
                }
            }
        });
    });


   

});


//Image Preview
$("#Image").change(function () {
    var file = this.files;
    if (file && file[0]) {
        ReadImage(file[0]);
    }
});
var ReadImage = function (file) {
    var reader = new FileReader;
    var image = new Image;
    reader.readAsDataURL(file);
    reader.onload = function (_file) {
        image.src = _file.target.result;
        $("#TargetImage").attr("src", _file.target.result);
        image.onload = function () {
            var height = this.height;
            var width = this.width;
            var type = file.type;
            
            var value = (file.size / 1024)
            var size = Math.round(value * 100) / 100+ " KB";

            $("#TargetImage").attr("src", _file.target.result);
            $("#Imagedescription").html("Size: " + size +'</br>'+"Dimension: " + height + " × " + width);
            $("#imagePreview").show();
        }
    }
}

