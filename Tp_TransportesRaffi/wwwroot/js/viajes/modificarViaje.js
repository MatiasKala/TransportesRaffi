function modificarViaje() {
    var a = document.getElementById('descripcion').value;
    var b = document.getElementById('vehiculo').value;
    var c = document.getElementById('destino').value;
    var d = document.getElementById('fecha').value;
    if (a && b && c && d) {
        alert("Modificacion exitosa");
    } else {
        alert("Error en la modificacion");
    }
}