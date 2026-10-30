using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;

public class MapManager : MonoBehaviour
{
    public static MapManager ins;
    [Header("是否打开日志")]
    public bool isDebug = false;
    public Dictionary<Vector2, TempPic> tempPics = new Dictionary<Vector2, TempPic>();
    public int zoom = 10;
    private MCObject MC = new MCObject();
    public MapAxesTransfer mapAxesTransfer;
    private MapTextureManager LoadTexture;
    /// <summary>
    /// 尺寸
    /// </summary>
    private Vector2 numSize;

    [Header("初始化后视角是否在中心")]
    public bool iscenter;

    void Start()
    {
        //WD_Debug.ins = isDebug;
        ins = this;
        mapAxesTransfer = GetComponentInChildren<MapAxesTransfer>();
        LoadTexture = GetComponent<MapTextureManager>();
        mapAxesTransfer.Init();
        int sizes = (int)(1920 / mapAxesTransfer.picSize.x);
        numSize = new Vector2(sizes + 3, sizes + 3);//决定地图几圈的地方
        //WD_Debug._Print("计算排列  " + numSize + "   " + Screen.width);
        //InitMap();
        InitMap(iscenter);
    }

    Vector2D CameraLL;
    //更换层级
    public void ChangeLayer(int zoom)
    {
        Vector3 Screensize = new Vector3(Screen.width / 2, Screen.height / 2);
        ray = Camera.main.ScreenPointToRay(Screensize);
        if (Physics.Raycast(ray, out hit)) //
        {
            //换之前先记录下当前中心位置的平面坐标   换之后 没有正确的块坐标不好找
            Vector2D centerMC = mapAxesTransfer.WorldToMC(hit.point);
            CameraLL = mapAxesTransfer.WorldToLL(hit.point);
            //WD_Debug._Print("换之前的MC坐标" + centerMC.x + "   " + centerMC.y);
            this.zoom = zoom;
            mapAxesTransfer.ChangeLayer(zoom);//这里已经将左下角块坐标重新计算了
            tempPics.Remove(centerTemppic.PieceCoordinates);//这里删除之前的中心位置  后边设置得是新的中心块
            centerTemppic.PieceCoordinates = mapAxesTransfer.MCToPiece(centerMC);

            //计算出下一个中心快的坐标之后  在计算其位置 以左下角为00点结算
            Vector2 offset = centerTemppic.PieceCoordinates - mapAxesTransfer.leftPiece;
            Vector3 InitPosition = new Vector3(offset.x, 0, offset.y);
            InitPosition *= mapAxesTransfer.pixel;
            // WD_Debug._Print("转换之后的块坐标" + centerTemppic.PieceCoordinates + " 坐标差 " + offset + "  位置" + InitPosition);
            centerTemppic.transform.position = InitPosition;
            centerTemppic.isUpdate = true;
            centerPos = centerTemppic.PieceCoordinates;
            InitMap(true, true);
        }
    }
    Camera cameramain;

    public void SetMapEnable(bool isEnable)
    {
        foreach (var map in tempPics.Values)
            map.SetEnable(isEnable);
    }
    void Update()
    {
        TileUpdate();
    }
    /// <summary>
    /// 中心图块周围坐标对应图块的信息
    /// </summary>
    private Dictionary<Vector2, Vector3> Groundpoints;
    /// <summary>
    /// 中心图块
    /// </summary>
    public TempPic centerTemppic;
    private Ray ray;
    private RaycastHit hit;

