function getAccessToken() {
    if (location.hash) {
        if (location.hash.split('access_token=')) {
            var accessToken = location.hash.split('access_token=')[1].split('&')[0];
            if (accessToken) {
                isUserRegistered(accessToken);
            }
        }
    }
}

function isUserRegistered(accessToken) {
    $.ajax({
        url: '/api/Account/UserInfo',
        Method = 'GET',
        headers = {
            'content-type': 'application/JSON',
            'Authorization': 'Bearer ' + accessToken
        },
        success: function (response) {
            if (response.HasRegistered) {
                localStorage.setItem("accessToken", accessToken);
                localStorage.setItem("userName", response.Email);
                window.location.href = "Data.html";
            }
            else {
                signUpExternalUser(accessToken);
            }
        }
    });

}

function signUpExternalUser(accessToken) {
    $.ajax({
        url: '/api/Account/RegisterExternal',
        Method = 'POST',
        headers = {
            'content-type': 'application/JSON',
            'Authorization': 'Bearer ' + accessToken
        },
        success: function (response) {
            window.location.href = "/api/Account/ExternalLogin?provider=Google&response_type=token&client_id=self&redirect_uri=http%3A%2F%2Flocalhost%3A49273%2FLogin.html&state=hczOpnqUcTs_OrxbNr68TYQpvObs146VwGc7g72G2OQ1";
        }
    });

}