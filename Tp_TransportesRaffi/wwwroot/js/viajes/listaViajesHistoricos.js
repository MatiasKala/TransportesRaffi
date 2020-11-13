const data = [
    {
        "idViaje": 123,
        "cliente": "Mati Kala",
        "vehiculo": "CAMION",
        "chofer": "Esteban Trabajos"
    }, {
        "idViaje": 231,
        "cliente": "Mati Kala",
        "vehiculo": "CAMION",
        "chofer": "Guillermo Puertas"
    }, {
        "idViaje": 456,
        "cliente": "J.P. Morvidone",
        "vehiculo": "MOTO",
        "chofer": "Axel Rosedal"
    }, {
        "idViaje": 543,
        "cliente": "Fer Martinez",
        "vehiculo": "UTILITARIO",
        "chofer": "Alfredo Mercurio"
    }
];

$(function () {
    const tbody = $("#tabla tbody");
    let tr = $("<tr />");

    $.each(data, function (_, obj) {
        tr = $("<tr />");
        $.each(obj, function (_, text) {

            tr.append("<td>" + text + "</td>");

        });
        tr.appendTo(tbody);
    });
});
