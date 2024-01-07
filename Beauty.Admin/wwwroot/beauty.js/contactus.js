function loadData() {
    $.ajax({
        url: "/beauty/contactus",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += `<td>${key + 1}</td>`;
                html += `<td>${item.SubTitle}</td>`;
                html += `<td>${item.Address}</td>`;
                html += `<td>${item.Email}</td>`;
                html += `<td>${item.Phone}</td>`;
                html += `<td>
                                 <a href="#" data-toggle="modal" data-target="#rightSideModal" onclick="GetContact(${item.ID})"><i class="fa fa-edit"></i></a>
                                 <a href="#" onclick="DelContact(${item.ID})"><i class="fa fa-trash"></i></a>
                                 </td>`;
                html += '</tr>';
            });
            $('#list').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
loadData();
function Clear() {
    $('form#contactForm').trigger("reset");
    $("#ID").val(0);
}
function GetContact(id) {
    $.ajax({
        url: `/beauty/contactus?id=${id}`,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $("#Phone").val(result[0].Phone);
            $("#SubTitle").val(result[0].SubTitle);
            $("#Email").val(result[0].Email);
            $("#Address").val(result[0].Address);
            $("#ID").val(result[0].ID);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function submitContact() {
    var contactus = {
        ID: $('#ID').val(),
        Phone: $('#Phone').val(),
        SubTitle: $('#SubTitle').val(),
        Email: $('#Email').val(),
        Address: $('#Address').val()
    };
    $.ajax({
        url: "/beauty/contactus",
        data: JSON.stringify(contactus),
        type: "POST",
        contentType: "application/json",
        dataType: "json",
        success: function (result) {
            window.location.href = '/beauty/beautycontactus';
            alert(result.message);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
function DelContact(id) {
    if (!confirm("Are you sure you want to delete this Record?")) {
        return false;
    } else {
        $.ajax({
            url: `/beauty/deletecontactus?id=${id}`,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                alert(result.message);
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    };
}