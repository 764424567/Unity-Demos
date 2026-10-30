using HaiLan.TestReflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class InvokeReflection : MonoBehaviour
{
    void Start()
    {
        Learn00();
        //Learn01();
        //Learn02();
        //Learn03();
    }


    public void Learn00()
    {
        /*
         *System.Reflection.Assembly类有两个静态方法：Assembly.Load(string assemblyname)和Assembly.LoadFrom(string filename) 。
         * 通常用这两个方法把程序集加载到应用程序域中。 如果你希望加载的程序集超出了CLR的预定探查范围，你可以用 Assembly.LoadFrom直接从一个文件位置加载程序集。
         * Assembly.LoadFrom()和Assembly.LoadFile()，两者的主要区别有两点：
         * 一：Assembly.LoadFile()只载入指定的dll文件，而不会自动加载相关的dll文件。如果下文例子使用Assembly.LoadFile()加载SayHello.dll，那么程序就只会加载
         * SayHello.dll而不会去加载SayHello.dll引用的BaseClass.dll文件。
         *二：用Assembly.LoadFrom()载入一个Assembly时，会先检查前面是否已经载入过相同名字的Assembly；
         * 而Assembly.LoadFile()则不会做类似的检查。
         */
        //C:\Users\Administrator\Desktop\New Unity Project\Assets\DLL
        Assembly assemly2 = Assembly.LoadFrom(@".\Assets\Scripts\TestReflection.dll");
        Assembly assemly1 = Assembly.LoadFile(@".\Assets\Scripts\TestReflection.dll");
        Assembly assemly = Assembly.Load("TestReflection");//1填加DLL
        Type testType = assemly.GetType("HaiLan.TestReflection.TestReflectionDLL");//2获取对应的类信息，需要填加对应的命名空间
        object oTestReflectionDLL = Activator.CreateInstance(testType);//3 创建对象
        IReflectionDLL iTestReflectionDLL = oTestReflectionDLL as IReflectionDLL;//4 类型转换
        iTestReflectionDLL.TestShow1();//5 方法调用

        foreach (var item in assemly.GetModules())
        {
            Debug.Log(item.Name);//打印结果 TestReflection.dll
        }
        foreach (var type in assemly.GetTypes())
        {
            Debug.Log(type.Name);
            foreach (var item in type.GetMethods())
            {
                Debug.Log(item.Name);
            }
        }
    }

    public void Learn01()
    {
        Console.WriteLine("************************Reflection*****************");
        Assembly assemly = Assembly.Load("TestReflection");

        Type testType = assemly.GetType("HaiLan.TestReflection.TestReflectionDLL");
        object oTest1 = Activator.CreateInstance(testType);
        object oTest2 = Activator.CreateInstance(testType, new object[] { });
        object oTest3 = Activator.CreateInstance(testType, new object[] { 9257 });
        object oTest4 = Activator.CreateInstance(testType, new object[] { "海澜" });

        Type genericType = assemly.GetType("HaiLan.TestReflection.GenericClass`3");//泛型类还有3个未指定的类型
        Type genericNewType = genericType.MakeGenericType(typeof(int), typeof(string), typeof(InvokeReflection));
        object oGeneric = Activator.CreateInstance(genericNewType);
        GenericClass<int, string, InvokeReflection> TempGenericClass = oGeneric as GenericClass<int, string, InvokeReflection>;
        TempGenericClass.Show(9257, "海澜", this);

        Type singletonType = assemly.GetType("HaiLan.TestReflection.Singleton");
        object oSingleton1 = Activator.CreateInstance(singletonType, true);//单例模型依然可以创建新类
        object oSingleton2 = Activator.CreateInstance(singletonType, true);
        object oSingleton3 = Activator.CreateInstance(singletonType, true);
    }

    public void Learn02()
    {
        Assembly assemly = Assembly.Load("TestReflection");
        Type testType = assemly.GetType("HaiLan.TestReflection.ReflectionTest");
        object oTest = Activator.CreateInstance(testType);
        {
            MethodInfo method = testType.GetMethod("Show1");//以前写的具体方法，换成字符串
            method.Invoke(oTest, null);
        }
        {
            MethodInfo method = testType.GetMethod("Show2");//带参数
            method.Invoke(oTest, new object[] { 9257 });
        }
        {
            MethodInfo method = testType.GetMethod("Show5");//静态
            method.Invoke(oTest, new object[] { "海澜" });
            method.Invoke(null, new object[] { "海澜" });
        }
        {
            MethodInfo method = testType.GetMethod("Show3", new Type[] { });//重载方法
            method.Invoke(oTest, new object[] { });
        }
        {
            MethodInfo method = testType.GetMethod("Show3", new Type[] { typeof(int) });//重载方法
            method.Invoke(oTest, new object[] { 9257 });
        }
        {
            MethodInfo method = testType.GetMethod("Show3", new Type[] { typeof(string) });//重载方法
            method.Invoke(oTest, new object[] { "海澜" });
        }
        {
            MethodInfo method = testType.GetMethod("Show3", new Type[] { typeof(int), typeof(string) });//重载方法
            method.Invoke(oTest, new object[] { 9257, "海澜" });
        }
        {
            MethodInfo method = testType.GetMethod("Show3", new Type[] { typeof(string), typeof(int) });//重载方法
            method.Invoke(oTest, new object[] { "海澜", 9257 });
        }
        {
            MethodInfo method = testType.GetMethod("Show4", BindingFlags.Instance | BindingFlags.NonPublic);//私有方法
            method.Invoke(oTest, new object[] { "海澜" });
        }
        {
            Type genericType = assemly.GetType("HaiLan.TestReflection.GenericMethod");
            object oGeneric = Activator.CreateInstance(genericType);
            MethodInfo method = genericType.GetMethod("Show");
            //MethodInfo method = genericType.GetMethod("Show`3");//错误写法，应为在编译期间就是无法通过的
            MethodInfo methodNew = method.MakeGenericMethod(typeof(int), typeof(string), typeof(int));
            methodNew.Invoke(oGeneric, new object[] { 9257, "海澜", 92570 });
        }
    }

    public void Learn03()
    {
        {
            People people = new People();
            people.Id = 9257;
            people.Name = "海澜";
            people.Description = "菜鸟海澜";

            Debug.Log($"people.Id={people.Id}");
            Debug.Log($"people.Name={people.Name}");
            Debug.Log($"people.Description={people.Description}");
        }
        {
            Type type = typeof(People);
            object oPeople = Activator.CreateInstance(type);
            foreach (var item in type.GetProperties())//反射可以给对象的属性 动态 赋值/获取值，
            {
                Debug.Log(item.Name);
                Debug.Log(item.GetValue(oPeople));
                if (item.Name.Equals("Id"))
                {
                    item.SetValue(oPeople, 1235);
                }
                else if (item.Name.Equals("Name"))
                {
                    item.SetValue(oPeople, "菜鸟海澜");
                }
                Debug.Log(item.GetValue(oPeople));
            }
            foreach (var item in type.GetFields())//反射可以给对象的字段  动态 赋值/获取值，
            {
                Debug.Log(item.Name);
                Debug.Log(item.GetValue(oPeople));
                if (item.Name.Equals("Description"))
                    item.SetValue(oPeople, "菜鸟海澜，ID：9257");
                Debug.Log(item.GetValue(oPeople));
            }

        }
    }
}
