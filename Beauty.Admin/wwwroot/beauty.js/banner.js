//...............Start banner.................//
var style = `style="font-size:20px"`;
var url = window.location.origin;
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
                    html += `<td>${item.Title}</td>`;
                    html += `<td><img src="${url}/Content/Image/${item.Image}" widht="40" height="30" /></td>`;
                    html += `<td>
                                 <a href="#" data-toggle="modal" data-target="#rightSideModal" onclick="GetBanner(${item.id})"><i class="fa fa-edit"></i></a>
                                 <a href="#" onclick="DelBanner(${item.ID})"><i class="fa fa-trash"></i></a>
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
                $("#Title").val(result[0].Title);
                $("#Img").val(result[0].Image);
                $("#ID").val(result[0].ID);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
function SubmitBanner() {

    var data = new FormData();
    data.append("ID", $('#ID').val());
    data.append("Title", $('#Title').val());

    let fileInput = $("#Image")[0].files[0];
    if (fileInput) {
        data.append("Image", fileInput);
    } else {
        data.append("Image", $("#Img").val());
    }
        $.ajax({
            url: "/beauty/banner",
            data: data,
            type: "POST",
            contentType: false,
            processData: false,
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
