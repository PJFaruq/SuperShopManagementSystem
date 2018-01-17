/// <reference path="~/Themes/bower_components/jquery/dist/jquery.min.js" />

//Delete an Item
var GetDeleteId = function (Id) {
    $("#DeleteId").val(Id);
    $("#myModal").modal("show");
}

$("#btnConfirmDelete").on("click", function () {
    var deleteId = $("#DeleteId").val();
    $.ajax({
        url: "/ExpenseItems/Delete",
        data: { id: deleteId },
        method: "post",
        success: function (response) {
            if (response == 1) {
                $("#myModal").modal("hide");
                $("#DelRow_" + deleteId).remove();
            }
        }
    })
})