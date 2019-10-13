function lockedProfile() {
    [...document.querySelectorAll("button")]
        .forEach(x => x.addEventListener("click", (e) => {
            let hiddenInfoElem = e.target.previousElementSibling;
            let lockElement = hiddenInfoElem.parentNode.children[2];
            let unlockElement = hiddenInfoElem.parentNode.children[4];

            if (unlockElement.checked === true) {
                if (hiddenInfoElem.style.display === "block") {
                    hiddenInfoElem.style.display = "none";
                    e.target.innerHTML = "Show more";

                } else {
                    hiddenInfoElem.style.display = "block";
                    e.target.innerHTML = "Hide it";
                }
            }
            console.log(unlockElement, lockElement);
        }));

        [...document.querySelectorAll("input[type = radio]")]
        .forEach(x => x.addEventListener("click", (e) => {
            if(e.target.value === "unlock"){
                e.target.checked = true;
                e.target.parentNode.children[2].checked = false;

            } else if(e.target.value === "lock"){
                e.target.checked = true;
                e.target.parentNode.children[4].checked = false;
            }
        }));
}