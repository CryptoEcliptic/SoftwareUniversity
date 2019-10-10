function solve() {
    let addButton = document.querySelector("#exercise > article:nth-child(1) > button:nth-child(2)");
    addButton.addEventListener('click', processData);

    let lettersList = document.querySelectorAll("ol li");
    function processData() {
        let inputField = document.querySelector("#exercise > article:nth-child(1) > input:nth-child(1)").value;
        let firstLetter = inputField[0].toUpperCase();
        let nameCapitalized = inputField.charAt(0).toUpperCase() + inputField.slice(1).toLowerCase();
        let letterIndex = firstLetter.charCodeAt(0);
        let index = letterIndex - 65;

        lettersList[index].innerHTML
            ? lettersList[index].innerHTML += ', ' + nameCapitalized
            : lettersList[index].innerHTML = nameCapitalized
    }
}
