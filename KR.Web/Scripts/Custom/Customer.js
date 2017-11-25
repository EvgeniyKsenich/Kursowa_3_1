$(".delete").click(AjaxDelete);

function AjaxDelete(event) {
    var url = "/Home/DeleteCustomer"
    var Id = event.target.id.split("_")[1];
    var data = {
        id: Id
    }

    $.ajax({
        type: "POST",
        url: url,
        data: data,
        success: function (response) {
            console.log(response);
            if (response != -1) {
                $("#row_" + Id).remove();
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });

    event.preventDefault();
};