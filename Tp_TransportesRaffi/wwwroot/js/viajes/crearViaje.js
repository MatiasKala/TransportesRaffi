function crearViaje() {
    var a = document.getElementById('nombre').value;
    var b = document.getElementById('descripcion').value;
    var c = document.getElementById('vehiculo').value;
    var d = document.getElementById('destino').value;
    var e = document.getElementById('fecha').value;
    var f = document.getElementById('valor').value;

    if (a && b && c && d && e && f) {
        alert("Creacion exitosa");
    } else {
        alert("Error en creacion");
    }
}