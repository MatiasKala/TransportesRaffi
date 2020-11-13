function crearVehiculo() {
    var a = document.getElementById('marca').value;
    var b = document.getElementById('modelo').value;
    var c = document.getElementById('anio').value;
    var d = document.getElementById('patente').value;
    var e = document.getElementById('seguro').value;
    var f = document.getElementById('tipo').value;
    if (a && b && c && d && e && f) {
        alert("Creacion exitosa");
    } else {
        alert("Error en creacion");
    }
}