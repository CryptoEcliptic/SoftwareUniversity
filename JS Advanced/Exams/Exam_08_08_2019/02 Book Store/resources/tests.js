const { assert, expect } = require("chai");
const BookStore = require('../resources/solve');

describe("Bookstore tests", () => {
    let bookstoreInst;
    beforeEach(function () {
        bookstoreInst = new BookStore("WaterStones");
    });

    it("Assure created new bookstore", function () {
        expect(bookstoreInst.name).to.equal("WaterStones");
        expect(bookstoreInst.books).to.deep.equal([]);
        expect(bookstoreInst.workers).to.deep.equal([]);
    });
    it("Assure stock books add new book", function () {
        let expectedBook = { title: "Tressute Hunter", author: "Artor Heily" };
        bookstoreInst.stockBooks(["Tressute Hunter-Artor Heily"]);
        expect(expectedBook).to.deep.equal(bookstoreInst.books[0]);
    })
    it("Assure stock books add new books", function () {
        bookstoreInst.stockBooks(["Tressute Hunter-Artor Heily", "HomeHunter-Deloid"]);
        assert.equal(bookstoreInst.books.length, 2);
    })
    it("Assert worker is added", function () {
        let name = "Gosgo";
        let position = "Engineer";
        let expectedResult = `${name} started work at WaterStones as ${position}`;

        let actualResult = bookstoreInst.hire(name, position);
        assert.equal(bookstoreInst.workers.length, 1);
        assert.equal(expectedResult, actualResult);
    })
    it("Assert hire throws exception", function () {
        bookstoreInst.hire("Gosho", "Engineer");
        let hire = () => bookstoreInst.hire("Gosho", "Engineer");
        expect(hire).to.throw(Error, 'This person is our employee')
    })
    it("Assert fire employee throws exception", function () {
        bookstoreInst.hire("Pesho", "Engineer");
        let fire = () => bookstoreInst.fire("Gosho");
        expect(fire).to.throw(Error, `Gosho doesn't work here`)
    })
    it("Assert fire employee", function () {
        bookstoreInst.hire("Gosho", "Engineer");
        let result = bookstoreInst.fire("Gosho");
        assert.equal(bookstoreInst.workers.length, 0);
        assert.equal(result, "Gosho is fired");
    })
    it("Assert sellBook throws exception if no such employee", function () {
        bookstoreInst.stockBooks(["Book 1-Author1"]);
        bookstoreInst.hire("Gosho", "Cashier");

        let result = () => bookstoreInst.sellBook("Book 1", "Spiridon")
        expect(result).to.throw(Error, "Spiridon is not working here")
    })
    it("Assert sellBook throws exception if no such book", function () {
        bookstoreInst.stockBooks(["Book 1-Author1"]);
        bookstoreInst.hire("Gosho", "Cashier");

        let result = () => bookstoreInst.sellBook("Book 2", "Gosho")
        expect(result).to.throw(Error, "This book is out of stock")
    })
    it("Assert book is successfully sold", function () {
        bookstoreInst.hire("Gosho", "Cashier");
        bookstoreInst.stockBooks(["Book 1-Author1"]);
        bookstoreInst.sellBook("Book 1", "Gosho");
        let cashier = bookstoreInst.workers[0];

        assert.equal(cashier.booksSold, 1);
    })
    it("printWorkers should work correctly", function () {
        bookstoreInst.hire("Gosho", "Cashier");
        bookstoreInst.stockBooks(["Book 1-Author1"]);
        bookstoreInst.sellBook("Book 1", "Gosho");
        let actualResult = bookstoreInst.printWorkers();

        let expectedResult = "Name:Gosho Position:Cashier BooksSold:1"

        assert.equal(actualResult, expectedResult);
    })
})