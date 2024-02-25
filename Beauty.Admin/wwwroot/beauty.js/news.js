var style = `style="font-size:20px"`;
var url = window.location.origin;
function loadData() {
    $.ajax({
        url: "/beauty/news",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            let html = '';
            $.each(result, function (key, item) {
                html += `<tr>`;
                html += `<td>${key + 1}</td>`;
                html += `<td>${item.SubTitle}</td>`;
                html += `<td>${item.Description}</td>`;
                html += `<td><img src="${url}/Content/Image/${item.Image}" widht="40" height="30" /></td>`;
                html += `<td>${item.MakeupType == true ? `<i class="fas fa-check-square" ${style} ></i>` : `<i class="fas fa-square-full" ${style}></i>`}</td>`;
                html += `<td>
                          <a href="#" data-toggle="modal" data-target="#rightSideModal" onclick="GetNews(${item.ID})"><i class="fa fa-edit" ${style}></i></a>
                          <a href="#" onclick="DelNews(${item.ID})"><i class="fa fa-trash" ${style}></i></a>
                          </td>`;
                html += '</tr>';
            });
            $('#newslist').html(html);
        },
        error: function (errormessage) {
            toaster.error(errormessage.responseText);
        }
    });
}
loadData();
function Clear() {
    $('form#newsForm').trigger("reset");
}
function GetNews(id) {
    $.ajax({
        url: `/beauty/news?id=${id}`,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $("#Image").attr("required", false);
            $("#SubTitle").val(result[0].SubTitle);
            $("#Img").val(result[0].Image);
            $("#Description").val(result[0].Description);
            $("#ID").val(result[0].ID);
            if (result[0].MakeupType == true ? $("#MakeupType").prop("checked", true) : $("#MakeupType").prop("cheked", false));
        },
        error: function (errormessage) {
            toaster.error(errormessage.responseText);
        }
    });
}
function SubmitNews() {

    var status;
    if ($('#MakeupType').is(":checked")) { status = true; } else { status = false; }
    var data = new FormData();
    data.append("ID", $('#ID').val());
    data.append("SubTitle", $('#SubTitle').val());
    data.append("Description", $('#Description').val());
    data.append("MakeupType", status);

    let fileInput = $("#Image")[0].files[0];
    if (fileInput) {
        data.append("Image", fileInput);
    } else {
        data.append("Image", $("#Img").val());
    }
    $.ajax({
        url: "/beauty/news",
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

function DelNews(id) {
    showConfirmationDialog("confirmDelete(" + id + ")", "cancelDelete");
}

function confirmDelete(id) {

    $.ajax({
        url: `/beauty/deletenews?id=${id}`,
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