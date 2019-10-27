function acceptance() {

	const inputFields = document.querySelector("#fields").children;
	inputFields[4].addEventListener("click", validateInput);

	function validateInput() {
		let company = inputFields[0].children[0].value;
		let product = inputFields[1].children[0].value;
		let quantity = inputFields[2].children[0].value;
		let scrape = inputFields[3].children[0].value;

		if (company !== "" &&
			product !== "" &&
			quantity !== "" &&
			scrape !== "" &&
			!isNaN(quantity) &&
			!isNaN(scrape)) {
			if(Number(quantity) - Number(scrape) > 0){
				addStock(company, product, quantity - scrape);
			}	
		}
		inputFields[0].children[0].value = "";
		inputFields[1].children[0].value = "";
		inputFields[2].children[0].value = "";
		inputFields[3].children[0].value = "";
	}

	function addStock(company, product, quantity) {
		let warehouse = document.getElementById("warehouse");
		let divEl = document.createElement("div");
		let pElement = document.createElement("p");
		pElement.innerHTML = `[${company}] ${product} - ${quantity} pieces`;

		let btn = document.createElement("button");
		btn.type = "button";
		btn.innerHTML = "Out of stock";

		divEl.appendChild(pElement);
		divEl.appendChild(btn);
		warehouse.appendChild(divEl);
		
		btn.addEventListener("click", (e) => {
			let parentElement = e.target.parentElement.parentElement;
			let elementTRemove = e.target.parentElement
			parentElement.removeChild(elementTRemove);
		})
	}
}