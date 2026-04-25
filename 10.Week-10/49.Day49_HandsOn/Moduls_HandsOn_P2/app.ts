import { Student } from "./student.model.js";
import { getGrade, getTopper } from "./student.service.js";
import { formatName,calculateAverage } from "./utilis.js";

const students: Student[] =[
    {id:101, name:"vinay",marks:85},
    {id:102,name:"ramu",marks:92},
    {id:103,name:"rekha",marks:70}
];

//now print the formated print
console.log("Formatted Names: ");
for(let i=0;i<students.length;i++){
    console.log(formatName(students[i].name));
}

//print grades
console.log("Grades:");
for(let i=0;i<students.length;i++){
    console.log(formatName(students[i].name)+ ": " + getGrade(students[i].marks));
}
//Average
const topper = getTopper(students);
console.log("\nTopper:", formatName(getTopper.name), topper.marks);