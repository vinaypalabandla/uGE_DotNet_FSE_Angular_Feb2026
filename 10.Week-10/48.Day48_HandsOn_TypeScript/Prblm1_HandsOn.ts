// Variable Declaration 
const userName: string = "Vinay";
let age: number = 22;
const email: string = "vinay@gmail.com";
const isSubscribed: boolean = true;

// Type Inference
let city = "Bangalore";
let loginCount = 5;

// Template Literals use chesam
let userProfileMessage: string = `Hello ${userName}, you are ${age} years old and your email is ${email}.`;

// Operators
age = age + 1;

// Comparison operator
let isAdult: boolean = age >= 18;

// Logical operator
let isEligibleForPremium: boolean = age > 18 && isSubscribed;

// Update message after increment
userProfileMessage = `Hello ${userName}, you are now ${age} years old and your email is ${email}.`;

// Output
console.log("===== USER PROFILE DETAILS =====");
console.log("User Name:", userName);
console.log("Age:", age);
console.log("Email:", email);
console.log("Subscribed:", isSubscribed);

console.log("\n===== INFERRED VARIABLES =====");
console.log("City:", city);
console.log("Login Count:", loginCount);

console.log("\n===== PROFILE MESSAGE =====");
console.log(userProfileMessage);

console.log("\n===== STATUS CHECK =====");
console.log("Is Adult:", isAdult);
console.log("Eligible for Premium:", isEligibleForPremium);