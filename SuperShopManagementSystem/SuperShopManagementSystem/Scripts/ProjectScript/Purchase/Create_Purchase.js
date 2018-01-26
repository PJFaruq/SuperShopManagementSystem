/// <reference path="~/Themes/bower_components/jquery/dist/jquery.min.js" />
$(document).ready(function () {

    $("#PurchaseDate").datepicker({
        autoclose: true
    });

    $("#btnAdd").click(function (e) {
        CheckValidation();
        $("#ErrorMsgs").html("");
        CreateRowForPurchase();
        $("#ItemId").val("") ;
        $("#Quantity").val("") ;
        $("#ItemPrice").val("");   
    });

    function CreateRowForPurchase() {
        var selectedItem = GetSelectedItem();
        var total = selectedItem.Quantity * selectedItem.ItemPrice;
        var index = $("#PurchaseItemList").children("tr").length;
        var sl = index;

        var serialCell = "<td class='serial'>" + sl + "</td>";
        var itemCell = "<td class='item' id='"+selectedItem.ItemId+"'>" + selectedItem.ItemText + "</td>";
        var priceCell = "<td class='price'>" + selectedItem.ItemPrice + "</td>";
        var quantityCell = "<td class='quantity'>" + selectedItem.Quantity + "</td>";
        var totalCell = "<td class='total'>" + total + "</td>";
        var actionCell = "<td>" + "<input type='button' class='btn btn-danger' value='Remove' onclick='GetDeleteId("+index+")' id='" + index + "'/>" + "</td>";
        $("#PurchaseItemList").append("<tr id='DelRow_" + index + "'>" + serialCell + itemCell + priceCell + quantityCell + totalCell + actionCell + "</tr>");
        TotalAmount();
        

    }

    function GetSelectedItem() {
        var item = $("#ItemId").val();
        var price = $("#ItemPrice").val();
        var quantity = $("#Quantity").val();
        var itemText = $("#ItemId option:selected").text();

        var item = {
            "ItemId": item,
            "ItemPrice": price,
            "Quantity": quantity,
            "ItemText":itemText
        }
        return item;
    }

    $("#btnSubmit").click(function () {
        var index = $("#PurchaseItemList").children("tr").length;
        $("#PurchaseItemList tr ").each(function (index, value) {
           
            var ItemId = ($(this).find(".item").attr("id"));
            var Quantity = ($(this).find(".quantity").html());
            var Price=($(this).find(".price").html());
            var Total = ($(this).find(".total").html());

            var bindexCell = "<input type='hidden' id='Index" + index + "' name='PurchaseDetails.index' value='" + index + "'/>"
            var bitem = "<input type='hidden' id='ItemId" + index + "' name='PurchaseDetails[" + index + "].ItemId' value='" + ItemId + "'/>"
            var bQuantity = "<input type='hidden' id='Quantity" + index + "' name='PurchaseDetails[" + index + "].Quantity' value='" + Quantity + "'/>"
            var bPrice = "<input type='hidden' id='Price" + index + "' name='PurchaseDetails[" + index + "].Price' value='" + Price + "'/>"
            var bTotal = "<input type='hidden' id='Total" + index + "' name='PurchaseDetails[" + index + "].Total' value='" + Total + "'/>"

            $("#bindValue").append(bindexCell, bitem, bQuantity, bPrice, bTotal);

            
        })

    });

    $("#ItemId").on("change", function () {
        var id=$(this).val();
        $.ajax({
            url: "/Purchases/GetItemPurchasePrice",
            type: "post",
            data:{id:id},
            success: function (response) {
                $("#ItemPrice").val(response)

            }
        });
    });

    function CheckValidation() {

        var numberRegex = /[0-9 -()+]+$/;
        if ($("#ItemId").val() == "") {
            $("#ErrorMsgs").html("***Please Select an Item")
            return e.preventDefault();
        }
        if ($("#Quantity").val() == "") {
            $("#ErrorMsgs").html("***Please Enter Quantity")
            return e.preventDefault();
        }
        if (!numberRegex.test($("#Quantity").val())) {
            $("#ErrorMsgs").html("***Please Enter Valid Quantity")
            return e.preventDefault();
        }
    }

    $("#form").submit(function () {
       return formValidation();
    })
});
var GetDeleteId = function (Id) {
    $("#DelRow_" + Id).remove();
    TotalAmount();
    
}

function TotalAmount() {
    var sumOfTotal = 0;
    if ($("#PurchaseItemList").children("tr").length == 0) {
        $("#Total").val(0);
    }
    else {
        $("#PurchaseItemList tr ").each(function (index, value) {
            var Total = parseFloat(($(this).find(".total").html()));
            sumOfTotal = sumOfTotal + Total;
            $("#Total").val(sumOfTotal);

        });
    }
    
}

function formValidation() {
    var outlet = $("#OutletId").val();
    var employee = $("#EmployeeId").val();
    var party = $("#PartyId").val();
    $("#ErrorForOutlet").html("");
    $("#ErrorForEmployee").html("");
    $("#ErrorForParty").html("");
    $("#ErrorForTableRow").html("");
    var tableRowNumber = $("#PurchaseItemList").children("tr").length;

    if (outlet == "") {
        $("#ErrorForOutlet").html("Select an Outlet");
        return false;
    }

    if (employee == "") {
        $("#ErrorForEmployee").html("Select an Employee");
        return false;
    }
    if (party == "") {
        $("#ErrorForParty").html("Select a Supplier");
        return false;
    }

    if (tableRowNumber <= 0) {
        
        $("#ErrorForTableRow").html("Please Select Some Item to Purchase");
        return false;
    }

}