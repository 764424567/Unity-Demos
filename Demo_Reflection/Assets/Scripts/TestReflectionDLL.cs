using System.Collections;
using System.Collections.Generic;


public interface IReflectionDLL2
{
    void TestShow1();
    void TestShow2();
    void TestShow3();
    void TestShow4();
    void TestShow5();

}

namespace HaiLan.TestReflection
{
    public class TestReflectionDLL : IReflectionDLL2
    {
        private string Name;
        private int ID;


        public TestReflectionDLL()
        {
            UnityEngine.Debug.Log("This is TestReflectionDLL");
        }

        public TestReflectionDLL(string TempStr)
        {
            Name = TempStr;
            UnityEngine.Debug.Log("This is TestReflectionDLL:" + TempStr);
        }
        public TestReflectionDLL(int TempInt)
        {
            ID = TempInt;
            UnityEngine.Debug.Log("This is TestReflectionDLL:" + TempInt);
        }
        public void TestShow1()
        {
            UnityEngine.Debug.Log("TestShow1");
        }
        public void TestShow2()
        {
            UnityEngine.Debug.Log("TestShow2");
        }
        public void TestShow3()
        {
            UnityEngine.Debug.Log("TestShow3");
        }
        public void TestShow4()
        {
            UnityEngine.Debug.Log("TestShow4");
        }
        public void TestShow5()
        {
            UnityEngine.Debug.Log("TestShow5");
        }

    }

    public class GenericClass<T, W, X>
    {
        public void Show(T t, W w, X x)
        {
            UnityEngine.Debug.LogFormat("t.type={0},w.type={1},x.type={2}", t.GetType().Name, w.GetType().Name, x.GetType().Name);
        }
    }

    public class GenericMethod
    {
        public void Show<T, W, X>(T t, W w, X x)
        {
            UnityEngine.Debug.LogFormat("t.type={0},w.type={1},x.type={2}", t.GetType().Name, w.GetType().Name, x.GetType().Name);
        }
    }

    public class GenericDouble<T>
    {
        public void Show<W, X>(T t, W w, X x)
        {
            UnityEngine.Debug.LogFormat("t.type={0},w.type={1},x.type={2}", t.GetType().Name, w.GetType().Name, x.GetType().Name);
        }
    }


    /// <summary>
    /// 单例模式
    /// </summary>
    public sealed class Singleton
    {
        private static Singleton _Singleton = null;
        private Singleton()
        {
            UnityEngine.Debug.Log("Singleton被构造");
        }

        static Singleton()
        {
            _Singleton = new Singleton();
        }

        public static Singleton GetInstance()
        {
            return _Singleton;
        }
    }


    /// <summary>
    /// 反射测试类
    /// </summary>
    public class ReflectionTest
    {
        #region Identity
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public ReflectionTest()
        {
            UnityEngine.Debug.LogFormat("这里是{0}无参数构造函数", this.GetType());
        }

        /// <summary>
        /// 带参数构造函数
        /// </summary>
        /// <param name="name"></param>
        public ReflectionTest(string name)
        {
            UnityEngine.Debug.LogFormat("这里是{0} 有参数构造函数", this.GetType());
        }

        public ReflectionTest(int id)
        {
            UnityEngine.Debug.LogFormat("这里是{0} 有参数构造函数", this.GetType());
        }
        #endregion

        #region Method
        /// <summary>
        /// 无参方法
        /// </summary>
        public void Show1()
        {
            UnityEngine.Debug.LogFormat("这里是{0}的Show1", this.GetType());
        }
        /// <summary>
        /// 有参数方法
        /// </summary>
        /// <param name="id"></param>
        public void Show2(int id)
        {

            UnityEngine.Debug.LogFormat("这里是{0}的Show2", this.GetType());
        }
        /// <summary>
        /// 重载方法之一
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void Show3(int id, string name)
        {
            UnityEngine.Debug.LogFormat("这里是{0}的Show3", this.GetType());
        }
        /// <summary>
        /// 重载方法之二
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        public void Show3(string name, int id)
        {
            UnityEngine.Debug.LogFormat("这里是{0}的Show3_2", this.GetType());
        }
        /// <summary>
        /// 重载方法之三
        /// </summary>
        /// <param name="id"></param>
        public void Show3(int id)
        {

            UnityEngine.Debug.LogFormat("这里是{0}的Show3_3", this.GetType());
        }
        /// <summary>
        /// 重载方法之四
        /// </summary>
        /// <param name="name"></param>
        public void Show3(string name)
        {

            UnityEngine.Debug.LogFormat("这里是{0}的Show3_4", this.GetType());
        }
        /// <summary>
        /// 重载方法之五
        /// </summary>
        public void Show3()
        {

            UnityEngine.Debug.LogFormat("这里是{0}的Show3_1", this.GetType());
        }
        /// <summary>
        /// 私有方法
        /// </summary>
        /// <param name="name"></param>
        private void Show4(string name)
        {
            UnityEngine.Debug.LogFormat("这里是{0}的Show4", this.GetType());
        }
        /// <summary>
        /// 静态方法
        /// </summary>
        /// <param name="name"></param>
        public static void Show5(string name)
        {
            UnityEngine.Debug.LogFormat("这里是{0}的Show5", typeof(ReflectionTest));
        }
        #endregion
    }


    /// <summary>
    /// 实体
    /// </summary>
    public class People
    {
        public People()
        {
            UnityEngine.Debug.LogFormat("{0}被创建", this.GetType().FullName);
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description;
    }
}
