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
        if (response.isSuccess) {
            $.cookie('_ncfa', response.authToken);
        }
        $('#btnLogIn').hide();
        $('#StatusText').text(response.message);
    })
    .fail(function (msg) { $('#StatusText').text('Error: ' + msg.statusText); });
};