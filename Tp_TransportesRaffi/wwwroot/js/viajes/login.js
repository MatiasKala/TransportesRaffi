function login() {
    var a = document.getElementById('usuario').value;
    var b = document.getElementById('clave').value;
    if (a && b) {
        alert("Login exitoso");
    } else {
        alert("Error en login");
    }
}