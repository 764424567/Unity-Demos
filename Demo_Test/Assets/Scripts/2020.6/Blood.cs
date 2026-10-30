using UnityEngine;

public class Blood : MonoBehaviour
{
    //主角对象
    GameObject Player;
    //模型高度
    public float Height = 2.5f;
    //红色血条贴图
    public Texture2D blood_red;
    //黑色血条贴图
    public Texture2D blood_black;
    //血条宽高
    public float Blood_Width;
    public float Blood_Height;
    //默认NPC血值
    public int HP = 100;
    public float m_OffsetX;
    public float m_OffsetY;


    void Start()
    {
        Player = GameObject.Find("Prefab1");
    }

    void Update()
    {
        //保持NPC一直面朝主角
        //transform.LookAt(Player.transform);
    }

    void OnGUI()
    {
        Vector2 position = Camera.main.WorldToScreenPoint(Player.transform.position);
        GUI.DrawTexture(new Rect(position.x + m_OffsetX, position.y + m_OffsetY, Blood_Width, Blood_Height), blood_black);
        GUI.DrawTexture(new Rect(position.x + m_OffsetX, position.y + m_OffsetY, HP, Blood_Height), blood_red);
    }
}