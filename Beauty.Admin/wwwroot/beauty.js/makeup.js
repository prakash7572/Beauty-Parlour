//...............Start makeup.................//

    function loadData() {
        $.ajax({
            url: "/beauty/makeup",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                var html = '';
                $.each(result, function (key, item) {
                    html += '<tr>';
                    html += `<td>${key + 1}</td>`;
                    html += `<td>${item.title}</td>`;
                    html += `<td>${item.faFaImg}</td>`;
                    html += `<td>${item.description}</td>`;
                    html += `<td>
                                 <a href="#" data-toggle="modal" data-target="#rightSideModal" onclick="GetMakeup(${item.id})"><i class="fa fa-edit"></i></a>
                                 <a href="#" onclick="DelMakeup(${item.id})"><i class="fa fa-trash"></i></a>
                                 </td>`;
                    html += '</tr>';
                });
                $('#makeuplist').html(html);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    loadData();
    function Clear() {
        $('form#MakeupForm').trigger("reset");
        $("#ID").val(0);
    }
function GetMakeup(id) {
        $.ajax({
            url: `/beauty/makeup?id=${id}`,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                $("#Title").val(result[0].title);
                $("#Fa-Fa-Icon").val(result[0].faFaImg);
                $("#Description").val(result[0].description);
                $("#ID").val(result[0].id);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
function submitMakeup() {
        var makeup = {
            ID: $('#ID').val(),
            Title: $('#Title').val(),
            FaFaImg: $("#Fa-Fa-Icon").val(),
            Description: $('#Description').val()
        };
        $.ajax({
            url: "/beauty/makeup",
            data: JSON.stringify(makeup),
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            success: function (result) {
                alert(result.message);
                window.location.href = '/beauty/beautymakeup';
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
        return false;
    }
function DelMakeup(id) {
        if (!confirm("Are you sure you want to delete this Record?")) {
            return false;
        } else {
            $.ajax({
                url: `/beauty/deletemakeup?id=${id}`,
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
//...............End makeup.................//
