function encodeAndDecodeMessages() {
    let encodeButton = document.querySelectorAll("button")[0];
    let decodeButton = document.querySelectorAll("button")[1];
    let sendArea = document.querySelectorAll("textarea")[0];
    let receiveArea = document.querySelectorAll("textarea")[1];

    function encode(){

        let messsage = sendArea.value;
        let encoded = messsage
        .split("")
        .map(x => x.charCodeAt() + 1)
        .map(x => String.fromCharCode(x))
        .join("");

        receiveArea.value = encoded;
        sendArea.value = "";
        console.log(encoded)
    }
    function decode(){
        let decoded = receiveArea.value
        .split("")
        .map(x => x.charCodeAt() - 1)
        .map(x => String.fromCharCode(x))
        .join("");
        receiveArea.value = decoded;
    }
    encodeButton.addEventListener("click", encode);
    decodeButton.addEventListener("click", decode)
}

