const {
    GetNumberByMod
} = require('./Lab5');

function isPrimeNumber(number) {
    for (let i = 2; i < number / 2; ++i)
        if (number % i === 0)
            return false;
    return true;
}

function RSA({
    n,
    e,
    d
}, message) {
    let crypto = "";
    const positionA = 'A'.charCodeAt(0);
    for (let i = 0, {
            length
        } = message; i < length; ++i) {
        const alphabetPosition = (message.charCodeAt(i) - positionA) + 1;
        crypto += String.fromCharCode((Math.pow(alphabetPosition, e) % n) - 1 + positionA);
        //crypto += String.fromCharCode(Math.pow(message.charCodeAt(i), e) % n);
    }
    return crypto;
}

function DecryptRSA({
    n,
    e,
    d
}, message) {
    let crypto = "";
    const positionA = 'A'.charCodeAt(0);
    for (let i = 0, {
            length
        } = message; i < length; ++i) {
        const alphabetPosition = (message.charCodeAt(i) - positionA) + 1;
        crypto += String.fromCharCode((Math.pow(alphabetPosition, d) % n) - 1 + positionA);
        //crypto += String.fromCharCode(Math.pow(message.charCodeAt(i), e) % n);
    }
    return crypto;
}

function ElGamalInit() {
    const [p, g, x] = [11, 2, 8];
    const y = Math.pow(g, x) % p;
    return {
        p,
        g,
        x,
        y
    }
}

function ElGamalSymbol({
    p,
    g,
    x,
    y
}, message) {
    const k = Math.round(Math.random() * (p - 1));
    const a = Math.pow(g, k) % p;
    const b = (Math.pow(y, k) * message) % p;
    return {
        a,
        b
    };
}

function ElGamal(keys, message) {
    const encrypt = [];
    for (let i = 0, {
            length
        } = message; i < length; ++i) {
        encrypt.push(ElGamalSymbol(keys, message[i]));
    }
    return encrypt;
}

function ElGamalDecrypt(keys, message) {
    const decrypt = [];
    for (let i = 0, {
            length
        } = message; i < length; ++i) {
        decrypt.push(ElGamalSymbolDecrypt(keys, message[i]));
    }
    return decrypt;
}

function ElGamalSymbolDecrypt({
    p,
    g,
    x,
    y
}, {
    a,
    b
}) {
    const m = b * Math.pow(a, p - 1 - x) % p;
    return m;
}

function RSAInit(randomPrimeNumber1,
    randomPrimeNumber2) {
    if (typeof randomPrimeNumber1 !== 'number' ||
        typeof randomPrimeNumber2 !== 'number') throw new Error('Bad type of params');
    if (!isPrimeNumber(randomPrimeNumber1) || !isPrimeNumber(randomPrimeNumber2))
        throw new Error('Numbers are not prime');
    const n = randomPrimeNumber1 * randomPrimeNumber2;
    const fn = (randomPrimeNumber1 - 1) * (randomPrimeNumber2 - 1);
    const e = 7;
    const d = GetNumberByMod(e, fn);
    return {
        n,
        e,
        d
    };
}

const keys = RSAInit(3, 11);
const encryptMessage = RSA(keys, 'BSTU,BSUIR,BSU');

console.log(encryptMessage);
console.log(DecryptRSA(keys, encryptMessage));
const keysElGamal = ElGamalInit();

const encryptElGamal = ElGamal(keysElGamal, [1, 2, 3, 4, 6]);
console.log(encryptElGamal);
console.log(ElGamalDecrypt(keysElGamal, encryptElGamal));


