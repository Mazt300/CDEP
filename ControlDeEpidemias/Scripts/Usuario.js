function load(urldirecion) {

    $(function () {
        var url = urldirecion;

        $.get(url).done(function (data) {
            $("#divGet").empty();
            $("#divGet").append(data);
        }).fail(function (s1, s2, error) {
            if (s1.status === 0) {
                alert('No conexion: Verificar la Network');
            }
            if (s1.status === 404) {
                alert('Requested page not found [404}')
            }
        })
    })
}