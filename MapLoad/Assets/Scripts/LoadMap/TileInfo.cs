using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 滑动方向枚举
/// </summary>
public enum Direction
{
    up,
    down,
    left,
    right
}

/// <summary>
/// 瓦片信息类
/// </summary>
public class TileInfo
{
    public int TileX { get; set; }
    public int TileY { get; set; }
    public int PixelX { get; set; }
    public int PixelY { get; set; }

    public TileInfo(int tileX, int tileY, int pixelX, int pixelY)
    {
        TileX = tileX;
        TileY = tileY;
        PixelX = pixelX;
        PixelY = pixelY;
    }
}

public class TileImageInfo
{
    public int TileX { get; set; }
    public int TileY { get; set; }
    public GameObject Go { get; set; }

    public TileImageInfo(int tileX, int tileY, GameObject go)
    {
        TileX = tileX;
        TileY = tileY;
        Go = go;
    }
}