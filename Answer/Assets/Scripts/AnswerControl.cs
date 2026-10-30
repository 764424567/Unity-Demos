using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerControl : MonoBehaviour
{
    //读取文档
    string[][] ArrayX;
    string[] lineArray;
    private int topicMax = 0;//最大题数
    private List<bool> isAnserList = new List<bool>();//存放是否答过题的状态

    //加载题目
    public Text indexText;//当前第几题
    public List<Text> DA_TextList;//选项
    public Text TM_Text;//当前题目
    public List<Toggle> toggleList;//答题Toggle
    public GameObject TipBtn;//提示按钮
    public Text tipsText;//提示信息
    private int topicIndex = 0;//第几题

    //按钮功能及提示信息
    public Text TextAccuracy;//正确率
    public Button BtnBack;//上一题
    public Button BtnNext;//下一题
    public InputField jumpInput;//跳转题目
    public Button BtnJump;//跳转题目
    private int anserint = 0;//已经答过几题
    private int isRightNum = 0;//正确题数


    void Start()
    {
        TextCsv();
        LoadAnswer();

        TipBtn.GetComponent<Button>().onClick.AddListener(() => Select_Answer(0));
        BtnBack.onClick.AddListener(() => Select_Answer(1));
        BtnNext.onClick.AddListener(() => Select_Answer(2));
        BtnJump.onClick.AddListener(() => Select_Answer(3));
    }


    /*****************读取txt数据******************/
    void TextCsv()
    {
        //读取csv二进制文件  
        TextAsset binAsset = Resources.Load("YW", typeof(TextAsset)) as TextAsset;
        //读取每一行的内容  
        lineArray = binAsset.text.Split('\r');
        //创建二维数组  
        ArrayX = new string[lineArray.Length][];
        //把csv中的数据储存在二维数组中  
        for (int i = 0; i < lineArray.Length; i++)
        {
            ArrayX[i] = lineArray[i].Split(':');
        }
        //查看保存的题目数据
        for (int i = 0; i < ArrayX.Length; i++)
        {
            for (int j = 0; j < ArrayX[i].Length; j++)
            {
                Debug.Log(ArrayX[i][j]);
            }
        }
        //设置题目状态
        topicMax = lineArray.Length;
        for (int x = 0; x < topicMax + 1; x++)
        {
            isAnserList.Add(false);
        }
    }

    /*****************加载题目******************/
    void LoadAnswer()
    {
        TipBtn.SetActive(false);
        tipsText.text = "";
        for (int x = 0; x < 4; x++)
        {
            toggleList[x].isOn = false;
        }
        indexText.text = "第" + (topicIndex + 1) + "题：";//第几题
        TM_Text.text = ArrayX[topicIndex][1];//题目
        int idx = ArrayX[topicIndex].Length - 3;//有几个选项
        for (int x = 0; x < idx; x++)
        {
            DA_TextList[x].text = ArrayX[topicIndex][x + 2];//选项
        }
    }

    /*****************按钮功能******************/
    void Select_Answer(int index)
    {
        switch (index)
        {
            case 0://提示
                int idx = ArrayX[topicIndex].Length - 1;
                int n = int.Parse(ArrayX[topicIndex][idx]);
                string nM = "";
                switch (n)
                {
                    case 1:
                        nM = "A";
                        break;
                    case 2:
                        nM = "B";
                        break;
                    case 3:
                        nM = "C";
                        break;
                    case 4:
                        nM = "D";
                        break;
                }
                tipsText.text = "<color=#FFAB08FF>" + "正确答案是：" + nM + "</color>";
                break;
            case 1://上一题
                if (topicIndex > 0)
                {
                    topicIndex--;
                    LoadAnswer();
                }
                else
                {
                    tipsText.text = "<color=#27FF02FF>" + "前面已经没有题目了！" + "</color>";
                }
                break;
            case 2://下一题
                if (topicIndex < topicMax - 1)
                {
                    topicIndex++;
                    LoadAnswer();
                }
                else
                {
                    tipsText.text = "<color=#27FF02FF>" + "哎呀！已经是最后一题了。" + "</color>";
                }
                break;
            case 3://跳转
                int x = int.Parse(jumpInput.text) - 1;
                if (x >= 0 && x < topicMax)
                {
                    topicIndex = x;
                    jumpInput.text = "";
                    LoadAnswer();
                }
                else
                {
                    tipsText.text = "<color=#27FF02FF>" + "不在范围内！" + "</color>";
                }
                break;
        }
    }
}
