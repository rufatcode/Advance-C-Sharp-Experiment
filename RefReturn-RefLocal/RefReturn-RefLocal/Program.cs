// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Dynamic;
using System.Reflection;
using System.Text.Json;
#region Ref Return
/*
//Console.WriteLine("Hello, World!");

//ref int GetIntReferances(ref int a)
//{
//    a = 7;
//    return ref a;
//}

//int a = 10;
//ref int c=ref GetIntReferances(ref a);
//c++;
//Console.WriteLine(a);

//ref int GetArr(int[] arr)
//{
//    arr[0] = 10;
//    return ref arr[0];
//}

//int[] arr = { 3, 4, 5, 6 };
//ref int newItem =ref GetArr(arr);
//Console.WriteLine(newItem);
//newItem = 15;
//Console.WriteLine(arr[0]);


//Person person = new Person();
//person.a = 10;
//ref int b =ref person.GetValue();
//b = 15;
//Console.WriteLine(person.a);

//public class Person
//{
//    public int a;
//    public ref int GetValue()
//    {
//        return ref a;
//    }
//}

//int a = 10;

//ref int b = ref a;

//b = 15;

//Console.WriteLine(a);

//Console.WriteLine(4>>3);
Book book1 = new() { Name = "book1", AuthorName = "Author1" };
Book book2 = new() { Name = "book2", AuthorName = "Author2" };
Book book3 = new() { Name = "book3", AuthorName = "Author3" };

Student student1 = new() { Name="student1",Id=1};
student1=student1 + book1;
student1=student1 + book2;
student1=student1 + book3;
student1.Id = 1;
Student student2 = new() { Name = "student2", Id = 4};
Student student3 = new() { Name = "student3", Id =12};
Student student4 = new() { Name = "student4", Id =5};
student2++;
Console.WriteLine(student2.Id);
//if (student3)
//{
//    Console.WriteLine(student1.Name);
//}
//foreach (var item in student1.Books)
//{
//    Console.WriteLine(item.AuthorName+" "+item.Name);
//}
class Book
{
    public string Name { get; set; }
    public string AuthorName { get; set; }
}
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Book> Books { get; set; } = new();
    public static Student operator +(Student student,Book book)
    {
        student.Books.Add(book);
        return student;
    }
    public static bool operator true(Student student)
    {
        return student.Id>5;
    }
    public static bool operator false(Student student)
    {
        return student.Id<=5;
    }
    public static Student operator ++(Student student)
    {
        student.Id++;
        return student;
    }
    public static Student operator --(Student student)
    {
        student.Id--;
        return student;
    }
}
*/
#endregion

#region Impisit and Expilisit operators
/*
Manat manat = new Dollar(10);
Manat manat1 = (Manat)new Dollar(10);

Dollar dollar = (Dollar)new Manat(10);

Console.WriteLine(manat.Price);
class Manat
{
    public double Price { get; set; }
    public static implicit operator Dollar(Manat manat)
    {
        return new Dollar(manat.Price / 1.7);
    }
    public Manat(double price)
    {
        this.Price = price;
    }
}
class Dollar
{
    public double Price { get; set; }
    public static implicit operator Manat(Dollar dollar)
    {
        return new Manat(dollar.Price * 1.7);
    }
    public Dollar(double price)
    {
        this.Price = price;
    }
}

*/
#endregion

#region Exception Handling
/*

string Call()
{
    try
    {
        Console.WriteLine("enter key");
        var key = Console.ReadKey();
        int a = 10;
        int b = 0;
        if (key.Key == ConsoleKey.Y)
        {
            Console.WriteLine(a/b);
            throw new CustomException("this is not okay");
        }
        return "try";

    }
    catch (Exception ex)
    {
        return ex.Message;
    }
    finally
    {
        Console.WriteLine("\ncatch");
    }

}

Console.WriteLine(Call());

class CustomException : Exception
{
    public CustomException():base("something went wrong")
    {

    }
    public CustomException(string message):base(message)
    {

    }
}

*/
#endregion

