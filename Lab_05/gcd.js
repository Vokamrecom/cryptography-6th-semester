class GCD {
    constructor(x = 0, y = 0) {
        this.x = x;
        this.y = y;
    }

    setX(x) {
        this.x = x;
    }

    setY(y) {
        this.y = y;
    }

    getGcd() {
        while (this.x !== 0 && this.y !== 0) {
            if (this.x > this.y) {
                this.setX(this.x % this.y);
            } else {
                this.setY(this.y % this.x);
            }
        }
        return this.x + this.y
    }
}

module.exports = GCD;