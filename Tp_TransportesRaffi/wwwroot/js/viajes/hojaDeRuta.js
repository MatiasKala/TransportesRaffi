const data = [
    {
        "chofer": "Esteban Trabajos",
        "vehiculo": "CAMION",
        "direccionRecoleccion": "Av Nunca Muerta 132",
        "direccionEntrega": "Av Siempre Viva 746",
        "horarioEntrega": "18:00-22:00hs",
    }, {
        "chofer": "Guillermo Puertas",
        "vehiculo": "CAMION",
        "direccionRecoleccion": "Av Nunca Muerta 132",
        "direccionEntrega": "Av Siempre Viva 746",
        "horarioEntrega": "10:00-16:00hs",
    }, {
        "chofer": "Axel Rosedal",
        "vehiculo": "MOTO",
        "direccionRecoleccion": "Av Del Perro 123",
        "direccionEntrega": "Av Dl Gato 456",
        "horarioEntrega": "12:00-14:00hs",
    }, {
        "chofer": "Alfredo Mercurio",
        "vehiculo": "UTILITARIO",
        "direccionRecoleccion": "Av Oscura 678",
        "direccionEntrega": "Av Iluminada 877",
        "horarioEntrega": "8:00-14:00hs",
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
