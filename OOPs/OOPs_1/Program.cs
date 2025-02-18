// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;


public abstract class Shape{
    public string Name {get; set;}
    public abstract double Area();
    public void display(){
        Console.WriteLine($"this is {Name}");
    }

}

public class Rectangle:Shape{
    public double length{get; set;}
    public double breadth{get; set;}
    public Rectangle(double length, double breadth){
        this.length = length;
        this.breadth = breadth;
        Name="Rectangle";
    }
    public override double Area(){
        return length*breadth;
    }
}
public class Circle:Shape{
    public double radius{get; set;}
    public Circle(double radius){
        this.radius = radius;
        Name="Circle";
    }
    public override double Area()
    {
        return 3.14*radius*radius;  
    }
}
class Program{
    public static void Main(string[] args){
        Rectangle r=new Rectangle(6, 12);
        Circle c=new Circle(8);
        Console.WriteLine(c.Area());
        Console.WriteLine(r.Area());
        c.display();
        r.display();
    }
}