
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
                window.location.href = '/home/index';
            } else {
                window.location.href = '/home/login';
            }
            alert(result.message[0].operationMessage);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}