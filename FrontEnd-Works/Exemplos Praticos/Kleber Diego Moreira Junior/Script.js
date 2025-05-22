function adicionarComentario() {
    var nomeInput = document.getElementById("usuario");
    var comentarioInput = document.getElementById("comentario");
    var listaComentarios = document.getElementById("comentarios-lista");
    var nomeUsuario = nomeInput.value.trim();
    var comentario = comentarioInput.value.trim();
    if (nomeUsuario && comentario) {
        var comentarioDiv = document.createElement("div");
        comentarioDiv.classList.add("comentario");
        var nomeNegrito = document.createElement("strong");
        nomeNegrito.innerText = nomeUsuario;
        var comentarioTexto = document.createElement("p");
        comentarioTexto.innerText = comentario;
        comentarioDiv.appendChild(nomeNegrito);
        comentarioDiv.appendChild(comentarioTexto);
        listaComentarios.appendChild(comentarioDiv);
        nomeInput.value = "";
        comentarioInput.value = "";
    }
    else {
        alert("Por favor, preencha tanto o nome quanto o comentário.");
    }
}
window.adicionarComentario = adicionarComentario;
