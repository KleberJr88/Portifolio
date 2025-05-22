function adicionarComentario(): void {
    const nomeInput = document.getElementById("usuario") as HTMLInputElement;
    const comentarioInput = document.getElementById("comentario") as HTMLTextAreaElement;
    const listaComentarios = document.getElementById("comentarios-lista") as HTMLDivElement;

    const nomeUsuario: string = nomeInput.value.trim();
    const comentario: string = comentarioInput.value.trim();

    if (nomeUsuario && comentario) {
        const comentarioDiv = document.createElement("div");
        comentarioDiv.classList.add("comentario");

        const nomeNegrito = document.createElement("strong");
        nomeNegrito.innerText = nomeUsuario;

        const comentarioTexto = document.createElement("p");
        comentarioTexto.innerText = comentario;

        comentarioDiv.appendChild(nomeNegrito);
        comentarioDiv.appendChild(comentarioTexto);

        listaComentarios.appendChild(comentarioDiv);

        nomeInput.value = "";
        comentarioInput.value = "";
    } else {
        alert("Por favor, preencha tanto o nome quanto o comentário.");
    }
}

(window as any).adicionarComentario = adicionarComentario;
