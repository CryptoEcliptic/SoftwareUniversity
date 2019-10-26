// NOTE: The comment sections inside the index.html file is an example of how suppose to be structured the current elements.
//       - You can use them as an example when you create those elements, to check how they will be displayed, just uncomment them.
//       - Also keep in mind that, the actual skeleton in judge does not have this comment sections. So do not be dependent on them!
//       - Тhey are present in the skeleton just to help you!


// This function will be invoked when the html is loaded. Check the console in the browser or index.html file.
function mySolution() {

    let mainTextArea = document.getElementById("inputSection").firstElementChild;
    let userNameField = document.querySelector("#inputSection > div:nth-child(2) > input:nth-child(2)");
    let sendQuestionBtn = document.querySelector("#inputSection > div:nth-child(2) > button:nth-child(3)");
    let pendingQuestions = document.getElementById("pendingQuestions");
    let openQuestions = document.getElementById("openQuestions");

    sendQuestionBtn.addEventListener("click", sendPendingQuestion);

    function sendPendingQuestion() {
        let pendingQuestionsSection = document.getElementById("pendingQuestions");
        let pendingQuestion = createPendingQuestion();
        pendingQuestionsSection.appendChild(pendingQuestion);
    }

    function createImageElem() {
        let imgElem = document.createElement("img");
        imgElem.src = "./images/user.png";
        imgElem.width = 32;
        imgElem.height = 32;

        return imgElem;
    }
    function createSpanElem() {
        let spanElement = document.createElement("span");
        userNameField.value == "" ? spanElement.innerHTML = "Anonymous" : spanElement.innerHTML = userNameField.value;
        return spanElement;
    }
    function createPElement() {
        let pElem = document.createElement("p");
        pElem.innerHTML = mainTextArea.value;
        return pElem;
    }
    function createActionButtons() {
        let divElem = document.createElement("div");
        divElem.classList.add("actions");

        let archiveBtn = document.createElement("button");
        archiveBtn.classList.add("archive");
        archiveBtn.innerHTML = "Archive";
        archiveBtn.addEventListener("click", function (e) {
            let elementToRemove = e.target.parentNode.parentNode;
            pendingQuestions.removeChild(elementToRemove);
        })
        divElem.appendChild(archiveBtn);

        let openBtn = document.createElement("button");
        openBtn.classList.add("open");
        openBtn.innerHTML = "Open";
        divElem.appendChild(openBtn);
        openBtn.addEventListener("click",(e) => {
            openQuestion(e)
        });

        return divElem;
    }
    function createPendingQuestion() {
        let divMessageElem = document.createElement("div");
        divMessageElem.classList.add("pendingQuestion");

        divMessageElem.appendChild(createImageElem());
        divMessageElem.appendChild(createSpanElem());
        divMessageElem.appendChild(createPElement());
        divMessageElem.appendChild(createActionButtons());

        return divMessageElem;
    }
    function openQuestion(e) {
        let openQuestion = e.target.parentNode.parentNode;
        openQuestion.classList = "openQuestion";
        let replyButton = createReplyBtn();
        openQuestion.lastElementChild.innerHTML = "";
        openQuestion.lastElementChild.appendChild(replyButton);
        openQuestion.appendChild(replySection());
        openQuestions.appendChild(openQuestion);

        replyButton.addEventListener("click", (e) => {
           e.target.parentNode.nextSibling.style.display = "block";
           e.target.innerHTML = "Back";
           e.target.addEventListener("click", (x) => {
               x.target.parentNode.nextSibling.style.display = "none";
               x.target.innerHTML = "Reply";
           })
        }); 

    }
    function createReplyBtn(){
        let btn = document.createElement("button");
        btn.classList.add("reply");
        btn.innerHTML = "Reply";
        return btn;
    }
    function replySection(){
        let replyDivEl = document.createElement("div");
        replyDivEl.classList.add("replySection");
        replyDivEl.style.display = "none";

        let inputEl = document.createElement("input");
        inputEl.classList.add("replyInput");
        inputEl.type = "text";
        inputEl.placeholder = "Reply to this question here...";
        replyDivEl.appendChild(inputEl);

        let sendBtn = document.createElement("button");
        sendBtn.classList.add("replyButton");
        sendBtn.innerHTML = "Send";
        replyDivEl.appendChild(sendBtn);

        ol = document.createElement("ol");
        ol.classList.add("reply");
        ol.type = "1";
        replyDivEl.appendChild(ol);
        
        sendBtn.addEventListener("click", (e) => {
            let reply = e.target.previousSibling.value;
            let li = document.createElement("li");
            li.innerHTML = reply;
            let ol = e.target.nextSibling;
            ol.appendChild(li);
        })
        return replyDivEl;
    }
}
