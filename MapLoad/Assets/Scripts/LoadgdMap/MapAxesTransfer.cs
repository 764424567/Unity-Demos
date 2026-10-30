using System;
using System.Collections.Generic;
using UnityEngine;

//地图坐标轴转换
public class MapAxesTransfer : MonoBehaviour
{
    public static MapAxesTransfer ins;
    //  public MapPicData mapPicData = new MapPicData();
    MCObject MC = new MCObject();
    public int zoom = 10;
    /// <summary>
    /// 图片大小 分辨率
    /// </summary>
    public Vector2 picSize = new Vector2(256, 256);
    /// <summary>
    /// 图片的每单位像素  图片资源的设置
    /// </summary>
    public int PixelsPerUnit = 100;
    #region 初始坐标
    public Vector2D InitleftLL
    {
        get
        {
            return new Vector2D()
            {
                x = 左下角经度,
                y = 左下角纬度,
            };
        }
    }
    public Vector2D rightLL
    {
        get
        {
            return new Vector2D()
            {
                x = 右上角经度,
                y = 右上角纬度,
            };
        }
    }
    public double 左下角经度 = 117.811422d, 左下角纬度 = 36.655215d;//117.811422d, 36.655215d
    public double 右上角经度 = 118.214941d, 右上角纬度 = 36.888737d;//118.214941d, 36.888737d
    #endregion



    public Vector2D leftLL = new Vector2D();
    //左下角的MC坐标
    public Vector2D leftDownMC = new Vector2D();
    //全图左下角块坐标
    public Vector2 leftPiece;
    public Vector2 rightPiece;
    /// <summary>
    /// 单个图块unity世界坐标的长度
    /// </summary>
    public float pixel;
    /// <summary>
    /// 单块平面坐标长度
    /// </summary>
    double pieceLengh;
    public Vector3 GetRightPos()
    {
        return new Vector3(rightPiece.x - leftPiece.x, 20, rightPiece.y - leftPiece.y) * pixel;
    }
    public void Init()
    {
        ins = this;
        pixel = picSize.x / PixelsPerUnit;
        leftDownMC = MC.convertLL2MC(InitleftLL.x, InitleftLL.y);
        leftPiece = LLToPiece(InitleftLL, zoom);
        rightPiece = LLToPiece(rightLL, zoom);
        ChangeLayer(zoom);
        //WD_Debug._Print(Math.Pow(2, zoom - 18));
        //MCToWorld(null);
        TestSet();
    }
    //更换层级 一些东西要重新计算定义
    public void ChangeLayer(int zoom)
    {
        this.zoom = zoom;
        leftPiece = LLToPiece(InitleftLL, zoom);
        rightPiece = LLToPiece(rightLL, zoom);
        pieceLengh = picSize.x / Math.Pow(2, zoom - 18);

        //WD_Debug._Print("左下角1  " + leftPiece + "  单块平面坐标的长度" + pieceLengh + "   左下角MC   " + leftDownMC.x);
        //下边两行先后顺序不能变 否则计算有误差  计算的时候是以leftDownMC为基准计算的   leftDownMC必须由修正后的经纬度计算
        ReSetLL();//修正经纬度
        TestSet();
    }
    //测试 更换层级之后的参考点位置
    GameObject g;
    void TestSet()
    {
        Vector2D mcpos = MC.convertLL2MC(referencePointLngLat.x, referencePointLngLat.y);
        Vector3 world = MCToWorld(mcpos);
        if (g == null)
            g = new GameObject("参考点");

        g.transform.position = world;
    }

    //修正经纬度到左下角 原因 : 在网页上取的经纬度 和实际上左下角块坐标的经纬度肯定是有偏差的, 需要重新计算
    private void ReSetLL()
    {
        //块坐标转平面坐标  块坐标乘以ppu
        Vector2D mcPos = new Vector2D()
        {
            x = leftPiece.x * picSize.x + 1,
            y = leftPiece.y * picSize.x + 1
        };
        mcPos.x /= Math.Pow(2, zoom - 18);
        mcPos.y /= Math.Pow(2, zoom - 18);
        //MC坐标转经纬度
        leftLL = MC.convertMC2LL(mcPos.x, mcPos.y);
    }

    //取层级对应的所有块坐标的左下角和右上角
    public Dictionary<int, Vector4> ZoomToLRPiece(int startZoom, int endZoom)
    {
        Dictionary<int, Vector4> zoomtoPiece = new Dictionary<int, Vector4>();
        for (int i = startZoom; i < endZoom; i++)
        {
            zoomtoPiece[i] = new Vector4()
            {
                x = LLToPiece(InitleftLL, i).x,
                y = LLToPiece(InitleftLL, i).y,
                z = LLToPiece(rightLL, i).x,
                w = LLToPiece(rightLL, i).y,
            };
        }
        // WD_Debug._Error(zoomtoPiece.Count);
        return zoomtoPiece;
    }
    //取一个坐标附近各个层级的块坐标
    public Dictionary<int, List<Vector2>> PieceToZoom(Vector2 CenterPiece, int zoom)
    {
        Dictionary<int, List<Vector2>> zoomtoPiece = new Dictionary<int, List<Vector2>>();
        for (int i = 15; i < 18 + 1; i++)
        {
            float coe = (float)Math.Pow(2, zoom - i);
            Vector2 newPiece = new Vector2((int)(CenterPiece.x / coe),
                (int)(CenterPiece.y / coe));
            //  WD_Debug._Print(zoom + "   " + i + "   新中点" + newPiece + "系数?   " + (float)Math.Pow(2, zoom - i));
            zoomtoPiece[i] = GetDic(newPiece, new Vector2(10, 10));
        }
        return zoomtoPiece;
    }
    List<Vector2> GetDic(Vector2 CenterPiece, Vector2 colraw)
    {
        List<Vector2> ListPieces = new List<Vector2>();
        for (int i = 1; i < ((int)(colraw.x / 2)) + 1; i++)
        {
            for (int j = 1; j < ((int)(colraw.y / 2)) + 1; j++)
            {
                ListPieces.Add(CenterPiece + new Vector2(i, j));
                ListPieces.Add(CenterPiece + new Vector2(i, -j));
                ListPieces.Add(CenterPiece + new Vector2(-i, -j));
                ListPieces.Add(CenterPiece + new Vector2(-i, j));
                ListPieces.Add(CenterPiece + new Vector2(-i, 0));
                ListPieces.Add(CenterPiece + new Vector2(i, 0));
                ListPieces.Add(CenterPiece + new Vector2(0, -j));
                ListPieces.Add(CenterPiece + new Vector2(0, j));

            }
        }
        return ListPieces;
    }

