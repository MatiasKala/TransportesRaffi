function modificarChofer() {
    var a = document.getElementById('nombre').value;
    var b = document.getElementById('CUIL').value;
    var c = document.getElementById('fechaNacimiento').value;
    var d = document.getElementById('comision').value;
    if (a && b && c && d) {
        alert("Modificacion exitosa");
    } else {
        alert("Error en modificacion");
    }
}