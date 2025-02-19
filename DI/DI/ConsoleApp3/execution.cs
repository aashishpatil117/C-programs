
public class Program{
    public static void Main(string[] args){
        //Iemployee i=new Iemployee();
        EmployeeI ie=new EmployeeI(new Iemployee());
        List<Employee> l=ie.getemps();
        Console.WriteLine("in main");
        foreach(var a in l){
            Console.WriteLine($"Name={a.Name}\nId={a.Id}\n");
        }
    }

}