    //刷新地图
    void TileUpdate()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Physics.Raycast(ray, out hit, 1000, 1 << 8)) //
            {
                if (Input.GetMouseButtonUp(0))
                {
                    mapAxesTransfer.WorldToMC(hit.point);
                }
            }
        }
        if (Input.GetMouseButtonUp(2) || Input.GetMouseButtonUp(1))
        {
            //找新的中心图 并刷新其周围图块 新的中心块一定是距离相机最近的一个 需要计算
            UpdateCamera();
        }
    }

    public void UpdateCamera()
    {
        Vector3 Screensize = new Vector3(Screen.width / 2, Screen.height / 2);
        ray = Camera.main.ScreenPointToRay(Screensize);
        if (Physics.Raycast(ray, out hit))//
        {
            if (hit.transform.gameObject.layer == 8)
            {
                if (hit.transform != centerTemppic.transform)
                {
                    Groundpoints[centerTemppic.PieceCoordinates] = centerTemppic.transform.position;
                    centerTemppic = hit.transform.GetComponent<TempPic>();
                    centerTemppic.isUpdate = true;
                    Groundpoints.Remove(centerTemppic.PieceCoordinates);
                    MapUpdate();
                }
            }
        }
    }

    [Header("是否使用输入得到中心点位置")]
    public bool IsInputCenter = false;
    [Header("输入的中心点经纬度")]
    public double inputlat = 118.050357d, inputlng = 36.860605d;
    void GetInputCenter()
    {
        centerPos = mapAxesTransfer.LLToPiece(new Vector2D(inputlat, inputlng), zoom);
    }
    public Vector2 centerPos;//中心块的块坐标
    //临时存储要删掉的图 
    public List<GameObject> TempDeleteMaps = new List<GameObject>();
    /// <summary>
    /// 初始化地图 以平面坐标左下角的图块的世界坐标为000;
    /// </summary>
    /// <param name="Center"></param>
    void InitMap(bool Center, bool isRefresh = false)
    {
        Vector3 InitPosition = Vector3.zero;
        var TempPicPre = Resources.Load<GameObject>("Prefabs/TempPic");

        if (Center)
        {
            if (centerPos == Vector2.zero) //调用之前 赋值中心点.则 是更新地图层级.
                centerPos = new Vector2(Convert.ToInt32((mapAxesTransfer.leftPiece.x + mapAxesTransfer.rightPiece.x) / 2),
                    Convert.ToInt32((mapAxesTransfer.leftPiece.y + mapAxesTransfer.rightPiece.y) / 2));
            if (IsInputCenter) GetInputCenter();
            Vector2 offset = centerPos - mapAxesTransfer.leftPiece;

            // Debug.Log(offset);
            InitPosition = new Vector3(/*(int)numSize.x / 2 + 1 + */offset.x, 0, /*(int)numSize.y / 2 + 1 +*/ offset.y);
            InitPosition *= mapAxesTransfer.pixel;
        }
        else
        {
            //新的初始化 以图块左下角的图为原点  旧的是全图块中间的图作为原点
            //中心图块的块坐标   x是列数 y是行数
            centerPos = new Vector2(Convert.ToInt32((mapAxesTransfer.leftPiece.x + numSize.x / 2 + 1)), Convert.ToInt32((mapAxesTransfer.leftPiece.y + numSize.y / 2 + 1)));
            //初始化生成 具体数量是否要可变得 ?
            InitPosition = new Vector3((int)numSize.x / 2 + 1, 0, (int)numSize.x / 2 + 1);
            InitPosition *= mapAxesTransfer.pixel;
            //设置相机
        }
        //初始位置放到目标点
        if (isRefresh)
            RefreshMapLayer();
        else
            SetMap(TempPicPre, centerPos, InitPosition);
        Vector3 cameraPos;
        if (isRefresh)
            cameraPos = mapAxesTransfer.LLToWorld(CameraLL);
        else
            cameraPos = new Vector3(InitPosition.x + mapAxesTransfer.pixel / 2, 20, InitPosition.z + mapAxesTransfer.pixel / 2);
        Camera.main.transform.position = new Vector3(cameraPos.x, 20, cameraPos.z);

    }
    /// <summary>
    /// 以左下角为零点计算地图
    /// </summary>
    void SetMap(GameObject TempPicPre, Vector2 centerPos, Vector3 InitPosition)
    {
        //WD_Debug._Print("初始化");
        //新的初始化 以图块左下角的图为原点  旧的是全图块中间的图作为原点
        GameObject centerTemp = Instantiate(TempPicPre, InitPosition, Quaternion.Euler(90, 0, 0)) as GameObject;
        centerTemp.transform.SetParent(transform);
        centerTemp.name = centerPos.ToString();
        centerTemppic = centerTemp.GetComponent<TempPic>();
        centerTemppic.PieceCoordinates = centerPos;
        LoadTexture.AddLoadTask(zoom, (int)centerPos.x, (int)centerPos.y, tex =>
        {
            centerTemppic.SetSprite(tex);
        });
        tempPics[centerPos] = centerTemppic;
        Groundpoints = centerTemppic.BoundsMapPos(numSize, mapAxesTransfer.pixel);
        foreach (var pos in Groundpoints.Keys)
        {
            GameObject temp = Instantiate(TempPicPre, Groundpoints[pos], Quaternion.Euler(90, 0, 0)) as GameObject;
            temp.transform.SetParent(transform);
            TempPic temppic = temp.GetComponent<TempPic>();
            LoadTexture.AddLoadTask(zoom, (int)pos.x, (int)pos.y, tex =>
            {
                temppic.SetSprite(tex);
            });
            // temppic.LoadPicSingleInit(GetPathZoom(pos));
            temppic.name = pos.ToString();
            temppic.PieceCoordinates = pos;
            tempPics[pos] = temppic;
        }
        LoadTexture.Preload(mapAxesTransfer.PieceToZoom(centerPos, zoom));
    }

    /// <summary>
    /// 中心图片更换之后调用 刷新周围 算法需要优化
    /// </summary>
    void MapUpdate()
    {
        Dictionary<Vector2, Vector3> newGroundpoints = centerTemppic.BoundsMapPos(numSize, mapAxesTransfer.pixel);
        List<Vector2> SamePoint = new List<Vector2>();//相同的点
        foreach (var pos in Groundpoints.Keys)
        {
            foreach (var poss in newGroundpoints.Keys)
            {
                if (!SamePoint.Contains(pos) && !SamePoint.Contains(poss))
                {
                    if (!newGroundpoints.ContainsKey(pos) && !Groundpoints.ContainsKey(poss))
                    {
                        SamePoint.Add(poss);
                        SamePoint.Add(pos);
                        if (tempPics.ContainsKey(pos))
                        {
                            TempPic temp = tempPics[pos];
                            temp.transform.position = newGroundpoints[poss];
                            temp.PieceCoordinates = poss;
                            temp.name = poss.ToString();
                            LoadTexture.AddLoadTask(zoom, (int)poss.x, (int)poss.y, tex =>
                            {
                                temp.SetSprite(tex);
                            });
                            //temp.LoadPicSingleInit(GetPathZoom(poss));
                            tempPics[poss] = temp;
                            tempPics.Remove(pos);
                        }
                    }
                }
            }
        }
        SamePoint.Clear();
        Groundpoints = newGroundpoints;
    }

    /// <summary>
    /// 刷新地图层级
    /// </summary>
    void RefreshMapLayer()
    {
        Dictionary<Vector2, TempPic> Vec_Temps = new Dictionary<Vector2, TempPic>();
        Vec_Temps[centerTemppic.PieceCoordinates] = centerTemppic;
        centerTemppic.name = centerTemppic.PieceCoordinates.ToString();
        LoadTexture.AddLoadTask(zoom, (int)centerTemppic.PieceCoordinates.x, (int)centerTemppic.PieceCoordinates.y, tex =>
        {
            centerTemppic.SetSprite(tex);
        });
        Dictionary<Vector2, Vector3> newGroundpoints = centerTemppic.BoundsMapPos(numSize, mapAxesTransfer.pixel);
        int index = 0;
        foreach (var poss in newGroundpoints.Keys)
        {
            var obj = tempPics.ElementAt(index);
            index++;
            TempPic temp = obj.Value;
            if (temp.transform.position != newGroundpoints[poss])//刷层级的时候其实,15级以下不会有重复  
                temp.transform.position = newGroundpoints[poss];
            temp.PieceCoordinates = poss;
            temp.name = poss.ToString();

            LoadTexture.AddLoadTask(zoom, (int)poss.x, (int)poss.y, tex =>
            {
                temp.SetSprite(tex);
            });
            Vec_Temps[poss] = temp;
        }
        tempPics = Vec_Temps;
    }

}