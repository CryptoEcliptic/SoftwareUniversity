function getInfo() {
    const stopId = document.getElementById("stopId");
    const stopNameDiv = document.getElementById("stopName");
    const busList = document.getElementById("buses");
  
    const fetchBusesUrl = `https://judgetests.firebaseio.com/businfo/${stopId.value}.json`;
    busList.innerHTML = "";
    stopNameDiv.innerHTML = "";
    fetch(fetchBusesUrl)
      .then(res => res.json())
      .then(data => {
        const { name, buses } = data;
        stopNameDiv.textContent = name;
        Object.entries(buses).forEach(([busId, bustTime]) => {
          const li = document.createElement("li");
          li.textContent = `Bus ${busId} arrives in ${bustTime} minutes.`;
  
          busList.appendChild(li);
        });
      })
      .catch(error => {
        stopNameDiv.textContent = "Error";
      });
}