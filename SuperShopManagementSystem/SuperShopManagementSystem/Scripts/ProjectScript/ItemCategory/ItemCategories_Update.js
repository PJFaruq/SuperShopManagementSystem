/// <reference path="~/Themes/bower_components/jquery/dist/jquery.min.js" />


$(document).ready(function () {
    $("#form").onload(function () {
        var parentId = $("#ParentId").val();
        if (parentId != null) {
            $('input:radio[name=Category]')[2].checked = true;
        }
    })


    
    
})