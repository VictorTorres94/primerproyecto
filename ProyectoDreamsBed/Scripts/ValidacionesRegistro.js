function cargarEventos() {

    var primeraVez = 0;

    /* FORMULARIO ENTRAR */
    function comprobarCampos(e) {
        let email = document.getElementById("email").value;
        let pass = document.getElementById("password").value;
        let textoError = document.getElementById("mensajeError");
        if (email == "" || email == null || pass == "" || pass == null) {
            textoError.innerHTML = "Debe rellenar los campos";
            e.preventDefault();
        } 
    }

    function limpiarError(e) {
        document.getElementById("mensajeError").innerHTML = "";
        document.getElementById("mensajeErrorRegistro").innerHTML = "";
        if (e.target.id == "resetRegistro") {
            document.getElementById("errorPassword2").innerHTML = "";
            primeraVez = 0;
        }
        
    }

    document.getElementById("formularioEntrar").addEventListener("submit", comprobarCampos);
    document.getElementById("formularioEntrar").addEventListener("reset", limpiarError);
    document.getElementById("email").addEventListener("focus", limpiarError);
    document.getElementById("password").addEventListener("focus", limpiarError);


    /* FORMULARIO REGISTRO */

    function comprobarCamposRegistro(e) {
        let nombre = document.getElementById("nombre").value;
        let apellidos = document.getElementById("apellidos").value;
        let emailRegistro = document.getElementById("emailRegistro").value;
        let passwordRegistro1 = document.getElementById("passwordRegistro1").value;
        let passwordRegistro2 = document.getElementById("passwordRegistro2").value;

        if (nombre == "" || apellidos == "" || emailRegistro == "" || passwordRegistro1 == "" || passwordRegistro2 == ""  || nombre == null || apellidos == null || emailRegistro == null || passwordRegistro1 == null || passwordRegistro2 == null) {
            document.getElementById("mensajeErrorRegistro").innerHTML = "Debe rellenar todos los campos";
            e.preventDefault();
        }
    }

    

    
    function comprobandoContraseñas() {
        let pass1 = document.getElementById("passwordRegistro1").value;
        let pass2 = document.getElementById("passwordRegistro2").value;
        if (primeraVez != 0) {
            if (pass1 != pass2) {
                document.getElementById("errorPassword2").innerHTML = "Las contraseñas no coinciden";
            } else {
                document.getElementById("errorPassword2").innerHTML = "";
            }
        }
    }

    function sumarPrimeraVez() {
        primeraVez++;
    }

    

    document.getElementById("formularioRegistro").addEventListener("submit", comprobarCamposRegistro);
    document.getElementById("formularioRegistro").addEventListener("reset", limpiarError);
    document.getElementById("nombre").addEventListener("focus", limpiarError);
    document.getElementById("apellidos").addEventListener("focus", limpiarError);
    document.getElementById("emailRegistro").addEventListener("focus", limpiarError);
    document.getElementById("passwordRegistro1").addEventListener("focus", limpiarError);
    document.getElementById("passwordRegistro2").addEventListener("focus", limpiarError);
    document.getElementById("passwordRegistro1").addEventListener("input", comprobandoContraseñas);
    document.getElementById("passwordRegistro2").addEventListener("input", comprobandoContraseñas);
    document.getElementById("passwordRegistro1").addEventListener("blur", sumarPrimeraVez);
    document.getElementById("passwordRegistro2").addEventListener("blur", sumarPrimeraVez);
    document.getElementById("resetRegistro").addEventListener("click", limpiarError);
}

window.addEventListener("load", cargarEventos);