    /// <summary>
    /// 经纬度取块坐标
    /// </summary>
    public Vector2 LLToPiece(Vector2D LL, int Zoom)
    {
        //先转墨卡托坐标
        Vector2D piece = MC.convertLL2MC(LL.x, LL.y);
        //转换到zoom级别下
        piece.x *= Math.Pow(2, Zoom - 18);
        piece.y *= Math.Pow(2, Zoom - 18);
        //墨卡托取块坐标
        return new Vector2((int)(piece.x / picSize.x), (int)(piece.y / picSize.x));
    }

    /// <summary>
    /// 世界坐标转经纬度
    /// </summary>
    /// <returns></returns>
    public Vector2D WorldToLL(Vector3 worldPos)
    {
        //计算偏移像素量 世界坐标乘以ppu 
        Vector2D MCOffset = new Vector2D()
        {
            x = worldPos.x * PixelsPerUnit,
            y = worldPos.z * PixelsPerUnit,
        };
        return MC.Point_Offset(leftLL.x, leftLL.y, MCOffset.x, MCOffset.y, zoom);
    }

    /// <summary>
    /// 经纬度转世界坐标
    /// </summary>
    public Vector3 LLToWorld(Vector2D LL)
    {
        Vector2D TempMC = MC.convertLL2MC(LL.x, LL.y);
        Vector3 world = MCToWorld(TempMC);
        return world;
    }

    /// <summary>
    /// 世界坐标转墨卡托坐标  
    /// </summary>
    public Vector2D WorldToMC(Vector3 worldPos)
    {
        Vector2D LL = WorldToLL(worldPos);
        Vector2D leftDownMCs = MC.convertLL2MC(LL.x, LL.y);
        return leftDownMCs;
    }

    /// <summary>
    /// 墨卡托转世界坐标
    /// </summary>
    public Vector3 MCToWorld(Vector2D MC)
    {
        string[] X = (MC.x / pieceLengh).ToString().Split('.');
        string[] Y = (MC.y / pieceLengh).ToString().Split('.');
        //小数点之前的是块坐标
        long pieceX = long.Parse(X[0]);
        long pieceY = long.Parse(Y[0]);
        Vector2 piecePos = new Vector2(pieceX, pieceY);
        double s = MC.x / pieceLengh;
        //小数点之后的是偏移量
        float ratioX = float.Parse("0." + X[1]);
        float ratioY = float.Parse("0." + Y[1]);
        //块偏移量 
        Vector2 offsettt = (piecePos - leftPiece);
        Vector3 center = new Vector3(ratioX + offsettt.x, 0, ratioY + offsettt.y);
        center *= pixel;
        return center;

    }

    /// <summary>
    /// 墨卡托转块
    /// </summary>
    public Vector2 MCToPiece(Vector2D centerMC)
    {

        //WD_Debug._Print("zoom = " + zoom + "   " + Math.Pow(2, zoom - 18) + "    " + centerMC.x);

        centerMC.x *= Math.Pow(2, zoom - 18);
        centerMC.y *= Math.Pow(2, zoom - 18);
        //墨卡托取块坐标
        return new Vector2((int)(centerMC.x / picSize.x), (int)(centerMC.y / picSize.x));
    }


    /// <summary>
    /// 米坐标转世界坐标
    /// </summary>
    public Vector3 CMToWorld(float x, float y)
    {
        //转经纬度
        Vector2D LL = CMToLatLng(x, y);
        //经纬度转世界坐标
        Vector2D MCs = MC.convertLL2MC(LL.x, LL.y);
        if (MCs.x == 0) return new Vector3();

        return MCToWorld(MCs);
    }

    //参考点
    private Vector2D referencePointLngLat = new Vector2D()
    {
        x = 118.050357d,
        y = 36.860605d
    };
    //米坐标
    private Vector2D referencePointXY = new Vector2D()
    {
        x = -3576280,
        y = -1258750,
    };

    /// <summary>
    /// 米坐标 转经纬度
    /// </summary>
    public Vector2D CMToLatLng(float x, float y)
    {
        double Dx = x * 10.0f - referencePointXY.x / 1000.0f;
        double Dy = y * 10.0f - referencePointXY.y / 1000.0f;

        double c = 6371393f * 2f * Math.PI;
        double ss = c * Math.Cos(referencePointLngLat.y * Mathf.Deg2Rad);//当前纬度的周长
        double d_m = 360f / ss;//度每米

        double cd = 360f / c;//赤道度每米
        Vector2D LL = new Vector2D()
        {
            //经度
            x = Dx * d_m + referencePointLngLat.x,
            //纬度
            y = Dy * cd + referencePointLngLat.y
        };
        return LL;
    }
}