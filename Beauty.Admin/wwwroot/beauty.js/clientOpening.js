//...............Start Aboutus.................//
var url = window.location.origin;
function loadData() {
    $.ajax({
        url: "/beauty/clientopening",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            let html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += `<td>${key + 1}</td>`;
                html += `<td>${item.SubTitle}</td>`;
                html += `<td>${item.Description}</td>`;
                html += `<td>${item.Destination}</td>`;
                html += `<td><img src="${url}/Content/Image/${item.Image}" widht="40" height="30" /></td>`;
                html += `<td>
                                 <a href="#" data-toggle="modal" data-target="#rightSideModal" onclick="GetClient(${item.ID})"><i class="fa fa-edit"></i></a>
                                 <a href="#" onclick="DelClient(${item.ID})"><i class="fa fa-trash"></i></a>
                                 </td>`;
                html += '</tr>';
            });
            $('#list').html(html);
        },
        error: function (errormessage) {
            toaster.error(errormessage.responseText);
        }
    });
}
loadData();
function ClearForm() {
    $('form#ClientOpeningForm').trigger("reset");
    $('#ID').val(0);
}
function GetClient(id) {
    $.ajax({
        url: `/beauty/clientopening?id=${id}`,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#Image').prop('required', false);
            $("#SubTitle").val(result[0].SubTitle);
            $("#Img").val(result[0].Image);
            $("#Description").val(result[0].Description);
            $("#Destination").val(result[0].Destination);
            $("#ID").val(result[0].ID);
        },
        error: function (errormessage) {
            toaster.error(errormessage.responseText);
        }
    });
}

function SubmitClient() {

    var data = new FormData();
    data.append("ID", $('#ID').val());
    data.append("Destination", $('#Destination').val());
    data.append("SubTitle", $('#SubTitle').val());
    data.append("Description", $('#Description').val());

    let fileInput = $('#Image')[0].files[0];
    if (fileInput) {
        data.append("Image", fileInput);
    } else {
        data.append("Image", $("#Img").val());
    }
    $.ajax({
        url: "/beauty/clientopening",
        data: data,
        type: "POST",
        contentType: false,
        processData: false,
        success: function (result) {
            toastr.success(result.message, 'Success');
            $('[data-dismiss="modal"]').trigger('click');
            loadData();
        },
        error: function (errormessage) {
            toaster.error(errormessage.responseText);
        }
    });
    return false;
}

function DelClient(id) {
    showConfirmationDialog("confirmDelete(" + id + ")", "cancelDelete");
}
function confirmDelete(id) {
    $.ajax({
        url: `/beauty/deleteclientopening?id=${id}`,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            toastr.success(result.message, 'Success');
            loadData();
        },
        error: function (errormessage) {
            toaster.error(errormessage.responseText);
        }
    });

}

//...............End Aboutus.................//
