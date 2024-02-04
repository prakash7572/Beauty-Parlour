//...............Start Aboutus.................//
var url = window.location.origin;
    function loadData() {
        $.ajax({
            url: "/beauty/aboutus",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                let html = '';
                $.each(result, function (key, item) {
                    html += '<tr>';
                    html += `<td>${key + 1}</td>`;
                    html += `<td>${item.Title}</td>`;
                    html += `<td>${item.SubTitle}</td>`;
                    html += `<td>${item.Description}</td>`;
                    html += `<td><img src="${url}/Content/Image/${item.Image}" widht="40" height="30" /></td>`;
                    html += `<td>
                                 <a href="#" data-toggle="modal" data-target="#rightSideModal" onclick="GetAbout(${item.ID})"><i class="fa fa-edit"></i></a>
                                 <a href="#" onclick="delAbout(${item.ID})" id="showConfirmToastBtn"><i class="fa fa-trash"></i></a>
                                 </td>`;
                    html += '</tr>';
                });
                $('#list').html(html);
            },
            error: function (errormessage) {
                toastr.error(errormessage.responseText, 'Error');
            }
        });
    }
    loadData();
function ClearForm() {
        $('form#aboutusForm').trigger("reset");
        $('#ID').val(0);
    }
    function GetAbout(id) {
        $.ajax({
            url: `/beauty/aboutus?id=${id}`,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                $('#Image').prop('required', false);
                $("#Title").val(result[0].Title);
                $("#SubTitle").val(result[0].SubTitle);
                $("#Img").val(result[0].Image);
                $("#Description").val(result[0].Description);
                $("#ID").val(result[0].ID);
            },
            error: function (errormessage) {
                toastr.error(errormessage.responseText, 'Error');
            }
        });
    }
  
function submitAbout() {
    
    var data = new FormData();
    data.append("ID", $('#ID').val());
    data.append("Title", $('#Title').val());
    data.append("SubTitle", $('#SubTitle').val());
    data.append("Description", $('#Description').val());

    let fileInput = $('#Image')[0].files[0];
       if (fileInput) {
           data.append("Image", fileInput);
       } else {
           data.append("Image", $("#Img").val());
       }
       $.ajax({
           url: "/beauty/aboutus",
           data: data,
           type: "POST",
           contentType: false,
           processData: false,
           success: function (result) {
               toastr.success(result.message, 'Success');
               toastr.error(result.message, 'Error');
               $('[data-dismiss="modal"]').trigger('click');
               loadData();
           },
           error: function (errormessage) {
               toastr.error(errormessage.responseText, 'Error');
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
                    toastr.success(result.message, 'Success');
                    loadData();
                },
                error: function (errormessage) {
                    toastr.error(errormessage.responseText, 'Error');
                }
            });
        };
}

//...............End Aboutus.................//
