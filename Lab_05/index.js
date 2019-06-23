
let r, x;

function gcd(a, b, a1, b1)
{//11=4*2+3
    console.log("a=",a);
    console.log("b=", b);
    r = b % a;//остаток
    x = ( b - r ) / a;//коэф
    console.log("r=",r);
    console.log("x=", x);
    console.log("a1=",a1);
    console.log("b1=", b1);
    if( (a1*x)%b1 === 1 ){
        console.log(x);
        return x;
    }
    else if(-((a1*x)%b1) + b1 === 1){
        x=-1*x;
        console.log(x);
        return x;
    }
    console.log("-------------");
    gcd(r, a, a1, b1);//a=r; b=a
}

gcd(4, 11, 4, 11);
//gcd(4, 5, 4, 5);




// const Gcd = require('./gcd');
// const Inverse = require('./inverse')
//
// let gcd = new Gcd(x = 7, y = 17);
// console.log(`НОД ${x} и ${y} = ${gcd.getGcd()}`)
//
// let a = 7, b =17;
// let inverse = new Inverse(a, b);
// gcd.setX(a);
// gcd.setY(b);
// let g = inverse.getInverseValue();
// if (gcd.getGcd() !== 1) {
//     console.log('Обратного элемента не существует');
// } else {
//     console.log(`Обратный элемент: ${g}`);
// }