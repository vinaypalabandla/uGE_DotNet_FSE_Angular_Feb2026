//Employee Managemet
//Employee is the  Base Class

class Employee {
    public id:number;
    protected name:string;
    private salry:number;
      //constructor using
    constructor(id:number,name:string,salary:number){
        this.id = id;
        this.name = name;
        this.salry=salary;
    }
    //getter and Setter
    public getSalary():number{
        return this.salry;
    }
    public setSalary(value:number):void{
        if(value>0){
            this.salry=value;
        }else {
            console.log("Salary must be greater than 0");
        }
    }
    //Method
    public displayDetails():void {
        console.log("Employee ID:",this.id);
        console.log("Name:", this.name);
        console.log("Salary:",this.salry);

    }
}
class Manager extends Employee {
    public teamSize:number;

    constructor(id:number,name:string,salry:number,teamSize:number){
        super(id, name,salry);
        this.teamSize =teamSize; //invoke the parent constructor
    }
    //method overiding
    public displayDetails():void{
        super.displayDetails();//calll the parent method
        console.log("Team Size:", this.teamSize);
    }
}
//object creation 
const emp1 = new Employee(1, "Vinay", 30000);
const mgr1 = new Manager(2, "VinayKumar", 50000, 5);
//using methods
console.log("===== EMPLOYEE DETAILS =====");
emp1.displayDetails()
//Getter And Setters
emp1.setSalary(350000);
console.log("Updated Salary:",emp1.getSalary());

console.log("\n=======Manager Details========");
mgr1.displayDetails();
