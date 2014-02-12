$('#loginForm').submit(tryLogon);

function tryLogon(event) {
    event.preventDefault();
    var username = $('#Username').val();
    var password = $('#Password').val();
    $.ajax({
        url: 'login',
        type: "POST",
        data: { UserName: username, Password: password }
    })
    .done(function (response) {
        if (response.IsSuccess) {
            $.cookie('_ncfa', response.AuthToken);
        }
        $('#StatusText').text(response.Message);
    })
    .fail(function (msg) { $('#StatusText').text('Error: ' + msg.statusText); });
};