using Microsoft.Extensions.DependencyInjection;

interface IClassB {
    public void ActionB();
}

interface IClassC {
    public void ActionC(); 
}

class ClassC : IClassC
{

    public ClassC() {
        Console.WriteLine("Class C is Created");
    }
    public void ActionC()
    {
        Console.WriteLine("Action in class C");
    }

}

class ClassB : IClassB
  
{
    IClassC c_dependency;
    public ClassB(IClassC classc)
    {
        c_dependency = classc;
        Console.WriteLine("Class B Created");
    }
    public void ActionB()
    {
        Console.WriteLine("Action in class B");
      c_dependency.ActionC();
    }

} 


class ClassA 
{
    IClassB b_dependency;

    public ClassA(IClassB b_dependency)
    {
        this.b_dependency = b_dependency;
        Console.WriteLine("Class A Is Created");
    }

    public void ActionA()
    {
        Console.WriteLine("Action in  Class A");
        b_dependency.ActionB();
    }

}

class ClassC1 : IClassC
{
    public ClassC1() => Console.WriteLine("ClassC1 is created");
    public void ActionC()
    {
        Console.WriteLine("Action in C1");
    }
}

class ClassB1 : IClassB
{
    IClassC c_dependency;
    public ClassB1(IClassC classc)
    {
        c_dependency = classc;
        Console.WriteLine("ClassB1 is created");
    }
    public void ActionB()
    {
        Console.WriteLine("Action in B1");
        c_dependency.ActionC();
    }
}

class ClassB2 : IClassB
{
    IClassC c_dependency;
    string message;

    public void ActionB(IClassC classc,string mess)
    {
        c_dependency = classc;
        message= mess;
        Console.WriteLine("Class B2 is created!");
    }

    public void ActionB()
    {
        Console.WriteLine(message);
        c_dependency.ActionC();
    }
}



public class Program{
    public static void AutoInject(ServiceCollection services)
    {
        //DK cac dich vu ...
        // IClassC,ClassC,ClassC1
        //singleton

        services.AddScoped<IClassC, ClassC>();
        services.AddTransient<IClassB, ClassB>();


        var provider = services.BuildServiceProvider();
        //var a = provider.GetServices<TenService>();

        var classc = provider.GetService<IClassC>();

        for (int i = 0; i < 5; i++)
        {
            IClassC c = provider.GetService<IClassC>();
            Console.WriteLine(c.GetHashCode());
        }

        //var classb = provider.GetService<IClassB>();
        for (int i = 0; i < 5; i++)
        {
            IClassB b = provider.GetService<IClassB>();
            Console.WriteLine(b.GetHashCode());
        }
    }

    static void autoInject(ServiceCollection services)
    {

        services.AddSingleton<ClassA, ClassA>();
        services.AddSingleton<IClassB, ClassB>();
        services.AddSingleton<IClassC, ClassC1>();

        var provider = services.BuildServiceProvider();

        ClassA a = provider.GetService<ClassA>();
        a.ActionA();



    }
    static void Main(string[] args)
    {
        //Th vien Dependency Injection
        //DI Container : SevicesCollection
        // -DK cac dich vu (lop)
        // - Service Provider -> GetServices

        var services = new ServiceCollection();


        services.AddSingleton<string,string>();


        var provider = services.BuildServiceProvider(); 



       
    }
}