#region Dynamic Object and class field Creation
/*
//1)
Type type = typeof(Person);
Person person2 = (Person)Activator.CreateInstance(type);

//2)
dynamic person = new Person();
person.Price = 100;
person.Name = "Person1";
person.GetProperties();
//3)
dynamic person1 = new ExpandoObject();
person1.Name = "Person1";
person1.Age = 22;
Console.WriteLine(person1.Age);
class Person:DynamicObject
{
    private Dictionary<string, object> properties = new();

    public void GetProperties()
    {
        properties.ToList().ForEach(item =>
        {
            Console.WriteLine("Key:"+item.Key+"\nValue:"+item.Value);
        });
    }

    public override bool TrySetMember(SetMemberBinder binder, object? value)
    {
        properties.Add(binder.Name, value);
        return true ;
    }
    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        return properties.TryGetValue(binder.Name, out result);
    }
}
*/
#endregion


#region Generic
/*
void Test<T>(T a) where T : IMyInterface { }
E<A>.G<B> g = new();

Test<MyRecord>(new());
class MyClass { }
interface IMyInterface { }
record MyRecord:IMyInterface { }
struct MyStruct { }
enum MyEnum { }
static class MyStaticClass { }
abstract class MyAbstractClass {
    public abstract void MyAbstractMethod<T>();
}
class A { }
class B:A { }
class C : IMyInterface { }
class D : MyAbstractClass {
    public override void MyAbstractMethod<T>() where T:default
    {
        throw new NotImplementedException();
    }
}

class E<T>
{
    public class G<T1>where T1:T
    {

    }
}

*/
#endregion

#region Converiance Contravariance
/*
object[] arr = new string[5];

IEnumerable<Animal> animals = new List<Cat>();
Animal[] animals1 = new Cat[] { };

arr[0] = "salam";
//arr[1] = true; //exception

Func<C> func = CallD; //coveriance
D CallD() => new();


Action<string> action = CallStr;//contravariance
void CallStr(object obj) { }

Action<Cat> action1 = CallC;//contravariance
void CallC(Animal c){ }

void Method1(string word) { };
IEnumerable<object> data = new List<string>();//coveriance



IInterface<object> a = new B<object>(); //bu mümkündü amma onjecte string reference vermey istesem bu zaman out dan istifade edirem
IInterface<object> a1 = new B<string>();//coveriance

Func<Animal> func1 = GetCat; //coveriance
Cat GetCat() { return new(); }

IInterface1<Cat> interface1 = new A<Animal>();//contravariance
//IInterface1<Animal> interface2 = new A<Cat>();//coveriance

XHandler < C > del1 = GetA;
XHandler < D > del2 = GetD;
del1 = del2; //bu coveriance prosesi icra ede bilmey ucun delegatede generic tipin qarsisina out yazmaq vacibdir

YHandler<C> del3 = GetA1;
YHandler<D> del4 = GetD1;
del4 = del3;//contravariance
void GetA1(C a) { }
void GetD1(D d) { }

C GetA() { return new(); }
D GetD() { return new(); }
delegate T XHandler<out T>();


delegate void YHandler<in T>(T a);

interface IInterface1<in T> { };

interface IInterface<out T> { }

class A<T>:IInterface1<T> { }
class B<T> : A<T>,IInterface<T> { }


class C { }
class D : C { }


class Animal { }
class Cat : Animal { }

*/
#endregion

