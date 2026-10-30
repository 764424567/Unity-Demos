using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CesiumForUnity;

public class LoadAmap : MonoBehaviour
{
    void Start()
    {
        // 创建Cesium地理参考，设置起始位置和比例尺
        var georeference = gameObject.AddComponent<CesiumForUnity.CesiumGeoreference>();
        georeference.ellipsoid = CesiumEllipsoid.WGS84;
        georeference.SetOriginLongitudeLatitudeHeight(39.916961, 116.403963, 0);// = new CesiumForUnity.GeoPoint(39.916961, 116.403963, 0); // 北京市中心
        georeference.scale = 1.0;

        // 添加Cesium地形提供者，使用百度地图服务
        var terrainProvider = gameObject.AddComponent<CesiumForUnity.CesiumTileMapServiceRasterOverlay>();
        terrainProvider.url = "http://{s}.map.bdimg.com/tile/?qt=ter&x={x}&y={y}&z={z}&styles=sl&scaler=1&udt=20210310";
        terrainProvider.specifyZoomLevels = true;
    }
}