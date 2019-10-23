const { assert } = require('chai');
const StringBuilder = require('../05StringBuilder/index');

describe('String builderTests', () => {
    let sbInst;
    beforeEach(() => {
        sbInst = new StringBuilder();  
    });

    it('Append element ', () => {
        sbInst.append('ab');
        let actualResult = sbInst.toString();
        assert.equal(actualResult, 'ab')
    });

    it('No params passed', () => {
        sbInst.append('');
        let actualResult = sbInst.toString();
        assert.equal(actualResult, '');
    })

    it('Throw TypeError', () => {
        let actualResult = sbInst.append;
        assert.throw(() => { actualResult(1); }, 'Argument must be string');
    });

    it('Prepend element', () => {
        sbInst.prepend('ab');
        let actual = sbInst.toString();
        assert.equal(actual, 'ab');
    })

    it('Insert element should return C at index 1', () => {
        sbInst.append('ab');
        sbInst.insertAt('C', 1)
        let actualRes = sbInst.toString()[1];
        assert.equal(actualRes, 'C')
    });

    it('Insert "a" on index -2)', () => {
        sbInst.insertAt('a', -2);
        const act = sbInst.toString();
        assert.equal(act, 'a');
    });

    it('Remove elements should return \'abefgh\'', () => {
        sbInst.append('abcdefgh');
        sbInst.remove(2, 2)
        let actualRes = sbInst.toString();
        assert.equal(actualRes, 'abefgh')
    })

    it('Is return string representation', () => {
        instance = new StringBuilder('text');
        const act = instance.toString();
        assert.equal(act, 'text');
    });

    it('typeof is object', () => {
        assert.typeOf(sbInst, 'object');
    });

    it('several test',() => {
        let sb = new StringBuilder('B');
        sb.append("Rad");
        sb.append("Vas");
        sb.insertAt('ilev', 6);
        sb.remove(6, 4);
        let actResult = sb.toString();
        assert.equal(actResult, 'BRadVas')
    });
})