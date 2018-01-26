/// <reference path="~/Themes/bower_components/jquery/dist/jquery.min.js" />
$(document).ready(function () {


    //Date Picker
    $("#Date").datepicker({
        autoclose: true
    });

    $("#btnAdd").click(function (e) {
        CheckValidation();
        $("#ErrorMsgs").html("");
        CreateRowForPurchase();
        $("#ItemId").val("");
        $("#Quantity").val("");
        $("#ItemPrice").val("");
    });


    //Create row for item
    function CreateRowForPurchase() {
        var selectedItem = GetSelectedItem();
        var index = $("#PurchaseItemList").children("tr").length;


        var itemCell = "<td class='item' id='" + selectedItem.ItemId + "'>" + selectedItem.ItemText + "</td>";
        var priceCell = "<td class='price'>" + selectedItem.ItemPrice + "</td>";
        var quantityCell = "<td class='quantity'>" + selectedItem.Quantity + "</td>";
        var lineTotalCell = "<td class='lineTotal'>" + selectedItem.LineTotal + "</td>";
        var reasonCell = "<td class='reason'>" + selectedItem.Reason + "</td>";
        var actionCell = "<td>" + "<input type='button' class='btn btn-danger' value='Remove' onclick='GetDeleteId(" + index + ")' id='" + index + "'/>" + "</td>";
        $("#ExpenseItemList").append("<tr id='DelRow_" + index + "'>" + itemCell + priceCell + quantityCell + lineTotalCell+reasonCell + actionCell + "</tr>");
        TotalAmount();


    }


    //Get item value
    function GetSelectedItem() {
        var item = $("#ItemId").val();
        var price = $("#ItemPrice").val();
        var quantity = $("#Quantity").val();
        var reason = $("#Reason").val();
        var itemText = $("#ItemId option:selected").text();
        var lineTotal = parseFloat(quantity) * parseFloat(price);

        var item = {
            "ItemId": item,
            "ItemPrice": price,
            "Quantity": quantity,
            "Reason":reason,
            "ItemText": itemText,
            "LineTotal":lineTotal
        }
        return item;
    }


    //Binding Expense Detail Value
    $("#btnSubmit").click(function () {
        var index = $("#ExpenseItemList").children("tr").length;
        $("#ExpenseItemList tr ").each(function (index, value) {

            var ItemId = ($(this).find(".item").attr("id"));
            var Quantity = ($(this).find(".quantity").html());
            var Price = ($(this).find(".price").html());
            var LineTotal = ($(this).find(".lineTotal").html());
            var Reason = ($(this).find(".reason").html());

            var bindexCell = "<input type='hidden' id='Index" + index + "' name='ExpenseDetails.index' value='" + index + "'/>"
            var bitem = "<input type='hidden' id='ItemId" + index + "' name='ExpenseDetails[" + index + "].ExpenseItemId' value='" + ItemId + "'/>"
            var bQuantity = "<input type='hidden' id='Quantity" + index + "' name='ExpenseDetails[" + index + "].Quantity' value='" + Quantity + "'/>"
            var bPrice = "<input type='hidden' id='Price" + index + "' name='ExpenseDetails[" + index + "].Amount' value='" + Price + "'/>"
            var bLineTotal = "<input type='hidden' id='LineTotal" + index + "' name='ExpenseDetails[" + index + "].LineTotal' value='" + LineTotal + "'/>"
            var bReason = "<input type='hidden' id='Reason" + index + "' name='ExpenseDetails[" + index + "].Reason' value='" + Reason + "'/>"

            $("#bindValue").append(bindexCell, bitem, bQuantity, bPrice, bLineTotal, bReason);


        })

    });



    //Validation while adding Item
    function CheckValidation() {

        $("#ErrorMsgForItem").html("");
        $("#ErrorMsgForQuantity").html("");
        $("#ErrorMsgForItemPrice").html("");

        var numberRegex = /[0-9 -()+]+$/;

        if ($("#ItemId").val() == "") {
            $("#ErrorMsgForItem").html("Please Select an Item")
            return e.preventDefault();
        }
        if ($("#Quantity").val() == "") {
            $("#ErrorMsgForQuantity").html("Please Enter Quantity")
            return e.preventDefault();
        }

        if (!numberRegex.test($("#Quantity").val())) {
            $("#ErrorMsgForQuantity").html("Please Enter Valid Quantity")
            return e.preventDefault();
        }
        if ($("#ItemPrice").val() == "") {
            $("#ErrorMsgForItemPrice").html("Please Enter Price")
            return e.preventDefault();
        }

        if (!numberRegex.test($("#ItemPrice").val())) {
            $("#ErrorMsgForItemPrice").html("Please Enter Valid Price")
            return e.preventDefault();
        }
    }

    //form validation
    $("#form").submit(function () {
        return formValidation();
    })
});


//Remove a Row
var GetDeleteId = function (Id) {
    $("#DelRow_" + Id).remove();
    TotalAmount();

}

function TotalAmount() {
    var sumOfTotal = 0;
    if ($("#ExpenseItemList").children("tr").length == 0) {
        $("#Total").val(0);
    }
    else {
        $("#ExpenseItemList tr ").each(function (index, value) {
            var Total = parseFloat(($(this).find(".lineTotal").html()));
            sumOfTotal = sumOfTotal + Total;
            $("#Total").val(sumOfTotal);

        });
    }

}

function formValidation() {
    var outlet = $("#OutletId").val();
    var employee = $("#EmployeeId").val();

    $("#ErrorForOutlet").html("");
    $("#ErrorForEmployee").html("");

    $("#ErrorForTableRow").html("");
    var tableRowNumber = $("#ExpenseItemList").children("tr").length;

    if (outlet == "") {
        $("#ErrorForOutlet").html("Select an Outlet");
        return false;
    }

    if (employee == "") {
        $("#ErrorForEmployee").html("Select an Employee");
        return false;
    }

    if (tableRowNumber <= 0) {

        $("#ErrorForTableRow").html("Please Select Some Item to Purchase");
        return false;
    }

}