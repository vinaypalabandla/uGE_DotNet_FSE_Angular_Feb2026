export function formatName(name) {
    return name[0].toUpperCase() + name.substring(1);
}
export function calculateAverage(students) {
    let total = 0;
    for (let i = 0; i < students.length; i++) {
        total += students[i].marks;
    }
    return total / students.length;
}
