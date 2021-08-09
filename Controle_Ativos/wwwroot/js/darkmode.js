function toggleDarkLight() {
    //var body = document.getElementById("body").classList.toggle("dark-edition");
    let mode = localStorage.getItem('mode')
    if (mode == null || mode == 'light') {
        document.getElementById("body").classList.toggle("dark-edition");
        localStorage.setItem('mode', 'dark')
    } else {
        document.getElementById("body").classList.toggle("light-edition");
        localStorage.setItem('mode', 'light')
        document.location.reload()
    }
}

function setMode() {
    let mode = localStorage.getItem('mode')
    if (mode == null) {
        localStorage.setItem('mode', 'light')
    } else if (mode == 'dark') {
        document.getElementById("body").classList.toggle("dark-edition");

    }
}

setMode()