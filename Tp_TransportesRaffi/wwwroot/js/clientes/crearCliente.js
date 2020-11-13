function crearCliente() {
    var a = document.getElementById('nombre').value;
    var b = document.getElementById('CUIL').value;
    var c = document.getElementById('fechaNacimiento').value;
    var d = document.getElementById('patente').value;
    var e = document.getElementById('seguro').value;
    var f = document.getElementById('tipo').value;
    if (a && b && c && d && e && f) {
        alert("Creacion exitosa");
    } else {
        alert("Error en creacion");
    }
}