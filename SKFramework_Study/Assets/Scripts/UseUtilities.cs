using SK.Framework;
using UnityEngine;

public class UseUtilities : MonoBehaviour
{
    void Start()
    {
        string phoneNum = "123";
        // 判断是否是电话号码
        Debug.Log(StringUtility.IsMatchMobilePhoneNumber(phoneNum));
    }
}