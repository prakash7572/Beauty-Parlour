$(document).ready(function () {
    $(".cancel").on("click", function () {
        window.location.href ="/home/index"
    });
})
function PorfileSumbit() {

    var data = new FormData();
    data.append("UserId", $('#ID').val());
    data.append("Title", $('#Title').val());
    data.append("FirstName", $('#firstname').val());
    data.append("MiddleName", $('#middlename').val());
    data.append("LastName", $('#lastname').val());
    data.append("UserName", $('#Username').val());
    data.append("Phone", $('#phonenumber').val());
    data.append("Email", $('#email').val());

    let fileInput = $('#Image')[0].files[0];
    if (fileInput) {
        data.append("Image", fileInput);
    } else {
        data.append("Image", $("#Img").val());
    }
    $.ajax({
        url: "/home/profile",
        data: data,
        type: "POST",
        contentType: false,
        processData: false,
        success: function (result) {
            alert(result.message[0].operationMessage);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}