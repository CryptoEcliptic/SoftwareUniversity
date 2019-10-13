function attachEventsListeners() {

    Array.from(document.querySelectorAll("input[type=button]")).forEach(x => x.addEventListener("click", convert));

    function fromDays(days) {
        days = Number(days);
        let hours = days * 24;
        let minutes = hours * 60;
        let seconds = minutes * 60;
        return {
            days, hours, minutes, seconds
        }
    }
    function fromHours(hours) {
        hours = Number(hours);
        let days = hours / 24;
        let minutes = hours * 60;
        let seconds = minutes * 60;
        return {
            days, hours, minutes, seconds
        }
    }
    function fromMinutes(minutes) {
        minutes = Number(minutes);
        let hours = minutes / 60;
        let days = hours / 24;
        let seconds = minutes * 60;
        return {
            days, hours, minutes, seconds
        }
    }
    function fromSeconds(seconds) {
        seconds = Number(seconds);
        let minutes = seconds / 60;
        let hours = minutes / 60;
        let days = hours / 24;
        return {
            days, hours, minutes, seconds
        }
    }
    const mapper = {
        daysBtn: fromDays,
        hoursBtn: fromHours,
        minutesBtn: fromMinutes,
        secondsBtn: fromSeconds,
    }
    function convert(e) {
        let buttonId = e.target.id;
        let funcToCall = mapper[buttonId];
        let inputData = document.getElementById(buttonId).previousElementSibling.value;
        let result = funcToCall(inputData);

        console.log(result)
        Array.from(document.querySelectorAll('input[type=text]'))
            .map(x => {
                x.value = result[x.id]
            });
    }
}

