import { Student } from "./student.model.js"; 

export function formatName(name:string):string{
    return name[0].toUpperCase()+name.substring(1);
}

export function calculateAverage(students: Student[]):number{
    let total =0;
    for(let i=0;i<students.length;i++){
        total +=students[i].marks;
    }
    return total/students.length;
}