
function Login() {

    var data = new FormData();
    data.append("Email", $('#Email').val());
    data.append("Password", $('#Password').val());
    $.ajax({
        url: "/home/Login",
        data: data,
        type: "POST",
        contentType: false,
        processData: false,
        success: function (result) {
            if (result.message[0].statusCode == "SUCCESS") {
                toastr.success(result.message[0].operationMessage, 'Success');
                setInterval(function () { window.location.href = '/home/index'; }, 1000);
                
            } else {
                toastr.error(result.message[0].operationMessage, 'Error');
                $('#Email,#Password').val('');
            }
        },
        error: function (errormessage) {
            toaster.error(errormessage.responseText);
        }
    });
    return false;
}