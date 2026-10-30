using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PagedData : MonoBehaviour
{
    //运行时打开判断 可以知道此时瓦片距离相机的距离
    public bool ison;
    public enum RangeMode { Distance, PixelSize };
    public RangeMode _rangeMode = RangeMode.Distance;
    public string _rootFileName = "", _databasePath = "";
    public BoundingSphere _bounds;
    public ReaderOSGB _mainReader;

    public List<string> _fileNames = new List<string>();
    public List<Vector2> _ranges = new List<Vector2>();
    public List<GameObject> _pagedNodes = new List<GameObject>();
    string _fullPathPrefix = "";

    public string getFullFileName(int index)
    { return _fullPathPrefix + _fileNames[index]; }

    Camera mainCam;
    Vector3 CAmerPosition;
    Quaternion CAmeraRotion;

    Vector3 centerW;
    Matrix4x4 local2World;
    Bounds bb;
    float distance;
    float rangeValue = 0.0f;    
    int OneSetactive=0;

    void Start()
    {
        mainCam = _mainReader.CameraMin;
        _fullPathPrefix = Path.GetDirectoryName(_rootFileName) + Path.DirectorySeparatorChar;
        if (_databasePath.Length > 0) _fullPathPrefix += _databasePath + Path.DirectorySeparatorChar;
        while (_pagedNodes.Count < _fileNames.Count) _pagedNodes.Add(null);
    }
    void Update()
    {
        if (ison)
        {
            if (CAmerPosition != mainCam.transform.position || CAmeraRotion != mainCam.transform.rotation|| OneSetactive==0)
            {
               // Debug.Log(_fileNames[1]);

                CAmerPosition = mainCam.transform.position;
                CAmeraRotion = mainCam.transform.rotation;
                OneSetactive = 1;
                //Check LOD situation  每个瓦片挂载 通过判断自己离相机的位置 判断是进一步加载精细模型还是 清除缓存               
                //world2Local = this.transform.worldToLocalMatrix;//矩阵 世界坐标转局部坐标              
                local2World = this.transform.localToWorldMatrix;
                centerW = local2World.MultiplyPoint(_bounds.position);
                distance = (centerW - mainCam.transform.position).magnitude;
                if (_rangeMode == RangeMode.Distance)
                {  
                    rangeValue = distance;
                }
                else
                {
                    bb = new Bounds(centerW, new Vector3(_bounds.radius, _bounds.radius, _bounds.radius) * 2.0f);
                    if (GeometryUtility.TestPlanesAABB(_mainReader._currentFrustum, bb))    
                    {
                        if (_fileNames[1].Length == 0) return;
                        float slope = Mathf.Tan(mainCam.fieldOfView * Mathf.Deg2Rad * 0.5f);
                        float projFactor = (0.5f * mainCam.pixelHeight) / (slope * distance);
                        rangeValue = _bounds.radius * projFactor * _mainReader.distanceFactor;            
                    }
                    else
                    {
                        if (distance < 10) return;

                        rangeValue = -1;
                    }
                }
                if (_ranges[1][0] < rangeValue && rangeValue < _ranges[1][1])
                {
                    if (_pagedNodes[1] == null)
                    {
                        _mainReader.RequestLoadAndUnload(this,0);
                    }
                }
                else if (!(_pagedNodes[1] == null))
                {
                    _mainReader.RequestLoadAndUnload(this, 1);
                }
            }
        }
    }
    public bool isThisPosition()
    {
        return GeometryUtility.TestPlanesAABB(_mainReader._currentFrustum, bb);
    }
}
