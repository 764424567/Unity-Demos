using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ReaderOSGB : MonoBehaviour
{
    GameObject Controller;
    public float distanceFactor=1;//如果发现离的很近依旧没有加载处最底层 这个值增加
    public Camera CameraMin;
    public Button m_Button;
    public Text textName;
    public Text text;

    const int OSG_HEADER_L = 0x6C910EA1;
    const int OSG_HEADER_H = 0x1AFB4545;

    public Material _template;
    string _fileOrPathName;
    public bool _asOsgbFolder;

    public int _sceneType = 0, _version = 0;
    public bool _useBrackets = false;
    public bool _useSchemaData = false;
    public bool _useDomains = false;

    public string _currentFileName;
    public Plane[] _currentFrustum;
    public Texture2D _preloadedTexture = null;
    public Dictionary<uint, Object> _sharedObjects = new Dictionary<uint, Object>();
    public Dictionary<uint, Texture2D> _sharedTextures = new Dictionary<uint, Texture2D>();

    List<string> _loadDataTiles = new List<string>();
    List<string> _unloadDataTiles = new List<string>();
    private Queue _loadDataTile = new Queue();
    private Queue _unloadDataTile = new Queue();
    private IEnumerator _LoadWork = null;
    private IEnumerator _unloadWork = null;
    public Vector3 CameraPosition;

    void Start()
    {
        Controller = GameObject.Find("conller");
        m_Button.onClick.AddListener(onclickbutton);    
    }
    public void EnqueueWork(IEnumerator work,int a)
    {
        if (a == 0)
        {
            _loadDataTile.Enqueue(work);
        }
        else
        {
            _unloadDataTile.Enqueue(work);
        }
    }
    private void DoWork(IEnumerator Work, Queue WorkQueue,int a)
    {  
        if (Work == null)
        {
            Work = (IEnumerator)WorkQueue.Dequeue();
            if (a == 0)
            {
                _loadDataTiles.RemoveAt(0);
            }
            else
            {
                _unloadDataTiles.RemoveAt(0);
            }
        }
        if (!Work.MoveNext())
        {
            Work = null;
        }
        else if (Work.Current is IEnumerator)
        {
            Work = (Work.Current as IEnumerator);
        }
    }
    public void RequestLoadAndUnload(PagedData data,int a)
    {
        if (a==0)
        {
            if (_loadDataTiles.Contains(data.name)) 
                return;

            EnqueueWork(PagingWork(data,true), a);
            _loadDataTiles.Add(data.name);
        }
        else
        {
            if (_unloadDataTiles.Contains(data.name))
                return;

            EnqueueWork(PagingWork(data,false), a);
            _unloadDataTiles.Add(data.name);
        }
    }
    IEnumerator PagingWork(PagedData data,bool isBool)
    {
        LoadOrUnloadDatas(data, 1, isBool);
        yield return null;
    }
    void LoadOrUnloadDatas(PagedData data, int index, bool toLoad)
    {
        if (toLoad)
        {
            if (data._pagedNodes[0])
            {
                string fileName = data.getFullFileName(index);
                GameObject fineNode = LoadSceneFromFile(fileName);
                if (fineNode != null)
                {   
                    fineNode.transform.SetParent(data.transform, false);
                    data._pagedNodes[index] = fineNode;
                    data._pagedNodes[0].SetActive(false);  // FIXME: assume only 1 rough level
                }
                else
                    Debug.LogWarning("Unable to read OSGB data from " + fileName);
            }
        }
        else
        {
            if (data._pagedNodes[0])
            {
                // if (data.isThisPosition()) return; // 取消注释的话   视野内的不随远近而卸载 保持最新加载
                if (data.name.Split('_').Length != data.name.Split('+').Length)
                {
                    data._pagedNodes[0].SetActive(true);
                }
                Destroy(data._pagedNodes[index]);
                data._pagedNodes[index] = null;              
            }        
        }
    }
    public GameObject LoadSceneData(string fileName, BinaryReader reader)
    {
            // Load header data
            int magicNumL = reader.ReadInt32();
            int magicNumH = reader.ReadInt32();
            if (magicNumL != OSG_HEADER_L || magicNumH != OSG_HEADER_H)
            {
                Debug.LogWarning("Unmatched magic number");
                return null;
            }
            _sceneType = reader.ReadInt32();
            _version = reader.ReadInt32();
            int attributes = reader.ReadInt32();
            text.text = " version " + _version + ", " + attributes.ToString("X");
            if (_version == 80)
            {
                return null;
            }
            _useBrackets = (attributes & 0x4) != 0;
            _useSchemaData = (attributes & 0x2) != 0;
            _useDomains = (attributes & 0x1) != 0;
            // TODO: handle attributes
            string compressor = ObjectBase.ReadString(reader);
            if (compressor != "0")
            {
                Debug.LogWarning("Decompressor " + compressor + " not implemented");
                return null;
            }
            // Load root object
            GameObject scene = new GameObject(Path.GetFileNameWithoutExtension(fileName));
            if (!ObjectBase.LoadObject(scene, reader, this))
            {
                Debug.LogWarning("Failed to load scene");
                return null;
            }
            _preloadedTexture = null;
            _sharedObjects.Clear();
            _sharedTextures.Clear();
            return scene;  
    }
    //文件加载场景
    public GameObject LoadSceneFromFile(string fileName)
    {
        _currentFileName = fileName;
        if (!File.Exists(fileName))
        {
            Debug.LogWarning("Unable to find file " + fileName);
            return null;
        }

        FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
        if (!stream.CanRead)
        {
            Debug.LogWarning("Unable to read binary stream from " + fileName);
            return null;
        }
        GameObject gameScene = LoadSceneData(fileName, new BinaryReader(stream));
        stream.Close(); return gameScene;
    }
    public void onclickbutton()
    {
        _fileOrPathName = textName.text;
        string a = _fileOrPathName + Path.DirectorySeparatorChar +"Data" + Path.DirectorySeparatorChar;
        GameObject scencepatent = new GameObject(Path.GetFileName(_fileOrPathName));
        scencepatent.transform.SetParent(this.transform);
        scencepatent.transform.localRotation = new Quaternion(0, 0, 0, 0);
        scencepatent.transform.localPosition = Controller.GetComponent<read>().readKml(_fileOrPathName);
        InsideFuntion(scencepatent, a);    
    }
    private void InsideFuntion(GameObject gamobj, string a)
    {
        if (_template == null)
            _template = new Material(Shader.Find("Standard"));//如果使用 URP 或 HDRP时记得改 不然会变成紫色
        if (_asOsgbFolder)
        {
            foreach (string folderName in Directory.GetDirectories(a))
            {
                string rootFile = folderName + Path.DirectorySeparatorChar
                                + Path.GetFileName(folderName) + ".osgb";
                GameObject scene = LoadSceneFromFile(rootFile);
                if (scene != null)
                {
                    scene.transform.SetParent(gamobj.transform, false);
                }
                else
                {
                    Debug.LogWarning("Unable to read OSGB data from " + rootFile);
                }
            }
        }
        else
        {
            GameObject scene = LoadSceneFromFile(a);
            if (scene != null)
                scene.transform.SetParent(gamobj.transform, false);
            else
                Debug.LogWarning("Unable to read OSGB data from " + a);
        }
        CameraMin.transform.position = Controller.GetComponent<Position_pAnds>().Test(gamobj)+new Vector3(0,1,0);
        Model.Instance.Origin = Controller.GetComponent<Position_pAnds>().Test(gamobj);
        Model.Instance.zoomOrigin = Model.Instance.Origin;
    }
    void Update()
    {
        if (CameraPosition != CameraMin.transform.position)
        {
            //相机视口范围
            _currentFrustum = GeometryUtility.CalculateFrustumPlanes(CameraMin);
            CameraPosition = CameraMin.transform.position;
        }
        //执行工作
        if (_loadDataTile.Count != 0)
        {
            DoWork(_LoadWork, _loadDataTile,0);
        }
        if (_unloadDataTile.Count != 0)
        {
            DoWork(_unloadWork, _unloadDataTile,1);
        }
    }




    
  
  

}
