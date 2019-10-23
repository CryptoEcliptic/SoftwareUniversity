const {assert} = require('chai');
const lookupChar = require('../03CharLookup/index');

describe("Char lookup tests", () =>{

    it('Invalid first string param', () => {
        assert.equal(lookupChar(6, 4), undefined);
    });
    it('Invalid second number param', () => {
        assert.equal(lookupChar('someString', '4'), undefined);
    });
    it('Invalid sparams', () => {
        assert.equal(lookupChar(3, '4'), undefined);
    });
    it('Invalid index range', () => {
        assert.equal(lookupChar('someString', -1), "Incorrect index");
    })
    it('Invalid index', () => {
        assert.equal(lookupChar('someString', 6.2), undefined);
    })
    it('Invalid index out of range', () => {
        assert.equal(lookupChar('someString', 11), "Incorrect index");
    })
    it('Second index returns valid result', () => {
        assert.equal(lookupChar('someString', 2), "m");
    })
})