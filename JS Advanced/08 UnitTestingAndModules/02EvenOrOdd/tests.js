const isOddOrEven = require ('../02EvenOrOdd/index');
const { assert } = require('chai');

describe('Even or odd', () => {

    it('Is Odd', () => {
        assert.equal(isOddOrEven('foo'), 'odd')
    });

    it('Is even', () => {
        assert.equal(isOddOrEven('bary'), 'even')
    })
    it('Is undefined', () => {
        assert.equal(isOddOrEven(6), undefined)
    })
})
