// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");














public struct Complexnum
{
    public double Real { get; set; }
    public double Img { get; set; }

    // Constructor (default values)
    public Complexnum(double real = 0, double img = 0)
    {
        Real = real;
        Img = img;
    }

    // + operator
    public static Complexnum operator +(Complexnum a, Complexnum b)
    {
        return new Complexnum(a.Real + b.Real, a.Img + b.Img);
    }

    // - operator
    public static Complexnum operator -(Complexnum a, Complexnum b)
    {
        return new Complexnum(a.Real - b.Real, a.Img - b.Img);
    }

    // * operator
    public static Complexnum operator *(Complexnum a, Complexnum b)
    {
        return new Complexnum(
            a.Real * b.Real - a.Img * b.Img,
            a.Real * b.Img + a.Img * b.Real
        );
    }

    // / operator
    public static Complexnum operator /(Complexnum a, Complexnum b)
    {
        double denominator = b.Real * b.Real + b.Img * b.Img;
        return new Complexnum(
            (a.Real * b.Real + a.Img * b.Img) / denominator,
            (a.Img * b.Real - a.Real * b.Img) / denominator
        );
    }

    // == operator
    public static bool operator ==(Complexnum a, Complexnum b)
    {
        return a.Real == b.Real && a.Img == b.Img;
    }

    public static bool operator !=(Complexnum a, Complexnum b)
    {
        return !(a == b);
    }

  // (مقارنة على معيار المقياس)
    
    public double Magnitude()
    {
        return Math.Sqrt(Real * Real + Img * Img);
    }
    public static bool operator >(Complexnum a, Complexnum b)
  {
    return a.Magnitude() > b.Magnitude();
  }

    public static bool operator <(Complexnum a, Complexnum b)
    {
        return a.Magnitude() < b.Magnitude();
    }

    public static bool operator <=(Complexnum a, Complexnum b)
    {
        return a.Magnitude() <= b.Magnitude();
    }

    public static bool operator >=(Complexnum a, Complexnum b)
    {
        return a.Magnitude() >= b.Magnitude();
    }

  public override string ToString()
    {
        return $"{Real}+{Img}i";
    }
  
  
}




public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    // Constructor (default)
    public Student(int id = 0, string name = "", int age = 0)
    {
        Id = id;
        Name = name;
        Age = age;
    }

    // == operator (by Id)
    public static bool operator ==(Student a, Student b)
    {
        if (ReferenceEquals(a, b))
            return true;
        if (a is null || b is null)
            return false;
        return a.Id == b.Id;
    }

    public static bool operator !=(Student a, Student b)
    {
        return !(a == b);
    }

    // > operator (by Age)
    public static bool operator >(Student a, Student b)
    {
        return a.Age > b.Age;
    }

    public static bool operator <(Student a, Student b)
    {
        return a.Age < b.Age;
    }

    public static bool operator >=(Student a, Student b)
    {
        return a.Age >= b.Age;
    }

    public static bool operator <=(Student a, Student b)
    {
        return a.Age <= b.Age;
    }

   

   

    // Casting to int (return Id)
    public static explicit operator int(Student s)
    {
        return s.Id;
    }

    // Casting to string (return Name)
    public static implicit operator string(Student s)
    {
        return s.Name;
    }
}










