$("#addDifficults").click(AjaxAddDifficults);
$("#addNewWork").click(AjaxAddWork);
$(".deleteDifficults").click(AjaxDeleteDifficults);
$(".deleteWork").click(AjaxDeleteWork);

function AjaxAddDifficults(event) {
    var url = "/Home/AddDifficults"
    var DifficultsId = $("#newDifficults").val();
    var OrderId = $("#orderId").val();
    var data = {
        difficultsId: DifficultsId,
        orderId: OrderId
    }


    $.ajax({
        type: "POST",
        url: url,
        data: data,
        success: function (response) {
            console.log(response);
            if (response != -1) {
                window.location.reload();
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });

    event.preventDefault();
};

function AjaxDeleteDifficults(event) {
    var url = "/Home/DeleteDifficults"
    var DifficultsId = event.target.id;
    var OrderId =  $("#orderId").val();
    var data = {
        difficultsId: DifficultsId,
        orderId: OrderId
    }


    $.ajax({
        type: "POST",
        url: url,
        data: data,
        success: function (response) {
            console.log(response);
            if (response != -1) {
                window.location.reload();
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });

    event.preventDefault();
};


function AjaxAddWork(event) {
    var url = "/Home/AddWork"
    var OrderId = $("#orderId").val();
    var Cuntt = $("#countt").val();
    var Typee = $("#typee").val();
    var Price = $("#price").val();

    var data = {
        orderId: OrderId,
        countt: Cuntt,
        typee: Typee,
        price: Price
    }


    $.ajax({
        type: "POST",
        url: url,
        data: data,
        success: function (response) {
            console.log(response);
            if (response != -1) {
                window.location.reload();
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });
    console.log("send");
    event.preventDefault();
};


function AjaxDeleteWork(event) {
    var url = "/Home/DeleteWork"
    var WorkId = event.target.id;
    var OrderId = $("#orderId").val();
    var data = {
        workId: WorkId,
        orderId: OrderId
    }


    $.ajax({
        type: "POST",
        url: url,
        data: data,
        success: function (response) {
            console.log(response);
            if (response != -1) {
                window.location.reload();
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });

    event.preventDefault();
};