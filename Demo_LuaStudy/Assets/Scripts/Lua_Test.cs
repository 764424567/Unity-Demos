using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using XLua;

[Hotfix]
public class Lua_Test : MonoBehaviour
{
    public Image BackgroundImage;
    public Text TipText;
    LuaEnv luaenv;
    void Start()
    {
        //创建Xlua虚拟机
        luaenv = new LuaEnv();

        //查找指定路径下的lua文件
        string path = "C:\\Temp\\t1.lua.txt";
        DownloadFile(path);
    }

    public void Init()
    {
        Debug.Log("第一个版本初始化");
    }


    public void DownloadFile(string path)
    {
        StreamReader sr = new StreamReader(path, Encoding.UTF8);
        if (sr != null)
        {
            //执行该Lua脚本中的语句
            luaenv.DoString(sr.ReadToEnd());
        }
    }

    void OnDisable()
    {
        luaenv.Dispose();//关闭lua环境
    }
}
