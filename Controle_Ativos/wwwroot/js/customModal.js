function ativarModal(elemento) {
    let modal = document.getElementById(elemento.getAttribute('data-modal').replace('#', ''))
    modal.classList.add('active')
}

function desativarModal(elemento) {
    elemento.parentNode.classList.remove('active')
}

function desativarModalPeloId(id) {
    document.getElementById(id).classList.remove('active')
}