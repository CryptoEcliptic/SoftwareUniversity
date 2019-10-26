const { assert, expect } = require("chai");
const PizzUni = require("../02 PizzUni/02. PizzUni_Ресурси");

describe("Pizzuni unit tests", () => {
    let instance;
    beforeEach(function () {
        instance = new PizzUni();
    });
    it("Ctor instance set initial properties correctly", () => {
        expect(instance.registeredUsers).to.deep.equal([]);
        expect(instance.orders).to.deep.equal([]);
        expect(instance.availableProducts).to.deep.equal({
            pizzas: ['Italian Style', 'Barbeque Classic', 'Classic Margherita'],
            drinks: ['Coca-Cola', 'Fanta', 'Water']
        });
    })
    it("registerUser should throw error in case of duplicated email", () => {
        instance.registerUser("pesho@abv.bg");
        let existingUser = () => instance.registerUser("pesho@abv.bg");
        expect(existingUser).to.throw(Error, `This email address (pesho@abv.bg) is already being used!`)
    });
    it("registerUser should sucessfully register user", () => {
        let expectedResult = { email: "pesho@abv.bg", orderHistory: [] };
        let actualResult = instance.registerUser("pesho@abv.bg");
        expect(expectedResult).to.deep.equal(actualResult);
        assert(instance.registeredUsers.length, 1)
    });
    it("makeAnOrder should throw error in case of non existing user", () => {
        let invalidOrder = () => instance.makeAnOrder("pesho@abv.bg", "Barbeque Classic", "Water");
        expect(invalidOrder).to.throw(Error, "You must be registered to make orders!")
    });
    it("makeAnOrder should throw error in case of non existing pizza", () => {
        instance.registerUser("pesho@abv.bg");
        let invalidOrder = () => instance.makeAnOrder("pesho@abv.bg", "Barbeque Modern", "Water");
        expect(invalidOrder).to.throw(Error, "You must order at least 1 Pizza to finish the order.")
    });
    it("makeAnOrder should create order and return zero", () => {
        instance.registerUser("pesho@abv.bg");
        let expectedOrder = {
            orderedPizza: "Barbeque Classic",
            orderedDrink: "Water",
            email: "pesho@abv.bg",
            status: "pending"
        };
        let actualResult = instance.makeAnOrder("pesho@abv.bg", "Barbeque Classic", "Water");
        assert.equal(actualResult, 0);
        assert.equal(instance.registeredUsers[0].orderHistory.length, 1);
        expect(expectedOrder).to.deep.equal(instance.orders[0]);
    });
    it("makeAnOrder should create order and return zero without drink", () => {
        instance.registerUser("pesho@abv.bg");
        let expectedOrder = {
            orderedPizza: "Barbeque Classic",
            email: "pesho@abv.bg",
            status: "pending"
        };
        let actualResult = instance.makeAnOrder("pesho@abv.bg", "Barbeque Classic");
        assert.equal(actualResult, 0);
        expect(expectedOrder).to.deep.equal(instance.orders[0]);
    });
    it("detailsAboutMyOrder should return correct orderStatus: pending", () => {
        instance.registerUser("pesho@abv.bg");
        instance.makeAnOrder("pesho@abv.bg", "Barbeque Classic");
        let actualResult = instance.detailsAboutMyOrder(0);
        let expectedResult = `Status of your order: pending`;
        assert.equal(actualResult, expectedResult);
    });
    it("completeOrder should complete the order", () => {
        instance.registerUser("pesho@abv.bg");
        instance.makeAnOrder("pesho@abv.bg", "Barbeque Classic");
        let actualResult = instance.completeOrder();
        assert.equal(actualResult.status, "completed");
    });
})