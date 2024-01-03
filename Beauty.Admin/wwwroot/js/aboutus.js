//...............Start Aboutus.................//

    function loadData() {
        $.ajax({
            url: "/beauty/aboutus",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                var html = '';
                $.each(result, function (key, item) {
                    html += '<tr>';
                    html += `<td>${key + 1}</td>`;
                    html += `<td>${item.title}</td>`;
                    html += `<td>${item.subTitle}</td>`;
                    html += `<td>${item.description}</td>`;
                    html += `<td>${item.image}</td>`;
                    html += `<td>
                                 <a href="#" data-toggle="modal" data-target="#rightSideModal" onclick="editAbout(${item.id})"><i class="fa fa-edit"></i></a>
                                 <a href="#" onclick="delAbout(${item.id})"><i class="fa fa-trash"></i></a>
                                 </td>`;
                    html += '</tr>';
                });
                $('#aboutlist').html(html);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    loadData();
    function Clear() {
        $('form#aboutusForm').trigger("reset");
        $('#ID').val(0);
    }
    function editAbout(id) {
        $.ajax({
            url: `/beauty/aboutus?id=${id}`,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                $("#Title").val(result[0].title);
                $("#SubTitle").val(result[0].subTitle);
                $("#Image").val(result[0].image);
                $("#Description").val(result[0].description);
                $("#ID").val(result[0].id);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
    function submitAbout() {
        var aboutus = {
            ID: $('#ID').val(),
            Title: $('#Title').val(),
            SubTitle: $('#SubTitle').val(),
            Image: $('#Image').val(),
            Description: $('#Description').val()
        };
        $.ajax({
            url: "/beauty/aboutus",
            data: JSON.stringify(aboutus),
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            success: function (result) {
                alert(result.message);
                window.location.href = '/beauty/beautyaboutus';
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
        return false;
    }
    function delAbout(id) {
        if (!confirm("Are you sure you want to delete this Record?")) {
            return false;
        } else {
            $.ajax({
                url: `/beauty/deleteabout?id=${id}`,
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
//...............End Aboutus.................//
