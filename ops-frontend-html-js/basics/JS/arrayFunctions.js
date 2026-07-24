
console.log("----------------------- Array Functions");
[].map( ()=>{} );
const result1 = ["Pune", "Chennai"].map( (ele)=>{ console.log(ele)} );



const cityData = [
    {city:"Pune", avgIncome: 1500000.00},
    {city:"Chennai", avgIncome: 1800000.00},
    {city:"Hyderabad", avgIncome: 2000000.00},
];

const cityWiseIncome = cityData.map( (ele)=> 
    {
        if (ele.avgIncome > 1500000) 
        {
            ele.expectedAvgTax = 0.20;
        }
        return ele;
    });
console.log("Map::::: ", cityWiseIncome);

const filteredCityWiseIncome = cityData.filter( (ele)=> 
    {
        if (ele.avgIncome > 1500000) 
        {
            ele.expectedAvgTax = 0.20;
            return ele;
        }
        
    });
console.log("filteredCityWiseIncome:::::: ", filteredCityWiseIncome);



const firstMatchingCityIncome = cityData.find( (ele)=> 
    {
        if (ele.avgIncome > 1500000) 
        {
            ele.expectedAvgTax = 0.20;
            return ele;
        }
        
    });
console.log("find firstMatchingCityIncome:::::: ", firstMatchingCityIncome);