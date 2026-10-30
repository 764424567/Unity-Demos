using UnityEngine;
using System.Collections.Generic;

public class TempPic : MonoBehaviour
{
    public bool isUpdate = true;//是否需要刷新位置
    /// <summary>
    /// 块坐标
    /// </summary>
    public Vector2 PieceCoordinates;

    /// <summary>
    /// 四周八个相邻图片的位置  图位置 对应块坐标
    /// </summary>
    /// <returns></returns>
    public Dictionary<Vector2, Vector3> BoundsMapPos(Vector2 pieceNum, float size)
    {
        if (isUpdate || _boundsMapPos.Count == 0)
        {
            isUpdate = false;
            _boundsMapPos.Clear();
            GetDic(pieceNum, size);
        }
        return _boundsMapPos;
    }
    private readonly Dictionary<Vector2, Vector3> _boundsMapPos = new Dictionary<Vector2, Vector3>();

    public void SetColor(Color col)
    {
        if (spriterender == null)
            spriterender = GetComponent<SpriteRenderer>();
        spriterender.color = col;
    }
    void GetDic(Vector2 colraw, float size)
    {
        for (int i = 1; i < ((int)(colraw.x / 2)) + 1; i++)
        {
            for (int j = 1; j < ((int)(colraw.y / 2)) + 1; j++)
            {
                _boundsMapPos[PieceCoordinates + new Vector2(i, j)] = transform.position + new Vector3(size * i, 0, size * j);
                _boundsMapPos[PieceCoordinates + new Vector2(i, -j)] = transform.position + new Vector3(size * i, 0, -size * j);
                _boundsMapPos[PieceCoordinates + new Vector2(-i, -j)] = transform.position + new Vector3(-size * i, 0, -size * j);
                _boundsMapPos[PieceCoordinates + new Vector2(-i, j)] = transform.position + new Vector3(-size * i, 0, size * j);
                _boundsMapPos[PieceCoordinates + new Vector2(-i, 0)] = transform.position + new Vector3(-size * i, 0, 0);
                _boundsMapPos[PieceCoordinates + new Vector2(i, 0)] = transform.position + new Vector3(size * i, 0, 0);
                _boundsMapPos[PieceCoordinates + new Vector2(0, -j)] = transform.position + new Vector3(0, 0, -size * j);
                _boundsMapPos[PieceCoordinates + new Vector2(0, j)] = transform.position + new Vector3(0, 0, size * j);
            }
        }
    }

    private bool isshow = true;
    public void SetEnable(bool enable)
    {
        isshow = enable;
        spriterender.enabled = enable;
    }
    private SpriteRenderer spriterender;
    public void SetSprite(Sprite sp)
    {
        if (spriterender == null)
            spriterender = GetComponent<SpriteRenderer>();
        spriterender.sprite = sp;
        if (!spriterender.enabled && isshow)
            spriterender.enabled = true;
        if (GetComponent<BoxCollider>() == null)
        {
            BoxCollider box = gameObject.AddComponent<BoxCollider>();
            box.isTrigger = false;
        }
    }
}