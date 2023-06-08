// See https://aka.ms/new-console-template for more information

#region Examples

using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;

Console.WriteLine("Hello, World!");
Console.WriteLine(typeof(decimal).IsPrimitive);

// bool x = default(bool);
// int y = default(int);

var child = new Child();
Obje2 obje2 = new Obje2();
obje2.Info();

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

class Class1
{
    public Class1(int a)
    {
        
    }

    public Class1()
    {

    }
}

class Class2 : Class1
{
    public Class2() : base(5)
    {
        
    }

    public Class2(int a) : base(a)
    {
        
    }
}

//It is an obligation that if ctor of parent class gets parameter, we have to use base keyword
//to inherit args from base to derived class. If it has not get parameter or it already has noArgsCtor
//it is not necessary to use base keyword.

//What are the differences between this and base keyword?

//'this' uses in the same class to switch between ctors, 'base' uses in derived classes to switch base class ctors


#endregion

class Obje
{
    public void Info()
    {
        Console.WriteLine("I'm an object");
    }
}

class Obje2 : Obje
{
    
}

sealed class X
{
    public int sayi1 { get; set; }
}

class Y //: X => sealed keyword prevents inheritance
{
    public int sayi2 { get; set; }
}

class Z : Y
{
    public int sayi3 { get; set; }
}

#region partial classes

partial class MyClass1
{
    public void A()
    {
        
    }
}

partial class MyClass1
{
    public void B()
    {
        
    }
}

#endregion