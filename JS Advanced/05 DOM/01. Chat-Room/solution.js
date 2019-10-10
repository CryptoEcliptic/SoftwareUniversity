function solve() {
   const messageFieldElement = document.getElementById("chat_input");
   const sendButton = document.getElementById('send');

   sendButton.addEventListener('click', sendMessage);

   function sendMessage() {
      let message = messageFieldElement.value;

      let elementToappend = document.createElement("div");
      elementToappend.classList.add("message", "my-message");
      elementToappend.textContent = message;

      document.getElementById("chat_messages").appendChild(elementToappend);
      messageFieldElement.value = '';
      console.log(message)
   }
}