// See https://aka.ms/new-console-template for more information
public interface wordprocess{
    public string process(string word);
}
public class upcasecheck:wordprocess{
    
        public string process(string word)
        {
            return word.ToUpper();
        }
}
public class censor:wordprocess{
    public string[] censors={"word1","word2"};
    public string process(string word){
        foreach(var s in censors){
            word=word.Replace(s,"*****");
        }
        return word;
    }

}
public class app{
    private List<wordprocess> wp=new List<wordprocess>();
    public app(){
        wp.Add(new censor());
        wp.Add(new upcasecheck());
    }
    public void sendmessage(string m){
        foreach(var s in wp){
            m=s.process(m);
        }
        Console.WriteLine($"message \"{m}\" was sent");
    }

}
class Program{
    public static void Main(string[] args){
    app app1 = new app();
    app1.sendmessage("this is a word1");
   }
}
