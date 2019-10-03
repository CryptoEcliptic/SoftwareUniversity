function solve(...args){
    let weight =  Number(args[2]);
    let height =  Number(args[3]);

    let person = {};
    person["name"] = args[0];
    person["personalInfo"] = {
        age: Number(args[1]),
        weight : weight,
        height : height
    };
    person["BMI"] = calcBMI(weight, height)
    person["status"] = status(person["BMI"]);
    if(person["status"] === "obese"){
        person["recommendation"] = "admission required"
    }

    function calcBMI(mass, hei){
        let cmHeight = Number(hei / 100);
        let indexMass = (Number(mass / (Math.pow(cmHeight, 2))).toFixed());
        return Number(indexMass);
    }
    function status(bmi){
    let stat = bmi < 18.5 ? "underweight" :
        bmi < 25 ? "normal" :
        bmi < 30 ? "overweight" : "obese";

        return stat;
    }
    return person;
}

console.log(solve("Peter", 29, 75, 182));
//solve("Honey Boo Boo", 9, 57, 137);