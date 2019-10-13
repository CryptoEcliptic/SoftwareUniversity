function notify(message) {
    let notifElement = document.getElementById("notification");
    notifElement.style.display = "block";
    notifElement.innerHTML = message;
    setTimeout(
        function () {
            notifElement.style.display = "none";
        },
        2000
    );
}