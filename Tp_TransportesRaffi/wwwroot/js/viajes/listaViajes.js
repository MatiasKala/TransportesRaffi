const data = [
    {
       "idViaje": 123,
       "cliente":"Mati Kala",
       "modificar": "M",
       "eliminar": "E",
       "estado": "PENDIENTE"
    },{
        "idViaje": 231,
        "cliente": "Mati Kala",
        "modificar": "M",
        "eliminar": "E",
         "estado": "EN TRANSITO"
    },{
        "idViaje": 456,
        "cliente": "J.P. Morvidone",
        "modificar": "M",
        "eliminar": "E",
         "estado": "PENDIENTE"
    },{
        "idViaje": 543,
        "cliente": "Fer Martinez",
        "modificar": "M",
        "eliminar": "E",
         "estado": "EN TRANSITO"
    }
];
  
$(function() {
  const tbody = $("#tabla tbody");
  let tr = $("<tr />");

  $.each(data, function(_, obj) {
    tr = $("<tr />");
    $.each(obj, function(_, text) {
        if (text == "M") {
            tr.append("<td>" + `<a href="modificarViaje.html" title="Modificar Viaje"><i class="fa fa-edit" id="icono"></i></a>` + "</td>");
        } else if (text == "E") {
            tr.append("<td>" + `<a href="#" title="Eliminar Viaje"><i class="fa fa-trash" id="icono"></i></a>` + "</td>");
        } else {
            tr.append("<td>" + text + "</td>");
        }
    });
    tr.appendTo(tbody);
  });
});
