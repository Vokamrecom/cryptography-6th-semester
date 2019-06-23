const Gcd = require('./gcd');

class Inverse {
    constructor(x , y ) {
        this.x = x;
        this.y = y;
    }

    getInverseValue() {
        var i = 1;
        while (((this.x * i) % this.y )!== 1)
            i++;
        return i;
    }
}

module.exports = Inverse;