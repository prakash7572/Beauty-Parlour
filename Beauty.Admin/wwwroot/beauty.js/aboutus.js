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
                    html += `<td>${item.Title}</td>`;
                    html += `<td>${item.SubTitle}</td>`;
                    html += `<td>${item.Description}</td>`;
                    html += `<td>${item.Image}</td>`;
                    html += `<td>
                                 <a href="#" data-toggle="modal" data-target="#rightSideModal" onclick="editAbout(${item.ID})"><i class="fa fa-edit"></i></a>
                                 <a href="#" onclick="delAbout(${item.ID})"><i class="fa fa-trash"></i></a>
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
    //function submitAbout() {
    //    var aboutus = {
    //        ID: $('#ID').val(),
    //        Title: $('#Title').val(),
    //        SubTitle: $('#SubTitle').val(),
    //        Image: $('#Image').val(),
    //        Description: $('#Description').val()
    //    };

    //    $.ajax({
    //        url: "/beauty/aboutus",
    //        data: JSON.stringify(aboutus),
    //        type: "POST",
    //        contentType: "application/json",
    //        dataType: "json",
    //        success: function (result) {
    //            alert(result.message);
    //            window.location.href = '/beauty/beautyaboutus';
    //        },
    //        error: function (errormessage) {
    //            alert(errormessage.responseText);
    //        }
    //    });
    //    return false;
//}

function submitAbout() {
    var aboutus = {
        ID: $('#ID').val(),
        Title: $('#Title').val(),
        SubTitle: $('#SubTitle').val(),
        Image: $('#Image')[0].files[0],
        // Remove $('#Image').val() for file input
        Description: $('#Description').val()
    };

    //var formData = new FormData();
    //formData.append("ID", aboutus.ID);
    //formData.append("Title", aboutus.Title);
    //formData.append("SubTitle", aboutus.SubTitle);
    //formData.append("Description", aboutus.Description);

    //// Append the file input data if a file is selected
    //var fileInput = $('#Image')[0].files[0];
    //if (fileInput) {
    //    formData.append("Image", fileInput);
    //}
    console.log(aboutus);
    $.ajax({
        url: "/beauty/aboutus",
        data: aboutus,
        type: "POST",
        contentType: "application/json",
        processData: false,
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
