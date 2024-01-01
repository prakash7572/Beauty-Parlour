//...............Start banner.................//

    function loadData() {
        $.ajax({
            url: "/beauty/banner",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                var html = '';
                $.each(result, function (key, item) {
                    html += '<tr>';
                    html += `<td>${key + 1}</td>`;
                    html += `<td>${item.title}</td>`;
                    html += `<td>${item.image}</td>`;
                    html += `<td>
                                 <a href="#" data-toggle="modal" data-target="#rightSideModal" onclick="GetBanner(${item.id})"><i class="fa fa-edit"></i></a>
                                 <a href="#" onclick="DelBanner(${item.id})"><i class="fa fa-trash"></i></a>
                                 </td>`;
                    html += '</tr>';
                });
                $('#bannerlist').html(html);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    loadData();
    function Clear() {
        $('form#bannerForm').trigger("reset");
        $('#ID').val(0);
    }
function GetBanner(id) {
        $.ajax({
            url: `/beauty/banner?id=${id}`,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                $("#Title").val(result[0].title);                
                $("#Image").val(result[0].image);
                $("#ID").val(result[0].id);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
function submitBanner() {
        var banner = {
            ID: $('#ID').val(),
            Title: $('#Title').val(),
            Image: $('#Image').val(),
        };
        $.ajax({
            url: "/beauty/banner",
            data: JSON.stringify(banner),
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            success: function (result) {
                alert(result.message);
                window.location.href = '/beauty/beautybanner';
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
        return false;
    }
function DelBanner(id) {
        if (!confirm("Are you sure you want to delete this Record?")) {
            return false;
        } else {
            $.ajax({
                url: `/beauty/deletebanner?id=${id}`,
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
//...............End banner.................//
