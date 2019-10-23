const {assert} = require('chai');
const mathEnforcer = require('../04MathEnforcer/index');

describe('Math enforcer tests', () => {

    it('addFive invlid parameter type', () => {
        assert.equal(mathEnforcer['addFive']('5'), undefined)
    });

    it('addFive returns 10', () => {
        assert.equal(mathEnforcer['addFive'](5), 10)
    });

    it('addFive returns 10.5', () => {
        assert.equal(mathEnforcer['addFive'](5.5), 10.5)
    });

    it('addFive returns 0 when negative param passed', () => {
        assert.equal(mathEnforcer['addFive'](-5), 0)
    });

    it('addFive returns -5.5 when negative param passed', () => {
        assert.equal(mathEnforcer['addFive'](-5.5), -0.5)
    });

    it('addFive returns undefined when no param passed', () => {
        assert.equal(mathEnforcer['addFive'](), undefined)
    });

    it('subtractTen invlid parameter type', () => {
        assert.equal(mathEnforcer['subtractTen']('5'), undefined)
    });

    it('subtractTen returns zero', () => {
        assert.equal(mathEnforcer['subtractTen'](10), 0)
    });

    it('subtractTen returns 1.5', () => {
        assert.equal(mathEnforcer['subtractTen'](11.5), 1.5)
    });

    it('subtractTen returns -11', () => {
        assert.equal(mathEnforcer['subtractTen'](-1), -11)
    });
   
    it('sum invlid parameter type', () => {
        assert.equal(mathEnforcer['sum']('5', 6), undefined)
    });

    it('sum invlid parameter type second param', () => {
        assert.equal(mathEnforcer['sum'](5, '6'), undefined)
    });

    it('sum should return 10', () => {
        assert.equal(mathEnforcer['sum'](5, 5), 10)
    });

    it('sum should return 10.5', () => {
        assert.equal(mathEnforcer['sum'](5, 5.5), 10.5)
    });

    it('sum should return 11', () => {
        assert.equal(mathEnforcer['sum'](5.5, 5.5), 11)
    });
})