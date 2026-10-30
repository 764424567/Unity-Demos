using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    //数据库对象
    public SqlAccess sql;
    //输入信息
    public InputField inputName;
    public InputField inputPassword;
    //按钮登录
    public Button btnLogin;

    // Use this for initialization
    void Start()
    {
        string connectionString = "Server = localhost;port = 3306;Database = db_user;User ID = root;Password = 123456";
        sql = new SqlAccess(connectionString);
        btnLogin.onClick.AddListener(LoginID);
    }

    public void LoginID()
    {
        //MD5加密
        //MD5 md5 = new MD5CryptoServiceProvider();
        //string Md5Password = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(inputPassword.text))).Replace("-", "");
        //DataSet ds = sql.SelectInto("users", "uName", "uPwd", inputName.text, Md5Password);


        DataSet ds = sql.SelectInto("users", "uName", "uPwd", inputName.text, inputPassword.text);
        Debug.Log("检索到：" + ds.Tables[0].Rows.Count);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Debug.Log("登陆成功");
        }
        else
        {
            Debug.Log("登录失败");
        }
    }

    public void Register()
    {
        //不加密
        //插入信息
        //sql.InsertInto("user",new string[] {"name","password" }, new string[] { inputName.text, inputPassword.text });

        //加密注册
        MD5 md5 = new MD5CryptoServiceProvider();
        string Md5Password = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(inputPassword.text))).Replace("-","");
        sql.InsertInto("users", new string[] { "uName", "uPwd" }, new string[] { inputName.text, Md5Password });
    }

    public void ShowData()
    {
        DataSet sdata = sql.SelectInto("users");
        sql.ReadData(sdata);
    }
}
