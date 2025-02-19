using System.Diagnostics.Contracts;

public class EmployeeI{
    // public List<Employee> allemps(EmployeeInterface e){
    //     return e.getemployees();
    // }
    public EmployeeInterface e;
    public EmployeeI(EmployeeInterface e){
        this.e = e;
    }
    public List<Employee> getemps(){
        return e.getemployees();
    }

}