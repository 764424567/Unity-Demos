using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 此类中 有两个坐标系，
/// 一个是瓦片地图 的坐标
/// 一个是实例化prefab 把瓦片地图 负值的gameobject 坐标
/// </summary>
public class LocationMap : MonoBehaviour
{
    [SerializeField]
    private GameObject Map;
    //为什么设置成256*256，因为高的返回的图就是256的，还有一种类型是512*512
    public static float TileWidthAndHeigth = 256;
    public int TileZoom = 16;

    //加载的Image 的缩放
    public static float TileScale = 1;

    [SerializeField]
    private GameObject TileMap;

    private List<TileImageInfo> TileMaps = null;

    //中心 瓦片信息类
    private LatLng latLng;//初始坐标
    private TileInfo m_centerTileInfo = null;

    //最好是正方形，容易计算，目前没处理 非正方形
    //瓦片行数
    public readonly int TileRow = 14;
    //瓦片列数
    public readonly int TileColumn = 18;

    private void Awake()
    {
        TileScale = TileMap.transform.localScale.x;
    }

    private void Start()
    {
#if UNITY_EDITOR
        //测试数据
        latLng = new LatLng(113.65700, 34.75572);
#endif
        StartCoroutine(InitTileInfo());
    }

    private void Update()
    {
        //if (Input.GetAxis("Mouse ScrollWheel") != 0)
        //{
        //    if (Input.GetAxis("Mouse ScrollWheel") < 0)
        //    {
        //        TileZoom -= 1;
        //    }
        //    if (Input.GetAxis("Mouse ScrollWheel") > 0)
        //    {
        //        TileZoom += 1;
        //    }
        //    UpdateTileZoom(TileZoom);
        //}
    }

    private IEnumerator InitTileInfo()
    {
        yield return Location.InitLocationPos();

        if (Location.mLatLng != null)
        {
            if (latLng == null) yield break;

            m_centerTileInfo = Location.LatLngToTileXY(latLng, TileZoom);
            Debug.Log(m_centerTileInfo.TileX+" "+ m_centerTileInfo.TileY);

            InitAllTile();
        }
    }

    private void UpdateTileZoom(int TileZoom)
    {
        for (int i = 0; i < Map.transform.childCount; i++)
        {
            Destroy(Map.transform.GetChild(i).gameObject);
        }
        m_centerTileInfo = Location.LatLngToTileXY(latLng, TileZoom);
        //求的 左上角的 x 和 y的 瓦片值
        int x = m_centerTileInfo.TileX - (TileColumn - 1) / 2;
        int y = m_centerTileInfo.TileY - (TileRow - 1) / 2;
        //左上角Image 图片的坐标
        Vector3 sour = new Vector3(0 - TileWidthAndHeigth * (TileColumn - 1) / 2 * TileScale, 0 + TileWidthAndHeigth * (TileRow - 1) / 2 * TileScale, 0);
        TileMaps = new List<TileImageInfo>(TileRow * TileColumn);
        TileImageInfo[] gameObjects = new TileImageInfo[TileRow * TileColumn];
        for (int i = 0; i < TileRow; i++)
        {
            for (int j = 0; j < TileColumn; j++)
            {
                GameObject g = Instantiate(TileMap, Map.transform);
                g.transform.localPosition = sour + new Vector3(j * TileWidthAndHeigth * TileScale, 0, 0);

                //求取瓦片地图横向坐标
                //int _x = x + j;

                //加载瓦片地图
                StartCoroutine(Location.SetMap(x, y, g.GetComponent<Image>(), TileZoom));

                //瓦片Image 存入数组
                gameObjects[j + i * TileColumn] = new TileImageInfo(x, y, g);
                g.SetActive(true);
            }
            y += 1;
            sour -= new Vector3(0, TileWidthAndHeigth * TileScale, 0);
        }
        TileMaps.AddRange(gameObjects);
    }

    private void InitAllTile()
    {
        //求的 左上角的 x 和 y的 瓦片值
        int x = m_centerTileInfo.TileX;
        int y = m_centerTileInfo.TileY;
        //左上角Image 图片的坐标
        Vector3 sour = new Vector3(0 - TileWidthAndHeigth * (TileColumn - 1) / 2 * TileScale, 0 + TileWidthAndHeigth * (TileRow - 1) / 2 * TileScale, 0);
        TileMaps = new List<TileImageInfo>(TileRow * TileColumn);
        TileImageInfo[] gameObjects = new TileImageInfo[TileRow * TileColumn];
        for (int i = 0; i < TileRow; i++)
        {
            for (int j = 0; j < TileColumn; j++)
            {
                GameObject g = Instantiate(TileMap, Map.transform);
                g.transform.localPosition = sour + new Vector3(j * TileWidthAndHeigth * TileScale, 0, 0);

                //求取瓦片地图横向坐标
                int _x = x + j;

                //加载瓦片地图
                //Debug.Log(_x+" "+y);
                StartCoroutine(Location.LoadSpriteWebRequest(_x, y, g.GetComponent<Image>(), TileZoom));

                //瓦片Image 存入数组
                gameObjects[j + i * TileColumn] = new TileImageInfo(_x, y, g);
                g.SetActive(true);
            }
            y += 1;
            sour -= new Vector3(0, TileWidthAndHeigth * TileScale, 0);
        }
        TileMaps.AddRange(gameObjects);
    }

