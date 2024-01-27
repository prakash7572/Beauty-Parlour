//...............Start Team.................//
var url = window.location.origin;
    function loadData() {
        $.ajax({
            url: "/beauty/team",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                let html = '';
                $.each(result, function (key, item) {
                    html += '<tr>';
                    html += `<td>${key + 1}</td>`;
                    html += `<td>${item.UserName} </td>`;
                    html += `<td>${item.Description}</td>`;
                    //html += `<td>${item.TwitterURL}</td>`;
                    //html += `<td>${item.InstagramURL}</td>`;
                    html += `<td><img src="${url}/Content/Image/${item.Image}" widht="40" height="30" /></td>`;
                    html += `<td>
                                 <a href="#" data-toggle="modal" data-target="#rightSideModal" onclick="GetTeam(${item.ID})"><i class="fa fa-edit"></i></a>
                                 <a href="#" onclick="DelTeam(${item.ID})"><i class="fa fa-trash"></i></a>
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
function ClearForm() {
    $('form#teamForm').trigger("reset");
        $('#ID').val(0);
    }
function GetTeam(id) {
        $.ajax({
            url: `/beauty/team?id=${id}`,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                $('#Image').prop('required', false);
                $("#Title").val(result[0].Title);
                $("#MiddleName").val(result[0].MiddleName);
                $("#FirstName").val(result[0].FirstName);
                $("#LastName").val(result[0].LastName);
                $("#TwitterUrl").val(result[0].TwitterURL);
                $("#InstagramUrl").val(result[0].InstagramURL);
                $("#Img").val(result[0].Image);
                $("#Description").val(result[0].Description);
                $("#ID").val(result[0].ID);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
  
function submitAbout() {
    
    var data = new FormData();
    data.append("ID", $('#ID').val());
    data.append("Title", $('#Title').val());
    data.append("FirstName", $('#FirstName').val());
    data.append("LastName", $('#LastName').val());
    data.append("MiddleName", $('#MiddleName').val());
    data.append("TwitterUrl", $('#TwitterUrl').val());
    data.append("InstagramUrl", $('#InstagramUrl').val());
    data.append("Description", $('#Description').val());

    let fileInput = $('#Image')[0].files[0];
       if (fileInput) {
           data.append("Image", fileInput);
       } else {
           data.append("Image", $("#Img").val());
       }
       $.ajax({
           url: "/beauty/team",
           data: data,
           type: "POST",
           contentType: false,
           processData: false,
           success: function (result) {
               window.location.href = '/beauty/beautyteam';
               alert(result.message);
           },
           error: function (errormessage) {
               alert(errormessage.responseText);
           }
       });
    return false;
}


function DelTeam(id) {
        if (!confirm("Are you sure you want to delete this Record?")) {
            return false;
        } else {
            $.ajax({
                url: `/beauty/deleteteam?id=${id}`,
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
