function loadData() {
    $.ajax({
        url: "/beauty/news",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += `<td>${key + 1}</td>`;
                html += `<td>${item.subTitle}</td>`;
                html += `<td>${item.description}</td>`;
                html += `<td>${item.image}</td>`;
                html += `<td>${item.makeupType}</td>`;
                html += `<td>
                                     <a href="#" data-toggle="modal" data-target="#rightSideModal" onclick="GetNews(${item.id})"><i class="fa fa-edit"></i></a>
                                     <a href="#" onclick="DelNews(${item.id})"><i class="fa fa-trash"></i></a>
                                     </td>`;
                html += '</tr>';
            });
            $('#newslist').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
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
            $("#SubTitle").val(result[0].subTitle);
            $("#Image").val(result[0].image);
            $("#Description").val(result[0].description);
            $("#ID").val(result[0].id);
            if (result[0].makeupType == true ? $("#MakeupType").prop("cheked", true) : $("#MakeupType").prop("cheked", false));
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function submitNews() {
    var news = {
        ID: $('#ID').val(),
        SubTitle: $('#SubTitle').val(),
        Image: $('#Image').val(),
        Description: $('#Description').val(),
        MakeupType: $("#MakeupType").prop("cheked", true) ? 1 : 0
    };
    $.ajax({
        url: "/beauty/news",
        data: JSON.stringify(news),
        type: "POST",
        contentType: "application/json",
        dataType: "json",
        success: function (result) {
            alert(result.message);
            window.location.href = '/beauty/beautynews';
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
function DelNews(id) {
    if (!confirm("Are you sure you want to delete this Record?")) {
        return false;
    } else {
        $.ajax({
            url: `/beauty/deletenews?id=${id}`,
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