/*******************************************************************************
* 版权声明：
* 版本声明：v1.0.0
* 类 名 称：MyExtension
* 创建日期：2023-06-07 10:30:37
* 作者名称：张尧
* CLR 版本：
* 修改记录：
* 描述：
******************************************************************************/

using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Com.Frame.ZY
{
    /// <summary>
    /// 用户自定义工具库
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// 根据名字查询物体，返回物体
        /// </summary>
        /// <param name="child">查询的物体的父节点</param>
        /// <param name="name">查询的子物体的名字</param>
        /// <returns></returns>
        public static GameObject Find(GameObject child, string name)
        {
            //定义一个Transform 变量it用来接收查询到子物体
            Transform it = child.transform.Find(name);
            if (it != null)
            {
                return it.gameObject;
            }
            if (child.transform.childCount == 0)
            {
                return null;
            }
            //查找子对象的子对象
            for (int i = 0; i < child.transform.childCount; i++)
            {
                //递归查询  定义一个Transform 变量its用来接收查询到子物体
                GameObject its = Find(child.transform.GetChild(i).gameObject, name);
                //如果不为空，就是存在次物体返回该物体
                if (its != null)
                {
                    return its.gameObject;
                }
            }
            return null;
        }

        /// <summary>
        /// 根据名字查询泛型类对象，返回泛型类对象
        /// </summary>
        /// <typeparam name="T">泛型类对象</typeparam>
        /// <param name="child">查询的物体的父节点</param>
        /// <param name="name">查询的子物体的名字</param>
        /// <returns></returns>
        public static T Find<T>(GameObject child, string name)
        {
            //定义一个Transform 变量it用来接收查询到子物体
            Transform it = child.transform.Find(name);
            if (it != null)
            {
                return it.GetComponent<T>();
            }
            if (child.transform.childCount == 0)
            {
                return default(T);
            }
            //查找子对象的子对象
            for (int i = 0; i < child.transform.childCount; i++)
            {
                //递归查询  定义一个Transform 变量its用来接收查询到子物体
                GameObject its = Find(child.transform.GetChild(i).gameObject, name);
                //如果不为空，就是存在次物体返回该物体
                if (its != null)
                {
                    return its.GetComponent<T>();
                }
            }
            return default(T);
        }

        /// <summary>
        /// 获取Button组件
        /// </summary>
        /// <param name="namestring"></param>
        /// <returns></returns>
        public static Button FindButton(string namestring)
        {
            return GameObject.Find(namestring).GetComponent<Button>();
        }

        /// <summary>
        /// 获取物体名下的 T 组件
        /// </summary>
        /// <param name="namestring">物体名</param>
        /// <returns></returns>
        public static T FindT<T>(string namestring)
        {
            return GameObject.Find(namestring).GetComponent<T>();
        }


        public static Vector3 ParseVector3(string msg)
        {

            msg = msg.Replace("(", "").Replace(")", "");

            string[] s = msg.Split(',');
            return new Vector3(float.Parse(s[0]), float.Parse(s[1]), float.Parse(s[2]));
        }


        public static int CountCHNString(string msg)
        {
            int num = 0;
            foreach (var one in msg)
            {
                num += ((int)one > 127) ? 3 : 1;
            }
            return num;
        }

        public static string Now
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        public static string NowMonth
        {
            get
            {
                return DateTime.Now.ToString("MM");
            }
        }

        public static string Week()
        {
            string weekstr = DateTime.Now.DayOfWeek.ToString();
            switch (weekstr)
            {
                case "Monday": weekstr = "周一"; break;
                case "Tuesday": weekstr = "周二"; break;
                case "Wednesday": weekstr = "周三"; break;
                case "Thursday": weekstr = "周四"; break;
                case "Friday": weekstr = "周五"; break;
                case "Saturday": weekstr = "周六"; break;
                case "Sunday": weekstr = "周日"; break;
            }
            return weekstr;
        }

        public static string Week(DateTime week)
        {
            string weekstr = week.DayOfWeek.ToString();
            switch (weekstr)
            {
                case "Monday": weekstr = "周一"; break;
                case "Tuesday": weekstr = "周二"; break;
                case "Wednesday": weekstr = "周三"; break;
                case "Thursday": weekstr = "周四"; break;
                case "Friday": weekstr = "周五"; break;
                case "Saturday": weekstr = "周六"; break;
                case "Sunday": weekstr = "周日"; break;
            }
            return weekstr;
        }

        /// <summary>
        /// 返回是否是Windows编辑器平台
        /// </summary>
        public static bool WindowsEditor
        {
            get { return Application.platform == RuntimePlatform.WindowsEditor; }
        }

        /// <summary>
        /// 写入JSON文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="name">文件名</param>
        /// <param name="info">信息</param>
        public static void WriteJson(string path, string name, string info)
        {
            StreamWriter streamWriter;                               //声明一个流写入对象
            FileInfo fileInfo = new FileInfo(path + "/" + name); //文件 写到哪里：叫什么
            streamWriter = fileInfo.CreateText();           //打开文件往里写文本
            streamWriter.WriteLine(info);                            //写入信息 fileInfo streamWriter
            streamWriter.Close();
            streamWriter.Dispose(); //双关，写完
        }


        /// <summary>
        /// 读取JSON文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="name">文件名</param>
        /// <returns>string </returns>
        public static string ReadJson(string path, string name)
        {
            StreamReader streamReader;                               //声明一个流读取对象
            FileInfo fileInfo = new FileInfo(path + "/" + name); //文件 文件路径信息：叫什么
            streamReader = fileInfo.OpenText();             //打开文件往里写文本
            string info = streamReader.ReadToEnd();        //读信息 streamReader 给 info
            streamReader.Close();
            streamReader.Dispose(); //双关，写完
            return info;
        }

        /// <summary>
        /// 文件是否存在
        /// </summary>
        /// <param name="filename">文件名</param>
        public static bool IsExists(string filename)
        {
            bool isExists;                                                                 //声明一个布尔值，默认为false
            FileInfo fileInfo = new FileInfo(Application.persistentDataPath + "/" + filename); //判断路径
                                                                                               //DirectoryInfo myDirectoryInfo=new DirectoryInfo(fileInfo.ToString()); //目录
            if (fileInfo.Exists == false) //路径不存在
            {
                isExists = false;
            }
            else
            {
                isExists = true;
            }
            return isExists; //返回bool值给函数 IsExist
        }

        /// <summary>
        /// 返回随机颜色
        /// </summary>
        /// <returns> Color </returns>
        public static Color RandomColor()
        {
            float r = UnityEngine.Random.Range(0f, 1f);
            float g = UnityEngine.Random.Range(0f, 1f);
            float b = UnityEngine.Random.Range(0f, 1f);
            Color color = new Color(r, g, b);
            return color;
        }

        /// <summary>
        /// 传递16进制字符串，返回颜色
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Color HexReturnColor(string color)
        {
            Color newColor;
            ColorUtility.TryParseHtmlString(color, out newColor);
            return newColor;
        }

        /// <summary>
        /// 正则表达式：Unicode转换中文
        /// </summary>
        /// <param name="unicode"></param>
        /// <returns></returns>
        public static string UnicodeToString(string unicode)
        {
            Regex regex = new Regex(@"(?i)\\[uU]([0-9a-f]{4})");
            return regex.Replace(unicode,
                delegate (Match m) { return ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString(); });
        }

        /// <summary>
        /// 正则表达式：提取名字信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ExtractNameInfo(string data)
        {
            string x = @"[\u4E00-\u9FFF]+";
            MatchCollection Matches = Regex.Matches(data, x, RegexOptions.IgnoreCase);
            StringBuilder sb = new StringBuilder();
            foreach (Match NextMatch in Matches)
            {
                sb.Append(NextMatch.Value);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 文件日志类
        /// </summary>
        // [特性(布局种类.有序,字符集=字符集.自动)]
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class OpenFileName
        {
            public int structSize = 0;
            public IntPtr dlgOwner = IntPtr.Zero;
            public IntPtr instance = IntPtr.Zero;
            public String filter = null;
            public String customFilter = null;
            public int maxCustFilter = 0;
            public int filterIndex = 0;
            public String file = null;
            public int maxFile = 0;
            public String fileTitle = null;
            public int maxFileTitle = 0;
            public String initialDir = null;
            public String title = null;
            public int flags = 0;
            public short fileOffset = 0;
            public short fileExtension = 0;
            public String defExt = null;
            public IntPtr custData = IntPtr.Zero;
            public IntPtr hook = IntPtr.Zero;
            public String templateName = null;
            public IntPtr reservedPtr = IntPtr.Zero;
            public int reservedInt = 0;
            public int flagsEx = 0;

            public OpenFileName()
            {
                this.structSize = Marshal.SizeOf(this);
                this.filter = "Texure Files(*图片文件)\0*.png;*.jpg;*.bmp;*.jpeg\0";
                this.file = new string(new char[256]);
                this.maxFile = this.file.Length;
                this.fileTitle = new string(new char[64]);
                this.maxFileTitle = this.fileTitle.Length;
                this.initialDir = "C:\\"; //默认路径
                this.title = "打开项目";
                this.defExt = "JPG";
                this.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200 | 0x00000008;
            }
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="ofd">文件日志类</param>
        /// <returns></returns>
        [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        public static extern bool GetOpenFileName([In, Out] OpenFileName ofd);

        /// <summary>
        /// 返回指定长度的随机字符串
        /// </summary>
        /// <param name="Length">长度</param>
        /// <returns></returns>
        public static string GetRandomString(int Length)
        {
            char[] constant = {  '0','1','2','3','4','5','6','7','8','9',
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
            StringBuilder newRandom = new StringBuilder(36);
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[UnityEngine.Random.Range(0, 36)]);
            }
            return newRandom.ToString();
        }

        /// <summary>
        /// 返回指定长度的随机字符串
        /// </summary>
        /// <param name="Length">长度</param>
        /// <returns></returns>
        public static string GetRandomString(int type, int Length)
        {
            char[] constant0 = {'0','1','2','3','4','5','6','7','8','9',
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
            char[] constant1 = {'0','1','2','3','4','5','6','7','8','9',
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
            char[] constant2 = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] constant3 = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            StringBuilder newRandom = new StringBuilder(Length);
            for (int i = 0; i < Length; i++)
            {
                switch (type)
                {
                    case 0:
                        newRandom.Append(constant0[UnityEngine.Random.Range(0, 62)]);
                        break;
                    case 1:
                        newRandom.Append(constant1[UnityEngine.Random.Range(0, 36)]);
                        break;
                    case 2:
                        newRandom.Append(constant2[UnityEngine.Random.Range(0, 10)]);
                        break;
                    case 3:
                        newRandom.Append(constant3[UnityEngine.Random.Range(0, 16)]);
                        break;
                    default:
                        break;
                }
            }
            return newRandom.ToString();
        }

        /// <summary>
        /// 返回汉字数字
        /// </summary>
        /// <param name="Length">长度</param>
        /// <returns></returns>
        public static string GetNum(int type)
        {
            char[] constant = { '一', '二', '三', '四', '五', '六', '七', '八', '九', '十' };
            return constant[type].ToString();
        }

        /// <summary>
        /// 阿拉伯数字转换中文汉字  数字大写
        /// </summary>
        /// <param name="input">输入数字</param>
        /// <param name="type">类型：0中文汉字 1大写钱</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string Rell(int input, int type = 0)
        {
            string ret = null;
            int input2 = Math.Abs(input);
            string resource;
            if (type == 0)
            {
                resource = "零一二三四五六七八九";
            }
            else
            {
                resource = "零壹贰叁肆伍陆柒捌玖";
            }
            string unit = "个十百千万亿兆京垓秭穰沟涧正载极";
            if (input > Math.Pow(10, 4 * (unit.Length - unit.IndexOf('万'))))
            {
                throw new Exception("the input is too big,input:" + input);
            }
            Func<int, List<List<int>>> splitNumFunc = (val) =>
            {
                int i = 0;
                int mod;
                int val_ = val;
                List<List<int>> splits = new List<List<int>>();
                List<int> splitNums;
                do
                {
                    mod = val_ % 10;
                    val_ /= 10;
                    if (i % 4 == 0)
                    {
                        splitNums = new List<int>();
                        splitNums.Add(mod);
                        if (splits.Count == 0)
                        {
                            splits.Add(splitNums);
                        }
                        else
                        {
                            splits.Insert(0, splitNums);
                        }
                    }
                    else
                    {
                        splitNums = splits[0];
                        splitNums.Insert(0, mod);
                    }
                    i++;
                } while (val_ > 0);
                return splits;
            };
            Func<List<List<int>>, string> hommizationFunc = (data) =>
            {
                List<StringBuilder> builders = new List<StringBuilder>();
                for (int i = 0; i < data.Count; i++)
                {
                    List<int> data2 = data[i];
                    StringBuilder newVal = new StringBuilder();
                    for (int j = 0; j < data2.Count;)
                    {
                        if (data2[j] == 0)
                        {
                            int k = j + 1;
                            for (; k < data2.Count && data2[k] == 0; k++) ;
                            //个位不是0，前面补一个零
                            newVal.Append('零');
                            j = k;
                        }
                        else
                        {
                            newVal.Append(resource[data2[j]]).Append(unit[data2.Count - 1 - j]);
                            j++;
                        }
                    }
                    if (newVal[newVal.Length - 1] == '零' && newVal.Length > 1)
                    {
                        newVal.Remove(newVal.Length - 1, 1);
                    }
                    else if (newVal[newVal.Length - 1] == '个')
                    {
                        newVal.Remove(newVal.Length - 1, 1);
                    }

                    if (i == 0 && newVal.Length > 1 && newVal[0] == '一' && newVal[1] == '十')
                    {//一十 --> 十
                        newVal.Remove(0, 1);
                    }
                    builders.Add(newVal);
                }
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < builders.Count; i++)
                {//拼接
                    if (builders.Count == 1)
                    {//个位数
                        sb.Append(builders[i]);
                    }
                    else
                    {
                        if (i == builders.Count - 1)
                        {//万位以下的
                            if (builders[i][builders[i].Length - 1] != '零')
                            {//十位以上的不拼接"零"
                                sb.Append(builders[i]);
                            }
                        }
                        else
                        {//万位以上的
                            if (builders[i][0] != '零')
                            {//零万零亿之类的不拼接
                                sb.Append(builders[i]).Append(unit[unit.IndexOf('千') + builders.Count - 1 - i]);
                            }
                        }
                    }
                }
                return sb.ToString();
            };
            List<List<int>> ret_split = splitNumFunc(input2);
            ret = hommizationFunc(ret_split);
            if (input < 0) ret = "-" + ret;
            return ret;
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="_hash">hash值</param>
        /// <returns></returns>
        public static string GetMD5Hash(string _hash)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.ASCII.GetBytes(_hash);
            byte[] encoded = md5.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < encoded.Length; i++)
            {
                sb.Append(encoded[i].ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="strToEncrypt">加密值</param>
        /// <returns></returns>
        public static string GetMD5Encrypt(string strToEncrypt)
        {
            byte[] bs = Encoding.UTF8.GetBytes(strToEncrypt);
            MD5 md5 = MD5.Create();
            byte[] hashBytes = md5.ComputeHash(bs);
            string hashString = "";
            for (int i = 0; i < hashBytes.Length; i++)
            {
                hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
            }
            return hashString.PadLeft(32, '0');
        }

        /// <summary>
        /// SHA256加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string SHA256EncryptString(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            byte[] hash = SHA256.Create().ComputeHash(bytes);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("x2"));
            }
            return builder.ToString();
        }

        /// <summary>
        /// SHA256加密
        /// </summary>
        /// <param name="StrIn">待加密字符串</param>
        /// <returns>加密数组</returns>
        public static byte[] SHA256EncryptByte(string StrIn)
        {
            SHA256Managed sha256 = new SHA256Managed();
            ASCIIEncoding Asc = new ASCIIEncoding();
            byte[] tmpByte = Asc.GetBytes(StrIn);
            byte[] EncryptBytes = sha256.ComputeHash(tmpByte);
            sha256.Clear();
            return EncryptBytes;
        }

        /// <summary>
        /// 根据容器大小跟图片大小，返回合适的图片大小值
        /// </summary>
        /// <param name="screen">容器</param>
        /// <param name="spriteRect">图片</param>
        /// <returns></returns>
        public static Vector2 ReturnImageScale(Rect screen, Rect spriteRect)
        {
            float scale;
            if (spriteRect.width > spriteRect.height)
            {
                scale = screen.width / spriteRect.width;
            }
            else if (spriteRect.width == spriteRect.height)
            {
                scale = screen.width / spriteRect.width;
            }
            else
            {
                scale = screen.height / spriteRect.height;
            }
            Vector2 sizeVe2 = new Vector2(spriteRect.width * scale, spriteRect.height * scale);
            return sizeVe2;
        }

        /// <summary>
        /// 将字典类型序列化为json字符串
        /// </summary>
        /// <typeparam name="TKey">字典key</typeparam>
        /// <typeparam name="TValue">字典value</typeparam>
        /// <param name="dict">要序列化的字典数据</param>
        /// <returns>json字符串</returns>
        public static string SerializeDictionaryToJsonString<TKey, TValue>(Dictionary<TKey, TValue> dict)
        {
            if (dict.Count == 0)
                return "";

            string jsonStr = JsonConvert.SerializeObject(dict);
            return jsonStr;
        }

        /// <summary>
        /// 将json字符串反序列化为字典类型
        /// </summary>
        /// <typeparam name="TKey">字典key</typeparam>
        /// <typeparam name="TValue">字典value</typeparam>
        /// <param name="jsonStr">json字符串</param>
        /// <returns>字典数据</returns>
        public static Dictionary<TKey, TValue> DeserializeStringToDictionary<TKey, TValue>(string jsonStr)
        {
            if (string.IsNullOrEmpty(jsonStr))
                return new Dictionary<TKey, TValue>();

            Dictionary<TKey, TValue> jsonDict = JsonConvert.DeserializeObject<Dictionary<TKey, TValue>>(jsonStr);

            return jsonDict;

        }

        //定时器
        public static IEnumerator UpdateTimer(float timer, Action callBack)
        {
            var wait = new WaitForSeconds(timer);
            while (true)
            {
                yield return wait;
                callBack();
                break;
            }
        }

        /// <summary>
        /// 获得MainCamera下，当前鼠标下的3D物体
        /// </summary>
        public static Transform GetOverObj()
        {
            Transform obj = null;

            Camera cam = Camera.main;

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, cam.farClipPlane))
            {
                // 如果与物体发生碰撞，在Scene视图中绘制射线 
                Debug.DrawLine(ray.origin, hit.point, Color.green);

                obj = hit.transform;
            }

            return obj;
        }

        public static void CreateTexture2DByRenderTexture(MonoBehaviour mono, Camera came, Rect r)
        {
            Texture2D screenShot;
            mono.StartCoroutine(CaptureScreen(came, r, (Texture2D tex) => { screenShot = tex; }));
        }

        static IEnumerator CaptureScreen(Camera came, Rect r, Action<Texture2D> finish)
        {
            yield return new WaitForEndOfFrame();
            RenderTexture rt = new RenderTexture((int)r.width, (int)r.height, 0);

            came.targetTexture = rt;
            came.Render();

            RenderTexture.active = rt;
            Texture2D screenShot = new Texture2D((int)r.width, (int)r.height, TextureFormat.RGB24, false);

            screenShot.ReadPixels(r, 0, 0);
            screenShot.Apply();

            came.targetTexture = null;
            RenderTexture.active = null;
            UnityEngine.Object.DestroyImmediate(rt);

            finish(screenShot);
        }

        public static void SetImageByScreenShot(MonoBehaviour mono, RectTransform rect, Image image, Action<Sprite> save)
        {
            mono.StartCoroutine(SetImageByScreenShot(rect, image, save));
        }
        static IEnumerator SetImageByScreenShot(RectTransform shotRect, Image image, Action<Sprite> save)
        {
            yield return new WaitForEndOfFrame();
            Texture2D t = new Texture2D((int)shotRect.rect.width, (int)shotRect.rect.height, TextureFormat.RGB24, true);//需要正确设置好图片保存格式
            float x = shotRect.localPosition.x + (Screen.width - shotRect.rect.width) / 2;
            float y = shotRect.localPosition.y + (Screen.height - shotRect.rect.height) / 2;
            Rect position = new Rect(x, y, shotRect.rect.width, shotRect.rect.height);
            t.ReadPixels(position, 0, 0, true);//按照设定区域读取像素；注意是以左下角为原点读取
            t.Apply();

            if (image)
            {
                Sprite sprite = Sprite.Create(t, new Rect(0, 0, t.width, t.height), Vector2.zero);
                image.sprite = sprite;
                save(sprite);

                //// sprite转byte[]
                //byte[] imageBuffer = t.EncodeToPNG();
                //string textString = Convert.ToBase64String(imageBuffer);
                //Debug.Log(textString);
                ////string转byte[]
                //byte[] bytes = Convert.FromBase64String(textString);
                //Texture2D tex2D = new Texture2D(width, height);
                //tex2D.LoadImage(bytes);
            }
        }

        public static void AddEventListener(GameObject go, EventTriggerType type, UnityEngine.Events.UnityAction<BaseEventData> call)
        {
            EventTrigger trigger;
            if (go.GetComponent<EventTrigger>() == null)
                go.AddComponent<EventTrigger>();
            trigger = go.GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = type;
            entry.callback = new EventTrigger.TriggerEvent();
            entry.callback.AddListener(call);
            trigger.triggers.Add(entry);
        }

        /// <summary>
        /// 求幂的指数是多少
        /// </summary>
        public static int GetP(int value, int m)
        {
            int n = 0, v = value;
            while (v > 0)
            {
                v /= m;
                n += v == 0 ? 0 : 1;
            }
            return n;
        }

        /// <summary>
        /// 在场景中启用或隐藏一个物体
        /// </summary>
        /// <param name="gameObject">要隐藏的物体</param>
        /// <param name="value">是否隐藏</param>
        /// <returns>是否隐藏成功，如果物体不存在则失败</returns>
        public static bool SetGameObjectActive(GameObject gameObject, bool value)
        {
            if (gameObject != null)
            {
                if (gameObject.activeInHierarchy != value)
                    gameObject.SetActive(value);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 在场景中启用或隐藏一个物体本身，不管是否在场景中可见
        /// </summary>
        /// <param name="gameObject">要隐藏的物体</param>
        /// <param name="value">是否隐藏</param>
        /// <returns>是否隐藏成功，如果物体不存在则失败</returns>
        public static bool SetGameObjectSelfActive(GameObject gameObject, bool value)
        {
            if (gameObject != null)
            {
                if (gameObject.activeSelf != value)
                    gameObject.SetActive(value);
                return true;
            }

            return false;
        }

        public static List<GameObject> GetAllRaycastUI()
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;
            List<RaycastResult> raycasts = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raycasts);
            if (raycasts.Count > 0)
            {
                List<GameObject> list = new List<GameObject>();
                for (int i = 0; i < raycasts.Count; i++)
                {
                    list.Add(raycasts[i].gameObject);
                }
                return list;
            }

            return null;
        }

        public static GameObject GetRaycastUI(int layer = -1/*小于0，则不根据layer获取*/)
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;
            List<RaycastResult> raycasts = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raycasts);
            if (raycasts.Count > 0)
            {
                if (layer == -1)
                    return raycasts[0].gameObject;

                for (int i = 0; i < raycasts.Count; i++)
                {
                    if (raycasts[i].gameObject.layer == layer)
                        return raycasts[i].gameObject;
                }
            }

            return null;
        }

        public static void DoMoveTransformSpeed(MonoBehaviour mono, Transform tran, Vector3 position, Vector3 rotation, float speed = 1, Action finish = null)
        {
            float duration = Mathf.Abs(Vector3.Distance(position, tran.position)) / speed;
            mono.StartCoroutine(MoveTo(tran, position, Quaternion.Euler(rotation), duration, finish));
        }

        public static void DoMoveTransform(MonoBehaviour mono, Transform tran, Vector3 position, Vector3 rotation, float duration = 1, Action finish = null)
        {
            mono.StartCoroutine(MoveTo(tran, position, Quaternion.Euler(rotation), duration, finish));
        }
        static IEnumerator MoveTo(Transform go, Vector3 pos, Quaternion rot, float duration = 1, Action end = null)
        {
            if (!go)
                yield break;

            Vector3 position = go.position;
            Quaternion rotation = go.rotation;

            float time = duration, value;
            while (time >= 0)
            {
                time -= Time.deltaTime;
                value = 1 - time / duration;
                if (value > 1)
                    value = 1;

                go.position = Vector3.Lerp(position, pos, value);
                go.rotation = Quaternion.Lerp(rotation, rot, value);
                yield return null;
            }
            end?.Invoke();
        }

        public static void DoActionDelay(MonoBehaviour mono, float sec, Action action = null)
        {
            mono.StartCoroutine(DoAction(sec, action));
        }
        static IEnumerator DoAction(float sec, Action action = null)
        {
            yield return new WaitForSeconds(sec);
            action?.Invoke();
        }
        public static void DoActionDelay(MonoBehaviour mono, int frameCount, Action action = null)
        {
            mono.StartCoroutine(DoAction(frameCount, action));
        }
        static IEnumerator DoAction(int frameCount, Action action = null)
        {
            int count = frameCount;
            while (count > 0)
            {
                count--;
                yield return null;
            }
            action?.Invoke();
        }

        static Dictionary<MaskableGraphic, bool> flashes = new Dictionary<MaskableGraphic, bool>();
        public static void HighlighterUIOn(MonoBehaviour mono, MaskableGraphic graphic, float duration, Color startColor, Color endColor)
        {
            if (flashes.ContainsKey(graphic) && flashes[graphic])
                return;

            if (!flashes.ContainsKey(graphic))
                flashes.Add(graphic, true);
            flashes[graphic] = true;
            mono.StartCoroutine(HighlighterUIOn(graphic, duration, startColor, endColor));
        }
        static IEnumerator HighlighterUIOn(MaskableGraphic graphic, float duration, Color startColor, Color endColor)
        {
            if (!graphic)
                yield break;

            graphic.color = startColor;
            float time = duration, value;
            Color tempColor = endColor;

            while (flashes[graphic])
            {
                time -= Time.deltaTime;
                value = 1 - time / duration;
                if (time <= 0)
                {
                    value = 0;
                    time = duration;
                    tempColor = tempColor == endColor ? startColor : endColor;
                }
                if (value > 1)
                {
                    value = 1;
                }

                graphic.color = Color.Lerp(graphic.color, tempColor, value);
                yield return null;
            }
        }
        public static void HighlighterUIOff(MaskableGraphic graphic, Color color)
        {
            flashes[graphic] = false;
            graphic.color = color;
        }

        static bool flashHDR = false;
        public static void HighlighterHDROn(MonoBehaviour mono, Material graphic, float duration, Color startColor, float intensity)
        {
            mono.StartCoroutine(HighlighterHDROn(graphic, duration, startColor, intensity));
        }
        static IEnumerator HighlighterHDROn(Material material, float duration, Color color, float intensity)
        {
            if (!material)
                yield break;

            flashHDR = true;
            float time = duration;
            bool change = false;
            intensity = 1;
            Color c = color;
            while (flashHDR)
            {
                time -= Time.deltaTime;
                if (time <= 0)
                {
                    change = !change;
                    time = duration;
                    if (change) c = new Color(color.r * intensity, color.g * intensity, color.b * intensity);
                    else c = new Color(color.r * intensity, color.g * intensity, color.b * intensity);
                    material.SetColor("_EmissionColor", c);
                }
                yield return null;
            }
        }
        public static void HighlighterHDROff(Material material, Color color, float intensity = 1)
        {
            flashHDR = false;
            Color c = new Color(color.r * intensity, color.g * intensity, color.b * intensity);
            material.SetColor("_EmissionColor", color * intensity);
        }

        public static Vector2 GetPositionInUI(Vector2 position, Transform canvas)
        {
            Vector2 pos = new Vector2(position.x - Screen.width / 2, position.y - Screen.height / 2) / canvas.localScale.x;

            // 限制边界
            //RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();
            //float width = canvasRectTransform.sizeDelta.x;
            //float height = canvasRectTransform.sizeDelta.y;
            //if (pos.x + sizeDelta.x > width * 0.5f) pos.x = width * 0.5f - sizeDelta.x;
            //if (pos.y - sizeDelta.y < -height * 0.5f) pos.y = -height * 0.5f + sizeDelta.y;
            //if (pos.x < -width * 0.5f) pos.x = -width * 0.5f;
            //if (pos.y > height * 0.5f) pos.y = height * 0.5f;

            return pos;
        }

        public static Vector3 GetMousePositionInWorld(Camera camera, Vector3 position)
        {
            Vector3 screenPosition = camera.WorldToScreenPoint(position);
            Vector3 mousePositionOnScreen = Input.mousePosition;
            mousePositionOnScreen.z = screenPosition.z;
            return camera.ScreenToWorldPoint(mousePositionOnScreen);
        }

        /// <summary>
        /// 判断间隔时间是否大于60秒
        /// </summary>
        /// <returns></returns>
        public static bool JudgeSpaceTime(string lastTime, int space)
        {
            DateTime dt_LastTime = DateTime.Parse(lastTime);
            DateTime dt_Now = DateTime.Now;
            if (dt_Now.Subtract(dt_LastTime).TotalSeconds >= space)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取Game View的分辨率
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void GetGameViewSize(out int width, out int height, int type)
        {
            switch (type)
            {
                case 0://4:3
                    height = 960;
                    width = 1280;
                    break;
                case 1://5:4
                    height = 1024;
                    width = 1280;
                    break;
                case 2://16：9
                    height = 720;
                    width = 1280;
                    break;
                case 3://16:10
                    height = 800;
                    width = 1580;
                    break;
                default:
                    height = 960;
                    width = 1280;
                    break;
            }
        }

        //时间格式化 00:00
        public static string FormatTime(float seconds)
        {
            TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(seconds));
            string str = "";
            if (ts.Hours > 0)
            {
                str = ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
            }
            if (ts.Hours == 0 && ts.Minutes > 0)
            {
                str = ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
            }
            if (ts.Hours == 0 && ts.Minutes == 0)
            {
                str = "00:" + ts.Seconds.ToString("00");
            }
            return str;
        }

        //时间格式化 00:00
        public static string FormatTime4(float seconds)
        {
            TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(seconds));
            string str = "";
            if (ts.Hours > 0)
            {
                str = ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
            }
            if (ts.Hours == 0 && ts.Minutes > 0)
            {
                str = ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
            }
            if (ts.Hours == 0 && ts.Minutes == 0)
            {
                str = ts.Seconds.ToString("00");
            }
            return str;
        }

        //时间格式化 00时00分00秒
        public static string FormatTime2(float seconds)
        {
            TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(seconds));
            string str = "";
            if (ts.Hours > 0)
            {
                str = ts.Hours.ToString("00") + "时" + ts.Minutes.ToString("00") + "分" + ts.Seconds.ToString("00") + "秒";
            }
            if (ts.Hours == 0 && ts.Minutes > 0)
            {
                str = ts.Minutes.ToString("00") + "分" + ts.Seconds.ToString("00") + "秒";
            }
            if (ts.Hours == 0 && ts.Minutes == 0)
            {
                str = ts.Seconds.ToString("00") + "秒";
            }
            return str;
        }

        //时间格式化 00秒
        public static string FormatTime3(float seconds)
        {
            TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(seconds));
            string str = "";
            if (ts.Hours > 0)
            {
                str = ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
            }
            if (ts.Hours == 0 && ts.Minutes > 0)
            {
                str = ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
            }
            if (ts.Hours == 0 && ts.Minutes == 0)
            {
                str = ts.Seconds.ToString("00");
            }
            return str;
        }

        public KeyCode GetKeyDownCode()
        {
            if (Input.anyKeyDown)
            {
                foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(key))
                    {
                        Debug.Log(key.ToString());
                        return key;
                    }
                }
            }
            return KeyCode.None;
        }

        /// <summary>
        /// 获取鼠标悬停的UI
        /// </summary>
        /// <param name="canvas"></param>
        /// <returns></returns>
        public static GameObject GetOverUI(GameObject canvas)
        {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;
            GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
            List<RaycastResult> results = new List<RaycastResult>();
            gr.Raycast(pointerEventData, results);
            if (results.Count != 0)
            {
                return results[0].gameObject;
            }
            return null;
        }

        /// <summary>
        /// 获取鼠标悬停的物体
        /// </summary>
        /// <param name="canvas"></param>
        /// <returns></returns>
        public static GameObject GetOverObj(GameObject raycaster)
        {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;
            GraphicRaycaster gr = raycaster.GetComponent<GraphicRaycaster>();
            List<RaycastResult> results = new List<RaycastResult>();
            gr.Raycast(pointerEventData, results);
            if (results.Count != 0)
            {
                return results[0].gameObject;
            }
            return null;
        }

        /// <summary>
        /// 获取鼠标悬停的物体
        /// </summary>
        /// <param name="canvas"></param>
        /// <returns></returns>
        public static GameObject GetOverRayObj(Camera cam)
        {
            GameObject obj = null;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, cam.farClipPlane))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.grey);
                obj = hit.transform.gameObject;
            }
            return obj;
        }

        //字符串匹配
        public static bool StringDoRegex(string _str)
        {
            Regex reg = new Regex("[\u4E00-\u9FFF]+");
            if (reg.IsMatch(_str))
            {
                return true;
            }
            else
                return false;
        }

        //字符串提取
        public static string GetChineseWord(string _str)
        {
            string regStr = @"[\u4E00-\u9FFF]+";
            MatchCollection matches = Regex.Matches(_str, regStr, RegexOptions.IgnoreCase);
            StringBuilder sb = new StringBuilder();
            foreach (Match item in matches)
            {
                sb.Append(item.Value);
            }
            return sb.ToString();
        }

        //提取英文和数字
        public static string GetEnglishNumWord(string _str)
        {
            //string regStr = @"[^A-Za-z0-9]+";
            //MatchCollection matches = Regex.Matches(_str, regStr, RegexOptions.IgnoreCase);
            //StringBuilder sb = new StringBuilder();
            //foreach (Match item in matches)
            //{
            //    sb.Append(item.Value);
            //}
            //return sb.ToString();
            string regStr = @"[^A-Z0-9]+";
            return Regex.Replace(_str, regStr, "");
        }

        //求最大公约数
        public static int GetLargestCommonDivisor(int n1, int n2)
        {
            int max = n1 > n2 ? n1 : n2;
            int min = n1 < n2 ? n1 : n2;
            int remainder;
            while (min != 0)
            {
                remainder = max % min;
                max = min;
                min = remainder;
            }
            return max;
        }

        //求最小公倍数
        static int GetLeastCommonMutiple(int n1, int n2)
        {
            return n1 * n2 / GetLargestCommonDivisor(n1, n2);
        }

        /// <summary>
        /// 数字经纬度和度分秒经纬度转换 (Digital degree of latitude and longitude and vehicle to latitude and longitude conversion)
        /// </summary>
        /// <param name="digitalLati_Longi">数字经纬度</param>
        /// <return>度分秒经纬度</return>
        public static string ConvertDigitalToDegrees(string digitalLati_Longi)
        {
            double digitalDegree = Convert.ToDouble(digitalLati_Longi);
            return ConvertDigitalToDegrees(digitalDegree);
        }

        /// <summary>
        /// 数字经纬度和度分秒经纬度转换 (Digital degree of latitude and longitude and vehicle to latitude and longitude conversion)
        /// </summary>
        /// <param name="digitalDegree">数字经纬度</param>
        /// <return>度分秒经纬度</return>
        public static string ConvertDigitalToDegrees(double digitalDegree)
        {
            const double num = 60;
            int degree = (int)digitalDegree;
            double tmp = (digitalDegree - degree) * num;
            int minute = (int)tmp;
            double second = (tmp - minute) * num;
            string degrees = "" + degree + "°" + minute + "′" + second.ToString("0000") + "″";
            return degrees;
        }

        /// <summary>
        /// 数字经纬度转 °′″
        /// </summary>
        /// <param name="digitalDegree"></param>
        /// <returns></returns>
        public static string ConvertDigitalToDegrees(decimal digitalDegree)
        {
            const decimal num = 60;
            int degree = (int)digitalDegree;
            decimal tmp = (digitalDegree - degree) * num;
            int minute = (int)tmp;
            decimal second = (tmp - minute) * num;
            string degrees = "" + degree + "°" + minute + "′" + second.ToString("0000") + "″";
            return degrees;
        }

        /// <summary>
        /// 数字经纬度转度分秒
        /// </summary>
        /// <param name="digitalDegree">数字经纬度</param>
        /// <return>度分秒经纬度</return>
        public static string ConvertDigitalToDegreesCN(decimal digitalDegree)
        {
            const decimal num = 60;
            int degree = (int)digitalDegree;
            decimal tmp = (digitalDegree - degree) * num;
            int minute = (int)tmp;
            decimal second = (tmp - minute) * num;
            string degrees = "" + degree + "度" + minute + "分" + Math.Round(second, 2) + "秒";
            return degrees;
        }

        /// <summary>
        /// 度分秒经纬度(必须含有'°')和数字经纬度转换 
        /// </summary>
        /// <param name="digitalDegree">度分秒经纬度</param>
        /// <return>数字经纬度</return>
        public static float ConvertDegreesToDigital(string degrees)
        {
            const double num = 60;
            double digitalDegree = 0.0;
            int d = degrees.IndexOf('°');           //度的符号对应的 Unicode 代码为：00B0[1]（六十进制），显示为°。
            if (d < 0)
            {
                return (float)digitalDegree;
            }
            string degree = degrees.Substring(0, d);
            digitalDegree += Convert.ToDouble(degree);

            int m = degrees.IndexOf('′');           //分的符号对应的 Unicode 代码为：2032[1]（六十进制），显示为′。
            if (m < 0)
            {
                return (float)digitalDegree;
            }
            string minute = degrees.Substring(d + 1, m - d - 1);
            digitalDegree += ((Convert.ToDouble(minute)) / num);

            int s = degrees.IndexOf('″');           //秒的符号对应的 Unicode 代码为：2033[1]（六十进制），显示为″。
            if (s < 0)
            {
                return (float)digitalDegree;
            }
            string second = degrees.Substring(m + 1, s - m - 1);
            digitalDegree += (Convert.ToDouble(second) / (num * num));

            return (float)digitalDegree;
        }

        /// <summary>
        /// 度分秒经纬度(必须含有'°') 转成 度分秒 int数组
        /// </summary>
        /// <param name="digitalDegree">度分秒经纬度</param>
        /// <return>数字经纬度</return>
        public static int[] ConvertDegreesToIntArray(string degrees)
        {
            int[] result = new int[3] { 0, 0, 0 };
            if (degrees == "")
            {
                return result;
            }
            const double num = 60;
            double digitalDegree = 0.0;
            int d = degrees.IndexOf('°');           //度的符号对应的 Unicode 代码为：00B0[1]（六十进制），显示为°。
            if (d < 0)
            {
                result[0] = Convert.ToInt32(degrees);
                return result;
            }

            string degree = degrees.Substring(0, d);
            digitalDegree += Convert.ToDouble(degree);
            result[0] = Convert.ToInt32(degree);

            int m = degrees.IndexOf('′');           //分的符号对应的 Unicode 代码为：2032[1]（六十进制），显示为′。
            if (m < 0)
            {
                return result;
            }

            string minute = degrees.Substring(d + 1, m - d - 1);
            digitalDegree += ((Convert.ToDouble(minute)) / num);
            result[1] = Convert.ToInt32(minute);

            int s = degrees.IndexOf('″');           //秒的符号对应的 Unicode 代码为：2033[1]（六十进制），显示为″。
            if (s < 0)
            {
                return result;
            }

            string second = degrees.Substring(m + 1, s - m - 1);
            digitalDegree += (Convert.ToDouble(second) / (num * num));
            result[2] = Convert.ToInt32(second);

            return result;
        }

        /// <summary>
        /// 度分秒经纬度(必须含有'°')和数字经纬度转换 
        /// </summary>
        /// <param name="digitalDegree">度分秒经纬度</param>
        /// <return>数字经纬度</return>
        public static double ConvertDegreesToDigitalCN(string degrees)
        {
            const double num = 60;
            double digitalDegree = 0.0;
            int d = degrees.IndexOf('度');           //度的符号对应的 Unicode 代码为：00B0[1]（六十进制），显示为°。
            if (d < 0)
            {
                return digitalDegree;
            }
            string degree = degrees.Substring(0, d);
            digitalDegree += Convert.ToDouble(degree);

            int m = degrees.IndexOf('分');           //分的符号对应的 Unicode 代码为：2032[1]（六十进制），显示为′。
            if (m < 0)
            {
                return digitalDegree;
            }
            string minute = degrees.Substring(d + 1, m - d - 1);
            digitalDegree += ((Convert.ToDouble(minute)) / num);

            int s = degrees.IndexOf('秒');           //秒的符号对应的 Unicode 代码为：2033[1]（六十进制），显示为″。
            if (s < 0)
            {
                return digitalDegree;
            }
            string second = degrees.Substring(m + 1, s - m - 1);
            digitalDegree += (Convert.ToDouble(second) / (num * num));

            return digitalDegree;
        }


        /// <summary>
        /// 度分秒经纬度(必须含有'/')和数字经纬度转换 
        /// </summary>
        /// <param name="digitalDegree">度分秒经纬度</param>
        /// <param name="cflag">分隔符</param>
        /// <return>数字经纬度</return>
        public static double ConvertDegreesToDigital_default(string degrees)
        {
            char ch = '/';
            return ConvertDegreesToDigital(degrees, ch);
        }

        /// <summary>
        /// 度分秒经纬度和数字经纬度转换 
        /// </summary>
        /// <param name="digitalDegree">度分秒经纬度</param>
        /// <param name="cflag">分隔符</param>
        /// <return>数字经纬度</return>
        public static double ConvertDegreesToDigital(string degrees, char cflag)
        {
            const double num = 60;
            double digitalDegree = 0.0;
            int d = degrees.IndexOf(cflag);
            if (d < 0)
            {
                return digitalDegree;
            }
            string degree = degrees.Substring(0, d);
            digitalDegree += Convert.ToDouble(degree);

            int m = degrees.IndexOf(cflag, d + 1);
            if (m < 0)
            {
                return digitalDegree;
            }
            string minute = degrees.Substring(d + 1, m - d - 1);
            digitalDegree += ((Convert.ToDouble(minute)) / num);

            int s = degrees.Length;
            if (s < 0)
            {
                return digitalDegree;
            }
            string second = degrees.Substring(m + 1, s - m - 1);
            digitalDegree += (Convert.ToDouble(second) / (num * num));

            return digitalDegree;
        }

        //匹配经纬度
        public static bool MatchDegrees(string degrees)
        {
            //18°12＇23.34＂ 18°12′23.34″
            Regex reg = new Regex("^[EW]?((\\d|[1-9]\\d|1[0-7]\\d)[s\\-,;°度](\\d|[0-5]\\d)[s\\-,;′分](\\d|[0-5]\\d)(\\.\\d{1,3})?[s\\-,;/″秒]?$)");
            if (reg.IsMatch(degrees))
                return true;
            else
                return false;
        }

        //返回时间戳
        public static int GetTimeStamp()
        {
            DateTime dt = DateTime.Now;
            DateTime dateStart = new DateTime(1970, 1, 1, 8, 0, 0);
            int timeStamp = Convert.ToInt32((dt - dateStart).TotalSeconds);
            return timeStamp;
        }

        /// <summary>
        /// 取时间戳，高并发情况下会有重复。想要解决这问题请使用sleep线程睡眠1毫秒。
        /// </summary>
        /// <param name="AccurateToMilliseconds">精确到毫秒</param>
        /// <returns>返回一个长整数时间戳</returns>
        public static long GetTimeStamp(bool AccurateToMilliseconds = false)
        {
            if (AccurateToMilliseconds)
            {

                // 使用当前时间计时周期数（636662920472315179）减去1970年01月01日计时周期数（621355968000000000）除去（删掉）后面4位计数（后四位计时单位小于毫秒，快到不要不要）再取整（去小数点）。

                //备注：DateTime.Now.ToUniversalTime不能缩写成DateTime.Now.Ticks，会有好几个小时的误差。

                //621355968000000000计算方法 long ticks = (new DateTime(1970, 1, 1, 8, 0, 0)).ToUniversalTime().Ticks;

                return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;

            }
            else
            {

                //上面是精确到毫秒，需要在最后除去（10000），这里只精确到秒，只要在10000后面加三个0即可（1秒等于1000毫米）。
                return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            }
        }

        //匹配汉字字符串
        public static bool IsMatchChinese(string input, string pattern)
        {
            int m = input.Length;
            int n = pattern.Length;
            if (m < n)
            {
                return false;
            }
            int[,] dp = new int[m + 1, n + 1];
            for (int i = 0; i <= m; i++)
            {
                dp[i, n] = 1;
            }
            for (int i = m - 1; i >= 0; i--)
            {
                char sChar = input[i];
                for (int j = n - 1; j >= 0; j--)
                {
                    char tChar = pattern[j];
                    if (sChar == tChar)
                    {
                        dp[i, j] = dp[i + 1, j + 1];
                    }
                    else
                    {
                        dp[i, j] = dp[i + 1, j];
                    }
                }
            }
            return dp[0, 0] >= 1 ? true : false;
        }

        //时长用00：00显示
        public static string ToTimeFormat(float time)
        {
            int seconds = (int)time;
            int minutes = seconds / 60;
            seconds %= 60;
            return string.Format("{0:D2}:{1:D2}", minutes, seconds);
        }

        //验证给定的字符串是否正确
        public static bool IsFormaCheck(string str)
        {
            try
            {
                int Num = int.Parse(str);
                //提取数字
                string regStr = @"[^0-9]+";
                string replaceStr = Regex.Replace(str, regStr, "");
                if (replaceStr.Length != 5)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        //验证给定的item是否在List存在
        public static bool IsContains<T>(List<T> list, T value)
        {
            foreach (var item in list)
            {
                if (item.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }
    }
}