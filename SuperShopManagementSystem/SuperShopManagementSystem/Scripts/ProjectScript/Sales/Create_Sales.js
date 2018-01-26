/// <reference path="~/Themes/bower_components/jquery/dist/jquery.min.js" />
$(document).ready(function () {
    $("#SalesDate").datepicker({
        autoclose: true
    });

    $("#btnAdd").click(function (e) {
        CheckValidation();
        $("#ErrorMsgs").html("");
        CreateRowForSales();
        $("#ItemId").val("");
        $("#Quantity").val("");
        $("#ItemPrice").val("");
        $("#Stock").val("");
        $("#ErrorForTableRow").html("");
        

    });

    function CreateRowForSales() {
        var selectedItem = GetSelectedItem();
        
        var index = $("#SalesItemList").children("tr").length;

        var itemCell = "<td class='item' id='" + selectedItem.ItemId + "'>" + selectedItem.ItemText + "</td>";
        var priceCell = "<td class='price'>" + selectedItem.ItemPrice + "</td>";
        var quantityCell = "<td class='quantity'>" + selectedItem.Quantity + "</td>";
        var totalCell = "<td class='total'>" + selectedItem.Total + "</td>";
        var actionCell = "<td>" + "<input type='button' class='btn btn-danger' value='Remove' onclick='GetDeleteId(" + index + ")' id='" + index + "'/>" + "</td>";
        $("#SalesItemList").append("<tr id='DelRow_" + index + "'>" + itemCell + priceCell + quantityCell + totalCell + actionCell + "</tr>");
        SubTotalAmount();
        GrandTotalAmount();


    }

    function GetSelectedItem() {
        var item = $("#ItemId").val();
        var price = $("#ItemPrice").val();
        var quantity = $("#Quantity").val();
        var itemText = $("#ItemId option:selected").text();
        var total = quantity*price;

        var item = {
            "ItemId": item,
            "ItemPrice": price,
            "Quantity": quantity,
            "ItemText": itemText,
            "Total":total
        }
        return item;
    }

    $("#btnSubmit").click(function () {
        var index = $("#SalesItemList").children("tr").length;
        $("#SalesItemList tr ").each(function (index, value) {

            var ItemId = ($(this).find(".item").attr("id"));
            var Quantity = ($(this).find(".quantity").html());
            var Price = ($(this).find(".price").html());
            var Total = ($(this).find(".total").html());

            var bindexCell = "<input type='hidden' id='Index" + index + "' name='SalesDetails.index' value='" + index + "'/>"
            var bitem = "<input type='hidden' id='ItemId" + index + "' name='SalesDetails[" + index + "].ItemId' value='" + ItemId + "'/>"
            var bQuantity = "<input type='hidden' id='Quantity" + index + "' name='SalesDetails[" + index + "].Quantity' value='" + Quantity + "'/>"
            var bPrice = "<input type='hidden' id='Price" + index + "' name='SalesDetails[" + index + "].Price' value='" + Price + "'/>"
            var bTotal = "<input type='hidden' id='Total" + index + "' name='SalesDetails[" + index + "].Total' value='" + Total + "'/>"

            $("#bindValue").append(bindexCell, bitem, bQuantity, bPrice, bTotal);


        });

    }); 

    //Get Item Price And Stock
    $("#ItemId").on("change", function () {

        var salesQuantity = 0;
        $("#SalesItemList tr ").each(function (index, value) {
            var Quantity =parseInt( ($(this).find(".quantity").html()));
            salesQuantity = salesQuantity + Quantity;

        });


        var id = $(this).val();
        $.ajax({
            url: "/Sales/GetItemSalesPrice",
            type: "post",
            data: { id: id },
            success: function (response) {
                $("#ItemPrice").val(response)

            }
        });

        $.ajax({
            url: "/Sales/GetItemStock",
            type: "post",
            data: { id: id },
            success: function (response) {
                var stock = parseInt(response);
                var availabeStock = stock - salesQuantity;
                if (availabeStock <= 0) {
                    $("#Stock").val(0)
                }
                else {
                    $("#Stock").val(availabeStock)
                }
                

            }
        });
    });


    //Validation for Add Item
    function CheckValidation() {
        $("#ErrorMsgForItem").html("");
        $("#ErrorMsgForQuantity").html("");
        $("#ErrorMsgForStock").html("");

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
        var stock = parseInt($("#Stock").val());
        var quantity = parseInt($("#Quantity").val());
        if (stock <= 0) {
            $("#ErrorMsgForStock").html("Item Stock is not Available");
            return e.preventDefault();
        }
        if (stock < quantity) {
            $("#ErrorMsgForQuantity").html("Out of Stock");
            return e.preventDefault();
        }

    }

    $("#form").submit(function () {
        return formValidation();
    });

    $("#VAT").blur(function () {
        var value=$(this).val();
        if ( value== "" || value== undefined) {
            $(this).val(0);
        }
        GrandTotalAmount();
        
    });

    $("#AmountDue").blur(function () {
        var value = $(this).val();
        if (value == "" || value == undefined) {
            $(this).val(0);
        }

    });
    $("#Discount").blur(function () {
        var value = $(this).val();
        if (value == "" || value == undefined) {
            $(this).val(0);
        }
        GrandTotalAmount();

    });
});


//Delete an Item from the List
var GetDeleteId = function (Id) {
    $("#DelRow_" + Id).remove();
    SubTotalAmount();
    GrandTotalAmount();
}


//Validation for Submit Button
function formValidation() {
    var outlet = $("#OutletId").val();
    var employee = $("#EmployeeId").val();

    $("#ErrorForOutlet").html("");
    $("#ErrorForEmployee").html("");
   
    $("#ErrorForTableRow").html("");
    var tableRowNumber = $("#SalesItemList").children("tr").length;

    if (outlet == "") {
        $("#ErrorForOutlet").html("Select an Outlet");
        return false;
    }

    if (employee == "") {
        $("#ErrorForEmployee").html("Select an Employee");
        return false;
    }

    if (tableRowNumber <= 0) {

        $("#ErrorForTableRow").html("Please Select Some Item to Sale");
        return false;
    }

}


//Total Sub Total Calculation
function SubTotalAmount() {
    var sumOfTotal = 0;
    if ($("#SalesItemList").children("tr").length == 0) {
        $("#SubTotal").val("");
    }
    else {
        $("#SalesItemList tr ").each(function (index, value) {
            var Total = parseFloat(($(this).find(".total").html()));
            sumOfTotal = sumOfTotal + Total;
            $("#SubTotal").val(sumOfTotal);

        });
    }

}

//Grand Total Calculation
function GrandTotalAmount() {
    var subTotal = $("#SubTotal").val();
    var discount = $("#Discount").val();
    var VAT = $("#VAT").val();

    if (discount == "" || discount==undefined) {
        discount = 0;
    }
    if (VAT == "" || VAT == undefined) {
        VAT = 0;
    }
     discount=parseFloat(discount);
     VAT = parseFloat(VAT);
     subTotal = parseFloat(subTotal);

    if(subTotal !=null && discount !=null && VAT !=null){
        var grandTotal = subTotal+subTotal*(VAT/100)-discount;
        $("#Total").val(grandTotal);
    }

}



