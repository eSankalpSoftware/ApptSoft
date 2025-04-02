$(document).ready(function () {
    ddlGetMaintenance();
    GetMaintenance();
    GetMaintenanceAmount();
});

var SaveMaintenace = function () {


    var id = $("#hdnId").val();
    var flatno = $("#txtFlatNo").val();
    var amount = $("#txtAmount").val();
    var transaction = $("#txtTransaction").val();
    var paymentmode = $("#txtPaymentMode").val();
    var month = $("#txtMonth").val();
    var year = $("#txtYear").val();
    var receipt = $("#txtReceipt").val();
    var paiddate = $("#txtPaidDate").val();
    var duedate = $("#txtDueDate").val();
    var createby = $("#txtCreateBy").val();
    var createdate = $("#txtCreateDate").val();
    var updateby = $("#txtUpdateBy").val();
    var updatedate = $("#txtUpdateDate").val();

    var model = {
        Id: id,
        FlatNo: flatno,
        Amount: amount,
        TransactionNo: transaction,
        PaymentMode: paymentmode,
        Month: month,
        Year: year,
        Receipt: receipt,
        PaidDate: paiddate,
        DueDate: duedate,
        CreateBy: createby,
        CreateDate: createdate,
        UpdateBy: updateby,
        UpdateDate: updatedate

    };

    $.ajax({
        url: "/Maintenance/SaveMaintenance",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.Message);

        },
        error: function (response) {
            alert(response.Message);
        }
    });
}



var GetMaintenance = function () {

    $.ajax({
        url: "/Maintenance/GetMaintenance?Year=" + $("#txtYear1").val() + "&month=" + $("#txtMonth1").val(),
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {

            var html = "";
            var amount = 0;
            $("#tblMaintenance tbody").empty();
            $.each(response.Message, function (MaintenanceIndex, elementvalue) {
                amount = parseInt(amount) + parseInt(elementvalue.Amount)
                html += "<tr><td>"
                    + elementvalue.FlatNo + "</td><td>"
                    /* + elementvalue.Id + "</td><td>"*/
                    + elementvalue.Month + "</td><td>"
                    + elementvalue.Year + "</td><td>"
                    + elementvalue.Amount + "</td><td>"
                    + elementvalue.PaymentMode + "</td><td>"
                    + elementvalue.PaidDate + "</td><td>"
                    + elementvalue.DueDate + "</td>><td</td ><td><input type ='submit' class='btn btn-danger' value = 'Delete' onclick='DeleteMaintenance(" + elementvalue.Id + ")'/></td><td><input type='submit' class='btn btn-success' value='Edit' onclick='EditMaintenance(" + elementvalue.Id + ")'/></td></tr > ";

            });
            $("#tblMaintenance tbody").append(html);
            $("#lblamount").text("Total Amount = " + amount);
           
        }

    });

}


var GetMaintenanceAmount = function () {

  

    $.ajax({
        url: "/Maintenance/GetMaintenance",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {

            var html = "";
            var amount = 0;
            $("#tblMaintenance tbody").empty();
            $.each(response.Message, function (MaintenanceIndex, elementvalue) {
                amount = parseInt(amount) + parseInt(elementvalue.Amount)
                html += "<tr><td>"
                    + elementvalue.FlatNo + "</td><td>"
                    /* + elementvalue.Id + "</td><td>"*/
                    + elementvalue.Month + "</td><td>"
                    + elementvalue.Year + "</td><td>"
                    + elementvalue.Amount + "</td><td>"
                    + elementvalue.PaymentMode + "</td><td>"
                    + elementvalue.PaidDate + "</td><td>"
                    + elementvalue.DueDate + "</td>><td</td ><td><input type ='submit' class='btn btn-danger' value = 'Delete' onclick='DeleteMaintenance(" + elementvalue.Id + ")'/></td><td><input type='submit' class='btn btn-success' value='Edit' onclick='EditMaintenance(" + elementvalue.Id + ")'/></td></tr > ";

            });
            $("#tblMaintenance tbody").append(html);
            $("#lblamount").text("Total Amount = " + amount);
            $("#lblPaidamount2").text(amount + "/-");
        }

    });

}


var ddlGetMaintenance = function () {



    $.ajax({
        url: "/Resident/GetResident",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblMaintenance tbody").empty();
            html += "<option value='1'>Select Flat No </option>";

            $.each(response.message, function (MaintenanceIndex, elementValue) {
                html += "<option value='" + elementValue.FlatNo + "'>" + elementValue.FlatNo + "</option>";

            });
            $("#txtFlatNo").append(html);
        }

    });

}



var DeleteMaintenance = function (Id) {

    var model = { Id: Id };
    $.ajax({
        url: "/Maintenance/DeleteMaintenance",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            alert("Record Deleted Successfully");
        }
    });
}

var EditMaintenance = function (Id) {

    var model = { Id: Id };
    $.ajax({
        url: "/Maintenance/EditMaintenance",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {

            var pdate = response.model.PaidDate.split("-");
            var paid = pdate[2] + "-" + pdate[1] + "-" + pdate[0];

            var ddate = response.model.DueDate.split("-");
            var due = ddate[2] + "-" + ddate[1] + "-" + ddate[0];

            $("#hdnId").val(response.model.Id);
            $("#txtMonth").val(response.model.Month);
            $("#txtYear").val(response.model.Year);
            $("#txtFlatNo").val(response.model.FlatNo);
            $("#txtTransaction").val(response.model.TransactionNo);
            $("#txtAmount").val(response.model.Amount);
            //$("#txtReceipt").val(response.model.Receipt);
            $("#txtPaymentMode").val(response.model.PaymentMode);
            $("#txtPaidDate").val(paid);
            $("#txtDueDate").val(due);
            $("#txtCreateBy").val(response.model.CreateBy);
            $("#txtCreateDate").val(response.model.CreateDate);
            $("#txtUpdateDate").val(response.model.UpdateBy);
            $("#txtUpdateDate").val(response.model.UpdateDate);


        }
    });
}
var MonthChangeEvent = function () {
    $("#txtYear1").val("");
    GetMaintenance();
}
var yearchangeenven = function () {

    if ($("#txtMonth1").val() == "") {
        alert("Please Select Month!");
        $("#txtYear1").val("");
        return false();
    }

    GetMaintenance();
}

//var IsValidMonthYear = function () {

//    if (FlatNo.month == $("#txtMonth").val() && FlatNo.year == $("#txtYear").val()) {
//        alert("Dont Enter");
//        return false();
//    }
//    else {
//        SaveMaintenace();
//    }

//}