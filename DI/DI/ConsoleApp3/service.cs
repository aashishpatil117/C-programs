

public interface EmployeeInterface{
    List<Employee> getemployees(); 
}
public class Iemployee:EmployeeInterface{
    public List<Employee> getemployees(){
        List<Employee> emps=new List<Employee>();
        Console.WriteLine("in getemployees");
        while(true){
            Console.WriteLine("ID,Name,Salary");
            int i=Convert.ToInt32(Console.ReadLine());
            string name=Console.ReadLine();
            int s=Convert.ToInt32(Console.ReadLine());  
            emps.Add(new Employee(i,name,s));
            Console.Write("0 to exit");
            int ch=Convert.ToInt32(Console.ReadLine());
            if(ch==0){
                break;
            }
        }
        
        //emps.Add(e);
        return emps;
    }
}