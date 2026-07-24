//> npm i -g nodemon
console.log("Object Cloning");
console.log("================== 1. Spread Operator - Shallow copy");
const originalOne = { 
    id:1, 
    name: "Tom Joseph", 
    address: {street:"101, MG Road", city:"Pune", pin:412207},
    keySkills: [ 
        {"Angular":4, "specilizedSkills": [{"NgRx":2}]}, 
        {"React":5}, 
        {"ASP.NET": 5} ]
};


const clonedCopyOne = { ...originalOne } ;
clonedCopyOne.id = 45;
clonedCopyOne.name = "Alex";
clonedCopyOne.address.street = "688, Alexandar Road";
clonedCopyOne.keySkills[0].Angular = 4.8;

console.log(originalOne);
console.log(clonedCopyOne);


const clonedStructuredCopyTwo = structuredClone(originalOne);
clonedStructuredCopyTwo.address.street = "567, Tilak Road";
clonedStructuredCopyTwo.keySkills[0].Angular = 8.8;

console.log(originalOne);
console.log(clonedStructuredCopyTwo);
