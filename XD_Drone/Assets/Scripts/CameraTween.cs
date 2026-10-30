using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraTween : MonoBehaviour
{
    List<GameObject> movePos;

    //show map param(check distance)
    GameObject checkObj;
    //147;153;421;2542;7356
    int[] checkRange = new int[3] { 150, 400, 2500 };
    GameObject mapObj;

    // Start is called before the first frame update
    void Start()
    {
        movePos = new List<GameObject>();
        checkObj = GameObject.Find("tile_bg");
        mapObj = checkObj.transform.Find("µØÐÎ").gameObject;
        var moveParent = GameObject.Find("CamerEnterPos").transform;
        for (int i = 0; i < moveParent.childCount; i++)
        {
            movePos.Add(moveParent.GetChild(i).gameObject);
        }

        Lod01();
    }

    public void AutoPlay()
    {
        float tweenTime = 5.0f;
        var obj = Camera.main.gameObject;
        obj.transform.position = movePos[0].transform.position;
        obj.transform.rotation = movePos[0].transform.rotation;
        Transform[] movePath = new Transform[movePos.Count];
        for (int i = 0; i < movePos.Count; i++)
        {
            movePath[i] = movePos[i].transform;
            //var distance = Vector3.Distance(movePath[i].transform.position, mapObj.transform.position);
            //Debug.LogFormat("step:{0};Distance:{1}", i, distance);
        }
        var table_move = new Hashtable();
        table_move.Add("onstart", "OnMoveStart");
        table_move.Add("onupdate", "OnMoveUpdate");
        table_move.Add("oncomplete", "OnMoveComplete");
        table_move.Add("onstarttarget", gameObject);
        table_move.Add("onupdatetarget", gameObject);
        table_move.Add("oncompletetarget", gameObject);
        table_move.Add("easetype", "linear");
        table_move.Add("time", tweenTime * movePath.Length);
        table_move.Add("path", movePath);
        iTween.MoveTo(obj, table_move);
    }
    public void Lod01()
    {
        var obj = Camera.main.gameObject;
        obj.transform.position = movePos[0].transform.position;
        obj.transform.rotation = movePos[0].transform.rotation;
        OnMoveUpdate();
    }
    public void Lod02()
    {
        var obj = Camera.main.gameObject;
        obj.transform.position = movePos[1].transform.position;
        obj.transform.rotation = movePos[1].transform.rotation;
        OnMoveUpdate();
    }
    public void Lod03()
    {
        var obj = Camera.main.gameObject;
        obj.transform.position = movePos[2].transform.position;
        obj.transform.rotation = movePos[2].transform.rotation;
        OnMoveUpdate();
    }
    public void Lod04()
    {
        var obj = Camera.main.gameObject;
        obj.transform.position = movePos[3].transform.position;
        obj.transform.rotation = movePos[3].transform.rotation;
        OnMoveUpdate();
    }
    public void Lod05()
    {
        var obj = Camera.main.gameObject;
        obj.transform.position = movePos[4].transform.position;
        obj.transform.rotation = movePos[4].transform.rotation;
        OnMoveUpdate();
    }

    void OnMoveStart()
    {
        mapObj.SetActive(false);
        for (int i = 0; i < checkObj.transform.childCount; i++)
        {
            checkObj.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void OnMoveUpdate()
    {
        var distance = Vector3.Distance(Camera.main.transform.position, mapObj.transform.position);
        var show = distance < checkRange[0];
        if (show && !checkObj.transform.GetChild(0).gameObject.activeSelf)
        {
            var table_rot = new Hashtable();
            table_rot.Add("easetype", "linear");
            table_rot.Add("rotation", movePos.Last().transform);
            table_rot.Add("time", 5.00f);
            iTween.RotateTo(Camera.main.gameObject, table_rot);
        }
        checkObj.transform.GetChild(0).gameObject.SetActive(show);
        show = distance < checkRange[1] && distance > checkRange[0];
        checkObj.transform.GetChild(1).gameObject.SetActive(show);
        show = distance < checkRange[2] && distance > checkRange[1];
        checkObj.transform.GetChild(2).gameObject.SetActive(show);
        show = distance > checkRange[2];
        checkObj.transform.GetChild(3).gameObject.SetActive(show);
    }

    private void OnMoveComplete()
    {
        mapObj.SetActive(true);
        //Camera.main.gameObject.GetComponent<IOCcam>().enabled = true;
    }
}