#region Delegates
/*
void AMethod() { Console.WriteLine("Method A"); }
void BMethod() { Console.WriteLine("Method A"); }
void CMethod() { Console.WriteLine("Method A"); }
void EMethod( ZHandler zHandler,string a)
{
    if (zHandler(a))
    {
        Console.WriteLine("okay");
    }
    else
    {
        Console.WriteLine("No");
    }
}
Person DMethod(int a, string b)
{
    Console.WriteLine("Person Method");
    return new();
}
EMethod(x=>x.Length>7, "sasasa");
XHandler xHandler = new(AMethod);
xHandler += () =>
{
    Console.WriteLine("Arrow functiom");
};
xHandler -= AMethod;
//xHandler();
YHandler<Person, int, string> yHandler = new(DMethod);
yHandler += delegate (int a, string b) { return new(); };

Delegate[] data = xHandler.GetInvocationList();

foreach (var item in data)
{
    //Console.WriteLine(item.Method.Name);
}
delegate T1 YHandler<out T1,in T2,in T3>(T2 a,T3 b);
delegate void XHandler();
delegate bool ZHandler(string c);
class Person { }
*/
#endregion

#region Events
/*
MyPublisher myPublisher = new();
void A()
{
    Console.WriteLine("Method A");
}
void B()
{
    Console.WriteLine("Method B");
}

MyPublisher.XHandler xHandler = new(A);
xHandler += B;

//xHandler();

//myPublisher.Handler = new(A);
//myPublisher.Handler += B;
//myPublisher.Handler();

myPublisher.MyEvent += A;
myPublisher.MyEvent += B;
myPublisher.MyEvent -= B;
myPublisher.Control();

class MyPublisher
{
    public delegate void XHandler();
    private XHandler Handler;
    public event XHandler MyEvent
    {
        add
        {
            Handler += value;
            Console.WriteLine(value.Method.Name+"Added  to Event");
        }
        remove
        {
            Handler -= value;
            Console.WriteLine(value.Method.Name+" removed from event");
        }
    }

    public void Control()
    {
        Handler();
        
    }
}
*/
#endregion

#region Lamda Discart experssion
/*
Func<int, string, char, int> func = (i, s, c) => s.Length;
Console.WriteLine(func(1,"sdsds",'s'));

Func<int, string, char, int> func1 = (_, s, _) => s.Length;
Console.WriteLine(func(1, "sdsds", 's'));
*/
#endregion

#region ExpandoObject
/*
dynamic person = new ExpandoObject();
person.Name = "Rufat";
person.SureName = "Ismayilov";


dynamic person1 = new ExpandoObject();
person.Name = "Asim";
person.SureName = "Azizov";


dynamic person2 = new ExpandoObject();
person.Name = "Qismet";
person.SureName = "Majidov";

List<ExpandoObject> list = new List<ExpandoObject> { person, person1, person2 };

IDictionary<string, object> expandoObj = (IDictionary<string, object>)person;

foreach (KeyValuePair<string,object> item in expandoObj)
{
    Console.WriteLine(item.Key+" "+item.Value);
}

var serializeObj = JsonSerializer.Serialize(person);
Console.WriteLine(serializeObj);

dynamic deserializeData = JsonSerializer.Deserialize<ExpandoObject>(serializeObj);
Console.WriteLine(deserializeData.Name);
*/
#endregion


#region Hazir Interfacelər
//IComarer
/*
Person person1 = new() { Name = "Person1", Age=22 };
Person person2 = new() { Name = "Person2", Age=26 };
Person person3 = new() { Name = "Person3", Age=18 };
Person person4 = new() { Name = "Person4", Age=28 };
Person person5 = new() { Name = "Person5", Age=15 };
PersonCompare personCompare = new();

List<Person> arr = new List<Person>{ person1, person2,person3,person4,person5 };

arr.Sort(personCompare);

Console.WriteLine(personCompare.Compare(person1,person2));
Console.WriteLine("--------");
foreach (var item in arr)
{
    Console.WriteLine(item.Name);
}
*/

//IComperable
/*
Person person1 = new() { Name = "Person1", Age = 22 };
Person person2 = new() { Name = "Person2", Age = 26 };
Person person3 = new() { Name = "Person3", Age = 18 };
Person person4 = new() { Name = "Person4", Age = 28 };
Person person5 = new() { Name = "Person5", Age = 15 };

Console.WriteLine(person1.CompareTo(person5));

Console.WriteLine("----------------");

List<Person> arr = new List<Person> { person1, person2, person3, person4, person5 };
arr.Sort();

foreach (var item in arr)
{
    Console.WriteLine(item.Name);
}
*/


