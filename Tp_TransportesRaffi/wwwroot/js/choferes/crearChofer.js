function crearChofer() {
    var a = document.getElementById('nombre').value;
    var b = document.getElementById('CUIL').value;
    var c = document.getElementById('fechaNacimiento').value;
    var d = document.getElementById('comision').value;
    if (a && b && c && d) {
        alert("Creacion exitosa");
    } else {
        alert("Error en creacion");
    }
}