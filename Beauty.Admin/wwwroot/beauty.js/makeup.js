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
                    html += `<td>${item.Title}</td>`;
                    html += `<td>${item.FaFaImg}</td>`;
                    html += `<td>${item.Description}</td>`;
                    html += `<td>
                                 <a href="#" data-toggle="modal" data-target="#rightSideModal" onclick="GetMakeup(${item.ID})"><i class="fa fa-edit"></i></a>
                                 <a href="#" onclick="DelMakeup(${item.ID})"><i class="fa fa-trash"></i></a>
                                 </td>`;
                    html += '</tr>';
                });
                $('#makeuplist').html(html);
            },
            error: function (errormessage) {
                toaster.error(errormessage.responseText);
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
                $("#Title").val(result[0].Title);
                $("#Fa-Fa-Icon").val(result[0].FaFaImg);
                $("#Description").val(result[0].Description);
                $("#ID").val(result[0].ID);
            },
            error: function (errormessage) {
                toaster.error(errormessage.responseText);
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
                    toastr.success(result.message, 'Success');
                    loadData();
                },
                error: function (errormessage) {
                    toaster.error(errormessage.responseText);
                }
            });
        };
    }
//...............End makeup.................//