    /// <summary>
    /// 更新瓦片位置
    /// </summary>
    /// <param name="direction"></param>
    public void MapUpdate(Direction direction = Direction.up)
    {
        int x;
        int y;

        switch (direction)
        {
            case Direction.up:
                //下向上更新
                x = m_centerTileInfo.TileX - (TileColumn - 1) / 2;
                y = m_centerTileInfo.TileY - (TileRow - 1) / 2 - 1;
                for (int i = 0; i < TileColumn; i++)
                {
                    //把最后一排搬到第一排
                    TileImageInfo info = TileMaps[i + TileColumn * (TileRow - 1)];
                    info.Go.transform.localPosition += new Vector3(0, TileWidthAndHeigth * TileRow * TileScale, 0);
                    info.TileX = x;
                    info.TileX = y;

                    StartCoroutine(Location.LoadSpriteWebRequest(x, y, info.Go.GetComponent<Image>(), TileZoom));
                    x++;
                    //冒泡
                    for (int j = 1; j <= TileRow - 1; j++)
                    {
                        int index1 = i + TileColumn * (TileRow - j);
                        int index2 = i + TileColumn * (TileRow - j - 1);
                        TileImageInfo temp = TileMaps[index1];
                        TileMaps[index1] = TileMaps[index2];
                        TileMaps[index2] = temp;
                    }
                }
                m_centerTileInfo.TileY--;
                break;
            case Direction.down:
                x = m_centerTileInfo.TileX - (TileColumn - 1) / 2;
                y = m_centerTileInfo.TileY + (TileRow - 1) / 2 + 1;
                for (int i = 0; i < TileColumn; i++)
                {
                    //把第一排搬到最后一排
                    TileImageInfo info = TileMaps[i];
                    info.Go.transform.localPosition -= new Vector3(0, TileWidthAndHeigth * TileRow * TileScale, 0);
                    info.TileX = x;
                    info.TileX = y;

                    StartCoroutine(Location.LoadSpriteWebRequest(x, y, info.Go.GetComponent<Image>(), TileZoom));
                    x++;
                    //冒泡
                    for (int j = 0; j < TileRow - 1; j++)
                    {
                        int index1 = i + TileColumn * j;
                        int index2 = i + TileColumn * (j + 1);
                        TileImageInfo temp = TileMaps[index1];
                        TileMaps[index1] = TileMaps[index2];
                        TileMaps[index2] = temp;
                    }
                }
                m_centerTileInfo.TileY++;
                break;
            case Direction.left:
                x = m_centerTileInfo.TileX - (TileColumn - 1) / 2 - 1;
                y = m_centerTileInfo.TileY - (TileRow - 1) / 2;
                for (int i = 0; i < TileRow; i++)
                {
                    //把最右列移到最左列
                    TileImageInfo info = TileMaps[i * TileColumn + (TileColumn - 1)];
                    info.Go.transform.localPosition -= new Vector3(TileWidthAndHeigth * TileColumn * TileScale, 0, 0);
                    info.TileX = x;
                    info.TileX = y;

                    StartCoroutine(Location.LoadSpriteWebRequest(x, y, info.Go.GetComponent<Image>(), TileZoom));
                    y++;
                    //冒泡
                    for (int j = 1; j <= TileColumn - 1; j++)
                    {
                        int index1 = i * TileColumn + (TileColumn - j);
                        int index2 = i * TileColumn + (TileColumn - j - 1);
                        TileImageInfo temp = TileMaps[index1];
                        TileMaps[index1] = TileMaps[index2];
                        TileMaps[index2] = temp;
                    }
                }
                m_centerTileInfo.TileX--;
                break;
            case Direction.right:
                x = m_centerTileInfo.TileX + (TileColumn - 1) / 2 + 1;
                y = m_centerTileInfo.TileY - (TileRow - 1) / 2;
                for (int i = 0; i < TileRow; i++)
                {
                    //把最左列移到最右列
                    TileImageInfo info = TileMaps[i * TileColumn];
                    info.Go.transform.localPosition += new Vector3(TileWidthAndHeigth * TileColumn * TileScale, 0, 0);
                    info.TileX = x;
                    info.TileX = y;

                    StartCoroutine(Location.LoadSpriteWebRequest(x, y, info.Go.GetComponent<Image>(), TileZoom));
                    y++;
                    //冒泡
                    for (int j = 0; j < TileColumn - 1; j++)
                    {
                        int index1 = i * TileColumn + j;
                        int index2 = i * TileColumn + (j + 1);
                        TileImageInfo temp = TileMaps[index1];
                        TileMaps[index1] = TileMaps[index2];
                        TileMaps[index2] = temp;
                    }
                }
                m_centerTileInfo.TileX++;
                break;
        }

        //每次修改 释放资源
        Resources.UnloadUnusedAssets();
    }
}