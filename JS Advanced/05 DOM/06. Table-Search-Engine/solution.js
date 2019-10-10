function solve() {
   let searchWord = document.getElementById("searchField");
   let table = document.querySelectorAll("tbody tr");

   document.querySelector("#searchBtn").addEventListener("click", () => {
      if(searchWord.value !== ''){
         for (let line of table) {
            line.className = '';
            if (line.innerHTML.toLowerCase().includes(searchWord.value.toLowerCase())) {
               line.className = 'select';
            }
         } 
      }
      searchWord.value = '';
   });
}





