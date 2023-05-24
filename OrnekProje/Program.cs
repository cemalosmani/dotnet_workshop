// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine(typeof(decimal).IsPrimitive);

// bool x = default(bool);
// int y = default(int);

var child = new Child();

class MyClass
{
    public int MyProperty { get; } //read-only
}

record MyRecord
{
    public int MyProperty { get; init; } //can be initialised at first creation
}

class Personel
{
    public string Adi { get; set; }
    public string Soyadi { get; set; }
    public bool MedeniHal { get; set; }
}

class Muhasebeci : Personel
{
    public bool Musavir { get; set; }
}

class Yazilimci : Personel
{
    public string Cihaz { get; set; }
}

class GrandFather
{
    public GrandFather()
    {
        Console.WriteLine($"{nameof(GrandFather)} nesnesi oluşturulmuştur.");
    }
}

class Father : GrandFather
{
    public Father()
    {
        Console.WriteLine($"{nameof(Father)} nesnesi oluşturulmuştur.");
    }
}

class Child : Father
{
    public Child()
    {
        Console.WriteLine($"{nameof(Child)} nesnesi oluşturulmuştur.");
    }
}

//Classes inherit just a class, there is only one base class.
//If i want to create a new Child object, it calls parents first(hierarchical) 
//Example: Child c = new Child(); 1. Grandfather - 2. Father - 3. Child