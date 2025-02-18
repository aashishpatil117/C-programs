// See https://aka.ms/new-console-template for more information
var p1=new Person("naked","snake");
var p2=new Person("solid","snake");
Console.WriteLine(p1.adsda());
p1.Snakes.Add(new Solidsnake("this is new"));
p1.Snakes.Add(new Solidsnake("New snake"));
p2.Snakes.Add(new Nakedsnake("This is old snake"));
p2.Snakes.Add(new Nakedsnake("old snake"));
List<Person> people=[p1,p2];
Console.WriteLine(people.Count);
//Console.WriteLine(p1);
foreach (var num in people){
    Console.WriteLine($"person is {num.Fn} {num.Ln}");
    foreach(var code in num.Snakes){
        Console.WriteLine($"Status is {code}");
    }
}
interface Snk{
    public String adsda();
}
public class Person(string Fullname, string Lastname):Snk{
    public string Fn{get;} = Fullname;
    public string Ln{get;} = Lastname;
    public List<Snake> Snakes{get;}=new();
    public String adsda()=>"sjas";

}
public abstract class Snake(string Codename){
    public string Fn{get;}=Codename;
    public abstract string noise();

}

public class Solidsnake(string Codename):Snake(Codename){
    public override string noise()=>"solid";
}
public class Nakedsnake(string Codename):Snake(Codename){
    public override string noise()=>"naked";
}
