using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using static MapTextureManager;

public class Location
{
    public static LatLng mLatLng = null;

    public static IEnumerator SetMap(int x, int y, Image image, int zoom)
    {
        string _path = string.Format("http://webrd01.is.autonavi.com/appmaptile?x={0}&y={1}&z={2}&lang=zh_cn&size=1&scale=1&style=8", x, y, zoom);

        //string.Format("http://online1.map.bdimg.com/onlinelabel/?qt=tile&x={0}&y={1}&z=18", x, y);
        //string.Format("https://wprd02.is.autonavi.com/appmaptile?lang=zh_cn&size=1&style=7&x={0}&y={1}&z=16&scl=1&ltype=1", x, y);

        WWW www = new WWW(_path);
        while (!www.isDone)
        {
            yield return null;
        }
        image.sprite = Sprite.Create(www.texture, new Rect(0, 0, LocationMap.TileWidthAndHeigth, LocationMap.TileWidthAndHeigth), new Vector2(0.5f, 0.5f));//www.texture;SpriteRenderer.sprite.pivot
    }

    public static IEnumerator LoadSpriteWebRequest(int x, int y, Image image, int zoom)
    {
        string _path = StitchingPath(x, y, zoom);
        Debug.Log(_path);
        UnityWebRequest req = UnityWebRequestTexture.GetTexture(_path);
        yield return req.SendWebRequest();
        if (req.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(req.error);
        }
        if (req.isDone)
        {
            image.sprite = Sprite.Create(DownloadHandlerTexture.GetContent(req), new Rect(0, 0, LocationMap.TileWidthAndHeigth, LocationMap.TileWidthAndHeigth), new Vector2(0.5f, 0.5f));
        }
    }

    /// <summary>
    /// 图片地址拼接
    /// </summary>
    /// <param name="zoom">层级</param>
    /// <param name="pieceX">行数</param>
    /// <param name="pieceY">列数</param>
    /// <returns></returns>
    static string StitchingPath(float pieceX, float pieceY, int zoom)
    {
        //return "D:/MapData/ImageBaiduData/" + zoom + "/" + (int)pieceX + "/" + (int)pieceY + ".png";
        return @"file://D:/MapData/GDMapData/mapabc/roadmap/" + zoom + "/" + (int)pieceX + "/" + (int)pieceY + ".png";
    }

    public static IEnumerator InitLocationPos()
    {
#if !UNITY_EDITOR
        if (!Input.location.isEnabledByUser)
        {
            Debug.LogError("Location is not enabled");
            yield break;
        }
#endif
        Input.location.Start(1, 1);
        int maxWait = 30;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if (maxWait < 1)
        {
            Debug.LogError("Location time out");
            yield break;
        }
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            yield break;
        }
        else
        {
            mLatLng = new LatLng(Input.location.lastData.longitude, Input.location.lastData.latitude);
            Input.location.Stop();
        }
    }

    /// <summary>
    /// 将tile(瓦片)坐标系转换为LatLngt(地理)坐标系，pixelX，pixelY为图片偏移像素坐标
    /// </summary>
    /// <param name="tileX"></param>
    /// <param name="tileY"></param>
    /// <param name="zoom"></param>
    /// <param name="pixelX"></param>
    /// <param name="pixelY"></param>
    /// <returns></returns>
    public static LatLng TileXYToLatLng(int tileX, int tileY, int zoom, int pixelX = 0, int pixelY = 0)
    {
        double size = Math.Pow(2, zoom);
        double pixelXToTileAddition = pixelX / LocationMap.TileWidthAndHeigth;
        double lng = (tileX + pixelXToTileAddition) / size * 360.0 - 180.0;

        double pixelYToTileAddition = pixelY / LocationMap.TileWidthAndHeigth;
        double lat = Math.Atan(Math.Sinh(Math.PI * (1 - 2 * (tileY + pixelYToTileAddition) / size))) * 180.0 / Math.PI;
        return new LatLng(lng, lat);
    }

    /// <summary>
    /// 将LatLngt地理坐标系转换为tile瓦片坐标系，pixelX，pixelY为图片偏移像素坐标
    /// </summary>
    /// <param name="latlng"></param>
    /// <param name="zoom"></param>
    /// <param name="tileX"></param>
    /// <param name="tileY"></param>
    /// <param name="pixelX"></param>
    /// <param name="pixelY"></param>
    public static TileInfo LatLngToTileXY(LatLng latlng, int zoom)
    {
        double size = Math.Pow(2, zoom);
        double x = ((latlng.Longitude + 180) / 360) * size;
        double lat_rad = latlng.Latitude * Math.PI / 180;
        double y = (1 - Math.Log(Math.Tan(lat_rad) + 1 / Math.Cos(lat_rad)) / Math.PI) / 2;
        y = y * size;

        int tileX = (int)x;
        int tileY = (int)y;
        return new TileInfo(tileX, tileY, (int)((x - tileX) * LocationMap.TileWidthAndHeigth), (int)((y - tileY) * LocationMap.TileWidthAndHeigth));
    }
}

public class LatLng
{
    public double Longitude;
    public double Latitude;
    public LatLng(double longitude, double latitude)
    {
        Longitude = longitude;
        Latitude = latitude;
    }
}