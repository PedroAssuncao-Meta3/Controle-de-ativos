function toggleDarkLight() {
    //var body = document.getElementById("body").classList.toggle("dark-edition");
    let mode = localStorage.getItem('mode')
    if (mode == null || mode == 'light') {
        document.getElementById("body").classList.add("dark-edition");
        document.getElementById("body").classList.remove("light-edition");
        localStorage.setItem('mode', 'dark')
    } else {
        document.getElementById("body").classList.remove("dark-edition");
        document.getElementById("body").classList.add("light-edition");
        localStorage.setItem('mode', 'light')
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