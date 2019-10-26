function solve() {
    let totalProfit = 0;
    let totalProfitField = document.querySelector("body > h1:nth-child(3)");
    let buyButton;
    let addNewBookBtn = document.querySelector("body > form:nth-child(2) > button:nth-child(7)");
    addNewBookBtn.addEventListener('click', addBook);

    function addBook(e) {
        e.preventDefault();
        let elements = document.getElementsByTagName("input");
        let title = elements[0].value;
        let year = elements[1].value;
        let price = Number(elements[2].value);

        if (title !== "" && Number(year) > 0 && Number(price) > 0) {

            createNewBook(title, year, price);
        }
    };

    function createNewBook(title, year, price) {
        let bookShelf;
        let divElem = document.createElement("div");
        divElem.classList.add("book");
        let pElem = document.createElement("p");
        pElem.innerHTML = `${title} [${year}]`;
        divElem.appendChild(pElem);
        buyButton = document.createElement("button");
        buyButton.innerHTML = `Buy it only for ${price.toFixed(2)} BGN`;
        divElem.appendChild(buyButton);
        if (year >= 2000) {
            bookShelf = document.querySelector("#outputs > section:nth-child(2) > div:nth-child(2)");
            moveToOldBtn = document.createElement("button");
            moveToOldBtn.innerHTML = "Move to old section";
            divElem.appendChild(moveToOldBtn);

            moveToOldBtn.addEventListener("click", (e) => {
                let currentBook = e.target.parentElement;
                let price = Number(currentBook.children[1].innerHTML.split(" ")[4]) * 0.85;
                console.log(price)
                buyButton.innerHTML = `Buy it only for ${price.toFixed(2)} BGN`;

                currentBook.removeChild(currentBook.children[2]);
                let oldBookShelf = document.querySelector("#outputs > section:nth-child(1) > div:nth-child(2)");
                oldBookShelf.appendChild(currentBook);
            })

        } else {
            bookShelf = document.querySelector("#outputs > section:nth-child(1) > div:nth-child(2)");
            price = price * 0.85;
            buyButton.innerHTML = `Buy it only for ${price.toFixed(2)} BGN`;
                }

        bookShelf.appendChild(divElem);
        buyButton.addEventListener('click', (e) => {
            let price = Number(e.target.innerHTML.split(" ")[4]);
            let currentBook = e.target.parentElement;
            totalProfit += price;
            totalProfitField.innerHTML = `Total Store Profit: ${totalProfit.toFixed(2)} BGN`;
            currentBook.parentNode.removeChild(currentBook);
        });   
    }  
}
