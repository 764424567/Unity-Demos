using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FoldableMenu : MonoBehaviour
{
    private RectTransform content;//父物体的parent
    private TextAsset textAsset;//所有菜单信息
    private RectTransform parentRect;//父菜单的prefab
    private RectTransform[] parentArr;//所有父菜单的数组
    private RectTransform childRect;//子菜单的prefab
    private Vector3 parentOffset;//单个父菜单的高度
    private Vector3 childOffset;//单个父菜单的高度
    private int[] cntArr;//所有父菜单拥有的子菜单个数

    void Awake()
    {
        Init();
    }

    void Init()
    {
        //获取到父节点
        content = transform.Find("Viewport/Content").GetComponent<RectTransform>();
        //获取到menuinfo里面的信息  3 3 4 4 5 5
        textAsset = Resources.Load<TextAsset>("menuInfo");
        //获取到父物体 设置父物体的高度
        parentRect = Resources.Load<RectTransform>("parentMenu");
        parentOffset = new Vector3(0, parentRect.rect.height);
        //获取到子物体 设置子物体的高度
        childRect = Resources.Load<RectTransform>("item");
        childOffset = new Vector3(0, childRect.rect.height);
        //分割字符串 info = 3 3 4 4 5 5
        var info = textAsset.text.Split(',');//获取子菜单个数信息
        //数组的长度
        cntArr = new int[info.Length];
        //父菜单的数组
        parentArr = new RectTransform[info.Length];
        //初始化content高度 宽度不变 高度是所有父物体的总长
        content.sizeDelta = new Vector2(content.rect.width, parentArr.Length * parentRect.rect.height);
        //i = 6
        for (int i = 0; i < cntArr.Length; i++)
        {
            //创建父物体
            parentArr[i] = Instantiate(parentRect, content.transform);
            //坐标为 上一个父物体的宽度
            parentArr[i].localPosition -= i * parentOffset;
            //赋值
            cntArr[i] = int.Parse(info[i]);
            //父物体上面加载子物体 子物体数量为3 3 4 4 5 5
            parentArr[i].GetComponent<ParentMenu>().Init(childRect, cntArr[i]);
            int j = i;
            //父物体上面的button绑定事件
            parentArr[i].GetComponent<Button>().onClick.AddListener(() => { OnButtonClick(j); });
        }
    }

    void OnButtonClick(int i)
    {
        //如果iscanclick为false则return  因为已经点击过了 不能再点击了 除非升起来的时候将isCanClick改为true
        if (!parentArr[i].GetComponent<ParentMenu>().isCanClick)
            return;
        parentArr[i].GetComponent<ParentMenu>().isCanClick = false;
        //isopening 为true 执行 menuup 为flase执行menuDown
        if (!parentArr[i].GetComponent<ParentMenu>().isOpening)
            StartCoroutine(MenuDown(i));
        else
            StartCoroutine(MenuUp(i));
    }

    IEnumerator MenuDown(int index)
    {       
        for (int i = 0; i < cntArr[index]; i++)
        {
            //更新content高度
            content.sizeDelta = new Vector2(content.rect.width,
                content.rect.height + childOffset.y);
            for (int j = index + 1; j < parentArr.Length; j++)
            {
                parentArr[j].localPosition -= childOffset;
            }
            yield return new WaitForSeconds(0.1f);
        }     
    }

    IEnumerator MenuUp(int index)
    {
        for (int i = 0; i < cntArr[index]; i++)
        {
            //更新content高度
            content.sizeDelta = new Vector2(content.rect.width,
                content.rect.height - childOffset.y);
            for (int j = index + 1; j < parentArr.Length; j++)
            {
                parentArr[j].localPosition += childOffset;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
