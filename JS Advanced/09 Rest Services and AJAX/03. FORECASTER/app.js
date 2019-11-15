import { fetchData } from "./fetchData.js"
import { fetchWeather } from "./fetchWeather.js"

const cityCodes = {
    "new york" : "ny",
    "london" : "london",
    "barcelona" : "barcelona"
}

const symbols = {
    Sunny: '☀',
    'Partly sunny': '⛅',
    Overcast: '☁',
    Rain: '☂',
    "degrees": '°',
};

const reqButton = document.getElementById("submit");
let inputName = document.getElementById("location").value;

async function getLocations() {
    await fetchData('locations').then(x => getWeatherData(inputName));
}

async function getWeatherData(inputName){
    let cityCode = cityCodes[inputName.toLowerCase()];
    if(cityCode !== "undefined"){
        fetchWeather(cityCode)
            .then(x => createCurrentWeatherElements(x));
    }
} 

async function createCurrentWeatherElements(data){
    let forecast = data["forecast"];

    const mainDivEl = document.getElementById("forecast");
    const currParentEl = document.getElementById("current");

    const forecastParentDivEl = appendCurrentForecastSpans(data, forecast);
    currParentEl.appendChild(forecastParentDivEl);
    mainDivEl.style.display = "block";
}

function appendCurrentForecastSpans(data, forecast){
    const forecastParentDivEl = createElement("div", "forecasts");

    const symbolSpan = createElement("span", "condition symbol", symbols[forecast["condition"]]);
    forecastParentDivEl.appendChild(symbolSpan);
    const parentSpan = createElement("span", "condition");
    const areaSpan = createElement("span", "forecast-data", data["name"]);
    const degreesSpan = 
        createElement("span", "forecast-data", `${forecast["low"]}${symbols["degrees"]}/${forecast["high"]}${symbols["degrees"]}`);
    const conditionSpan = createElement("span", "forecast-data", forecast["condition"]);
    parentSpan.appendChild(areaSpan);
    parentSpan.appendChild(degreesSpan);
    parentSpan.appendChild(conditionSpan);

    forecastParentDivEl.appendChild(parentSpan);
    return forecastParentDivEl;
}

function createElement(tagName, className, content){
    const element = document.createElement(tagName);
    element.className = className;
    element.textContent = content;
    return element;
}

reqButton.addEventListener("click", getLocations);




