document.getElementById("btn__iniciar-sesion").addEventListener("click", iniciarSesion);
document.getElementById("btn__registrarse").addEventListener("click", register);
document.getElementById("olvide-contrasena").addEventListener("click", mostrarFormularioRecuperar);
document.getElementById("volver-login").addEventListener("click", volverLogin);
window.addEventListener("resize", anchoPage);

var formulario_login = document.querySelector(".formulario__login");
var formulario_register = document.querySelector(".formulario__register");
var formulario_recuperar = document.querySelector(".formulario__recuperar");
var contenedor_login_register = document.querySelector(".contenedor__login-register");
var caja_trasera_login = document.querySelector(".caja__trasera-login");
var caja_trasera_register = document.querySelector(".caja__trasera-register");

function anchoPage(){
    if (window.innerWidth > 850){
        caja_trasera_register.style.display = "block";
        caja_trasera_login.style.display = "block";
    }else{
        caja_trasera_register.style.display = "block";
        caja_trasera_register.style.opacity = "1";
        caja_trasera_login.style.display = "none";
        formulario_login.style.display = "block";
        contenedor_login_register.style.left = "0px";
        formulario_register.style.display = "none";   
    }
}

anchoPage();

function iniciarSesion(){
    if (window.innerWidth > 850){
        formulario_login.style.display = "block";
        contenedor_login_register.style.left = "10px";
        formulario_register.style.display = "none";
        formulario_recuperar.style.display = "none";
        caja_trasera_register.style.opacity = "1";
        caja_trasera_login.style.opacity = "0";
    }else{
        formulario_login.style.display = "block";
        contenedor_login_register.style.left = "0px";
        formulario_register.style.display = "none";
        formulario_recuperar.style.display = "none";
        caja_trasera_register.style.display = "block";
        caja_trasera_login.style.display = "none";
    }
}

//boton que redirige de entrar en el inicio de sesion a la pagina 
document.querySelector(".formulario__login button").addEventListener("click", function(event) {
    event.preventDefault();
    window.location.href = "administrador.html";
});




function register(){
    if (window.innerWidth > 850){
        formulario_register.style.display = "block";
        contenedor_login_register.style.left = "410px";
        formulario_login.style.display = "none";
        formulario_recuperar.style.display = "none";
        caja_trasera_register.style.opacity = "0";
        caja_trasera_login.style.opacity = "1";
    }else{
        formulario_register.style.display = "block";
        contenedor_login_register.style.left = "0px";
        formulario_login.style.display = "none";
        formulario_recuperar.style.display = "none";
        caja_trasera_register.style.display = "none";
        caja_trasera_login.style.display = "block";
        caja_trasera_login.style.opacity = "1";
    }
}

function mostrarFormularioRecuperar(event) {
    event.preventDefault();
    formulario_recuperar.style.display = "block";
    formulario_login.style.display = "none";
}

function volverLogin(event) {
    event.preventDefault();
    formulario_recuperar.style.display = "none";
    formulario_login.style.display = "block";
}