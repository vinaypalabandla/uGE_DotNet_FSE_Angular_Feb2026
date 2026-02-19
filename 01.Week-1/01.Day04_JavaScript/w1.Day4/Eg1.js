
let uid = 'admi';
let pwd = 'admin123';

if(uid === "admin" && pwd == "admin123"){
    console.log("valid login");
}else {
    console.log("invalid login");
}


////////////////////////

function calculate() {

  // Read values from DOM
  let x = Number(document.getElementById("num1").value );// input data provide
  let y = Number( document.getElementById("num2").value ); // input data provide
  let operator = document.getElementById("operator").value;

  let result;

  // Switch Case
  switch (operator) {
    case "+":
      result = x + y;
      break;

    case "-":
      result = x - y;
      break;

    case "*":
      result = x * y;
      break;

    case "/":
      result =   num1 / num2 ;
      break;

    default:
      result = "Invalid Operation";
  }

  // Display result
  document.getElementById("result").innerText = "Result: " + result;
   // inner text use for it visible inside result
}
