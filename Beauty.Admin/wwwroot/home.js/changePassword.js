$(document).ready(function () {
    $('input').on("keyup", function () {
        var pass = $('input[name=NewPassword]').val();
        var repass = $('input[name=ConfirmPassword]').val();
        if (($('input[name=NewPassword]').val().length == 0) || ($('input[name=ConfirmPassword]').val().length == 0)) {
            $('#newpassword').addClass('has-error');
        }
        else if (pass != repass) {
            $(".Confirm").hide();
            $(".error-msg").html('Did Not match new password.');
            return false;
        }
        else {
            $(".Confirm").show();
            $(".error-msg").html('');
        }
    });         
});
function ChagePasswordSumbit() {

    var data = new FormData();
    data.append("OldPassword", $('#oldpassword').val());
    data.append("NewPassword", $('#newpassword').val());
    data.append("ConfirmPassword", $('#confirmpassword').val());
    
    $.ajax({
        url: "/home/changepassword",
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
