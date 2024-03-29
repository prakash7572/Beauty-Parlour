var url = window.location.origin;
function loadData() {
    $.ajax({
        url: "/beauty/service",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            let html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += `<td>${key + 1}</td>`;
                html += `<td>${item.Title}</td>`;
                html += `<td>${item.SubTitle}</td>`;
                html += `<td>${item.Description}</td>`;
                html += `<td><img src="${url}/Content/Image/${item.Image}" widht="40" height="30" /></td>`;
                html += `<td>
                                     <a href="#" data-toggle="modal" data-target="#rightSideModal" onclick="GetService(${item.ID})"><i class="fa fa-edit"></i></a>
                                     <a href="#" onclick="DelService(${item.ID})"><i class="fa fa-trash"></i></a>
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
    $('form#serviceForm').trigger("reset");
    $("#ID").val(0)
}
function GetService(ID) {
    $.ajax({
        url: `/beauty/service?ID=${ID}`,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#Image').prop('required', false);
            $("#Title").val(result[0].Title);
            $("#SubTitle").val(result[0].SubTitle);
            $("#Description").val(result[0].Description);
            $("#ID").val(result[0].ID);
            $("#Img").val(result[0].Image)
        },
        error: function (errormessage) {
            toaster.error(errormessage.responseText);
        }
    });
}
function SubmitService() {

    var data = new FormData();
    data.append("ID", $('#ID').val()),
        data.append("Title", $('#Title').val()),
        data.append("SubTitle", $('#SubTitle').val())
    data.append("Description", $('#Description').val())

    let fileInput = $('#Image')[0].files[0];
    if (fileInput) {
        data.append("Image", fileInput);
    } else {
        data.append("Image", $("#Img").val());
    }
    $.ajax({
        url: "/beauty/service",
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

function DelService(id) {
    showConfirmationDialog("confirmDelete(" + id + ")", "cancelDelete");
}
function confirmDelete(ID) {

    $.ajax({
        url: `/beauty/deleteservice?ID=${ID}`,
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