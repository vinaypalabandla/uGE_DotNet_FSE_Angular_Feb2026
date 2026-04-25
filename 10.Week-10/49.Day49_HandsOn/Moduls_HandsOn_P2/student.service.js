import { PASS_MARKS } from "./constants.js";
export function getGrade(marks) {
    if (marks >= 90)
        return "A";
    else if (marks >= 75)
        return "B";
    else if (marks >= 60)
        return "C";
    else if (marks >= PASS_MARKS)
        return "D";
    else
        return "Fail";
}
export function getTopper(students) {
    if (students.length === 0) {
        throw new Error("No student");
    }
    let top = students[0];
    for (const student of students) {
        if (student.marks > top.marks) {
            top = student;
        }
    }
    return top;
}
