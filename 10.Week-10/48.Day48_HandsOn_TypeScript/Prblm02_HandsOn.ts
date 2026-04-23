//Function With Required Parameters
function getWelcomeMessage(name:string):string 
{
    return `Welcome ${name}, glad to have you onboard!`;
}
//function with optional parameter
function getUserInfo(name:string, age?:number):string
{
    if(age !==undefined) {
        return `User ${name} is ${age} years old.`;

    }else {
        return `User ${name} has not provided age.`;
    }
}
//function with Default parameter
function getSubscriptionStatus(name:string, isSubscribed:boolean=false):string
{
    if(isSubscribed) {
        return name + " is subscribed";
    }else {
        return name + " is not subscribed";
    }
}
//Function with Boolean retrun tyepes
function isEligibleForPremium(age: number):boolean
{
 return age>18;
}
//Function With Arrow
const getAccountUpdate =(name:string):string=>{
    return `Hello ${name}, your account has been updated successfully.`;

};
//Lexical this Demonstration

const notificationService = {
    appName: "MyApp",

    //normal method
    sendNotification(userName:string):string{
        //arrow function inside preserve this
        const arrowFunc =():string =>{
            return `Notification from ${this.appName}: Hello ${userName}!`;
        };
        return arrowFunc();
    }
};
//Step7 Execution
console.log("============USER NOTIFICATIONS=================");

//Required
console.log(getWelcomeMessage("vinay"));

//Optional parametes
console.log(getUserInfo("vinay",22));
console.log(getUserInfo("vinay"));
//default parameters
console.log(getSubscriptionStatus("Vinay", true));
console.log(getSubscriptionStatus("Viny"));
//Boolean related return
console.log("Eligible for Premium:", isEligibleForPremium(22));
//Arrow FUnction
console.log(getAccountUpdate("vinay"));
//Lexical this
console.log(notificationService.sendNotification("vinay"));
