function cesarCrypt(text, key) {
    text = text.toUpperCase();
    let rc = '';
    for (let i = 0; i < text.length; i++) {
        let ind = (text.charCodeAt(i) - 65 + key) % 26 + 65;
        rc += String.fromCharCode(ind);
    }
    return rc;
}

function vizhenerCrypt(text, key) {
    text = text.toUpperCase();
    key = key.toUpperCase();
    let rc = '';

    while (text.length > key.length) {
        key += key;
    }
    key = key.slice(0, text.length);

    for (let i = 0; i < text.length; i++) {
        //let ind = (text.charCodeAt(i) + key.charCodeAt(i) - 130) % 26 + 65;
        //rc += String.fromCharCode(ind);
        let ind = cesarCrypt(text[i], key.charCodeAt(i) - 65);
        rc += ind;
    }
    console.log(text);
    console.log(key);
    return rc;
}

function affineCrypt(text, a, b){
    text = text.toUpperCase();
    let rc = '';
    for(let i = 0; i < text.length; i++){
        let ind = (((a * (text.charCodeAt(i) - 65)) + b) % 26) + 65;
        rc += String.fromCharCode(ind);
    }
    return rc;
}

console.log('---------- task 1 ----------');
console.log(cesarCrypt('abcdefghigklmnopqrstuvwxyz', 1));
console.log(cesarCrypt('Egwinn', 5));
console.log('---------- task 2 ----------');
console.log(vizhenerCrypt('ATTACKATDAWN', 'LEMON'));
console.log('---------- task 3 ----------');
console.log(affineCrypt('ATTACKATDAWN', 3, 4));