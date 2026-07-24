console.log("f2: ", f2); //undefined. var variables points to arrow function can be hoisted
f1(1001);


function f1(intialValue){    
    console.log("Count: ", count); //undefined
    count = intialValue;
    console.log("Count: ", count); //1001  
    var count; //count will jump upside and reaches to the top level statement inside the function
    //Why is it working? "var" variable Hoisting

    // console.log("Name: ", name); //ReferenceError: Cannot access 'name' before initialization
    let name;
}


// f2("Good Morning"); //TypeError: f2 is not a function
var f2 = (greetMsg) => {  //It jumps to the first/ top level stmt of a current function
    console.log(greetMsg);
}
f2("Good Afternoon");


function outerF1(){
    function innerF1(intialValue){        
        console.log("Counter 2: ", counter2);
        counter2 = intialValue;
        console.log("Counter 2: ", counter2);
        var counter2; //It jumps to the top stmt of innerF1
    }
    // innerF1(9000);
    return innerF1;
}
console.log(outerF1()); //[Function: innerF1]
console.log(outerF1()(89)); //counter 2:  undefined

const resultOfOuter = outerF1(); //it returns innerF1
resultOfOuter(2001);
resultOfOuter(3001);



console.log("========================== Closure");
function outerF3(){
    let counter3 = 0 ;
    function innerF4(intialValue){        
        counter3 = (counter3==0)?intialValue: ++counter3;
        return counter3;
    }
    return innerF4;
}
console.log(outerF3()); //[Function: innerF4]
console.log(outerF3()(5001)); //5001
console.log(outerF3()(6001)); //6001

const outerF3Result = outerF3();
console.log(outerF3Result(7001)); //7001
console.log(outerF3Result(8001)); //7002
console.log(outerF3Result(9001)); //7003


console.log("---------------- setTimeout() ")
setTimeout( function f1(){ console.log("f1 is called")}, 2000); //JS doesnt implementate. Browser API has implemented this function.
setTimeout( f1B=()=>{ console.log("f1B is called")}, 500);

setTimeout( f1C=()=>{ console.log("f1C is called")}, 0);
setTimeout( f1D=()=>{ console.log("f1D is called")}, 0);
console.log("End");

