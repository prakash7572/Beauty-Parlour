    function loadData() {
        $.ajax({
            url: "/beauty/service",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                var html = '';
                $.each(result, function (key, item) {
                    html += '<tr>';
                    html += `<td>${key + 1}</td>`;
                    html += `<td>${item.Title}</td>`;
                    html += `<td>${item.SubTitle}</td>`;
                    html += `<td>${item.Description}</td>`;
                    html += `<td>${item.Image}</td>`;
                    html += `<td>
                                     <a href="#" data-toggle="modal" data-target="#rightSideModal" onclick="GetService(${item.ID})"><i class="fa fa-edit"></i></a>
                                     <a href="#" onclick="DelService(${item.ID})"><i class="fa fa-trash"></i></a>
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
        $('form#serviceForm').trigger("reset");
    }
    function GetService(ID) {
        $.ajax({
            url: `/beauty/service?ID=${ID}`,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                $("#Title").val(result[0].Title);
                $("#SubTitle").val(result[0].SubTitle);
                $("#Image").val(result[0].Image);
                $("#Description").val(result[0].Description);
                $("#ID").val(result[0].ID);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    function SubmitService() {
        var servic = {
            ID: $('#ID').val(),
            Title: $('#Title').val(),
            SubTitle: $('#SubTitle').val(),
            Image: $('#Image').val(),
            Description: $('#Description').val()
        };
        $.ajax({
            url: "/beauty/service",
            data: JSON.stringify(servic),
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            success: function (result) {
                window.location.href = '/beauty/beautyservice';
                alert(result.message);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
        return false;
}
    function DelService(ID) {
    if (!confirm("Are you sure you want to delete this Record?")) {
        return false;
    } else {
        $.ajax({
            url: `/beauty/deleteservice?ID=${ID}`,
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