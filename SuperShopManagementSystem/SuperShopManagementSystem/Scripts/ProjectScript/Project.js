/// <reference path="~/Themes/bower_components/jquery/dist/jquery.min.js" />


$(document).ready(function () {

    $(".search-table").DataTable({
        'paging': true,
        'lengthChange': true,
        'searching': true,
        'ordering': true,
        'info': true,
        'autoWidth': true
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
            var size = Math.round(value * 100) / 100 + " KB";

            $("#TargetImage").attr("src", _file.target.result);
            $("#Imagedescription").html("Size: " + size + '</br>' + "Dimension: " + height + " × " + width);
            $("#imagePreview").show();
        }
    }
}




