//IClonable
/*
Person person1 = new() { Name = "Person1", Age = 22 };

Person person = person1.Clone() as Person;
Console.WriteLine(person.Age);
*/

//IEnumerable
/*
Person person1 = new() { Name = "Person1", Age = 22 };
person1.data=person1.Where(p => p.Contains("a")).ToList();
foreach (var item in person1)
{
    Console.WriteLine(item);
}
*/

//IDisposable
/*
using Person person1 = new() { Name = "Person1", Age = 22 };
Person person2 = new() { Name = "Person2", Age = 22 };
person2.Dispose();
for (int i = 0; i < 5; i++)
{
    new Person();
    
}
GC.Collect();









class Person : ICloneable, IEnumerable<string>,IDisposable
{
    public string Name { get; set; }
    public int? Age { get; set; }
    public List<string> data { get; set; } = new List<string> { "apple", "orange", "onion", "cucumber", "tomoto", "carrot" };
    public object Clone()
    {
        return new Person() { Name = this.Name, Age = this.Age + 10 };
    }

    public void Dispose()
    {

        Name = null;
        Age = null;
        data = null;
        GC.SuppressFinalize(this);
        Console.WriteLine("dispose is work");
    }
    ~ Person()
    {
        
        Dispose();
        Console.WriteLine("object is removed");
    }
    public IEnumerator<string> GetEnumerator()
    {
        return data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}


//class PersonCompare : IComparer<Person>
//{
//    public int Compare(Person? x, Person? y)
//    {
//        return x.Age.CompareTo(y.Age);
//    }
//}
//class Person:IComparable<Person>
//{
//    public string  Name { get; set; }
//    public int Age { get; set; }

//    public int CompareTo(Person? other)
//    {
//        return this.Age.CompareTo(other.Age);
//    }
//}


*/

#endregion

#region IEnumerable,IEnumerator
/*

class StockEnumerator : IEnumerator<int>
{
    public int Current => _data[CurrentIndex];
    public int CurrentIndex { get; set; } = -1;
    private List<int> _data;

    object IEnumerator.Current => _data[CurrentIndex];

    public StockEnumerator(List<int> data) => _data = data;

    public void Dispose()
    {
        _data = null;
        GC.SuppressFinalize(this);
    }

    public bool MoveNext()
    {
        CurrentIndex += 2;
        return CurrentIndex < _data.Count;
    }

    public void Reset()
    {
        CurrentIndex = -1;
    }
}
class Stock
{
    public List<int> numbers = new List<int> { 6,12,9,33,5,1,3,54,23,18};
    public void Add(int num)
    {
        numbers.Add(num);
    }
    public IEnumerator<int> GetEnumerator()
    {
        return new StockEnumerator(numbers);
    }
}

*/
#endregion

#region Collection Initialazers

/*
Person person = new() {
    {1,"sasa" },
    {2,"sdsds" },
    4,
    "hello",
    (21,'d',"dsds"),
    (44,'u',"gfh"),
    

};

foreach (var item in person)
{
    Console.WriteLine(item);
}

class Person:IEnumerable<int>
{
    public string Name { get; set; }
    public List<int> Ages { get; set; } = new();
    public List<string> Names { get; set; } = new();
    public void Add(int age,string s)
    {
        Ages.Add(age);
        Names.Add(s);
    }
    public void Add(int age)
    {
        Ages.Add(age);
    }
    public void Add(string name)
    {
        Names.Add(name);
    }
    public void Add((int i, char c, string s) t)
    {
        Ages.Add(t.i);
        Names.Add(t.s);
    }
    public IEnumerator<int> GetEnumerator()
    {
        return Ages.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Ages.GetEnumerator();
    }
}
*/
#endregion


