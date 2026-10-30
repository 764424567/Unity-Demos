using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {
    //管道变量
    RaycastHit hit_point;
    Queue<RaycastHit> start_end;
    Vector3 startPoint;
    Vector3 endPoint;
    List<string> allPoint;
    public Material mate;
    //A star路径
    FindPath pathNode;
    Grid grid;
    //储存信息变量
    ArrayList data;
    List<ArrayList> dataParent;
    //拖动变量
    bool m_isDrag;
    Vector3 m_offset;
    Vector3 m_STW;
    Vector3 v;
    RaycastHit hit_parent;
    Transform[] m_trans;
    // Use this for initialization
    void Start () {
        start_end = new Queue<RaycastHit>();
        allPoint = new List<string>();
       
        dataParent = new List<ArrayList>(); 
        grid = GetComponent<Grid>();
        pathNode = GetComponent<FindPath>();
	}
	
	// Update is called once per frame
	void Update () {
        GetStartEnd();
        DrawTest();
        Move();
        ParentMove_line();
    }

    public void GetStartEnd()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out hit_point,Mathf.Infinity ))
            {
                if (hit_point.transform.tag=="Port")
                {
                    if (start_end.Count<2)
                    {
                        start_end.Enqueue(hit_point);
                       
                    }
                    print(start_end.Count);
                }
            }
        }

    }

    public void DrawTest()
    {
        if (start_end.Count!=2)
        {
            return;
        }
        data = new ArrayList();
        RaycastHit temp01 = start_end.Dequeue();
        startPoint = temp01.transform.position;
        data.Add(temp01.transform.name);
        data.Add(startPoint);
        RaycastHit temp02 = start_end.Dequeue();
        endPoint = temp02.transform.position;
        data.Add(temp02.transform.name);
        data.Add(endPoint);

        if (allPoint.Contains(temp01.transform.name)||allPoint.Contains(temp02.transform.name))
        {
            return;
        }
        pathNode.FindingPath(startPoint,endPoint);
            if (grid.path!=null)
            {
                GameObject obj = new GameObject();
                obj.name = "LineParent";
                for (int i = 0; i < grid.path.Count; i++)
                {
                    grid.path[i]._position = new Vector3(grid.path[i]._position.x,0.5f, grid.path[i]._position.z);
                }
                for (int i = 0; i < grid.path.Count-1; i++)
                {
                    
                   GameObject objs=  DrawMeshLine.Draw(grid.path[i]._position, grid.path[i+1]._position, mate, 0.1f);
                    objs.transform.parent = obj.transform;
                }
               data.Add(obj);
            }

        dataParent.Add(data);
        allPoint.Add(temp01.transform.name);
        allPoint.Add(temp02.transform.name);
    }

    public void ParentMove_line()
    {
       
        if (m_isDrag&&dataParent.Count>0)
        {

            for (int i = 1; i < m_trans.Length; i++)
            {
                int tempIndex = -1;
                ArrayList temp = new ArrayList();

                for (int j = 0; j < dataParent.Count; j++)
                {

                    if (dataParent[j].Contains(m_trans[i].name))
                    {
                        tempIndex = j;
                        int index = -1;
                        
                        for (int k = 0; k < dataParent[j].Count; k++)
                        {
                            if ((dataParent[j])[k]is string)
                            {
                                string name = (string)(dataParent[j])[k];
                                temp.Add(name);
                                if (m_trans[i].name==name)
                                {
                                    index = k;
                                }
                            }
                            else if ((dataParent[j])[k] is Vector3)
                            {
                                Vector3 position = (Vector3)(dataParent[j])[k];
                                
                                if (index==0)
                                {
                                    
                                    temp.Add(m_trans[i].position);
                                    index = -1;
                                }
                                else if (index==2)
                                {
                                    
                                    temp.Add(m_trans[i].position);
                                    index = -1;
                                }
                                else if(index==-1)
                                {
                                    temp.Add(position);
                                }
                            }
                            else if ((dataParent[j])[k] is GameObject)
                            {
                                GameObject obj = (GameObject)(dataParent[j])[k];
                                Destroy(obj);
                        
                            }
                        }
                    }
                }


                if (tempIndex != -1 && temp.Count>0)
                {

                    dataParent.RemoveAt(tempIndex);
                    dataParent.Add(temp);
                    pathNode.FindingPath((Vector3)temp[1], (Vector3)temp[3]);
                    if (grid.path != null)
                    {
                        //print(grid.path.Count + "Gridpath");
                        GameObject tempObj = new GameObject();
                        tempObj.name = "LineParentNew";
                        for (int s = 0; s < grid.path.Count; s++)
                        {
                            grid.path[s]._position = new Vector3(grid.path[s]._position.x, 0.5f, grid.path[s]._position.z);
                        }
                        for (int h = 0; h < grid.path.Count - 1; h++)
                        {

                            GameObject objs = DrawMeshLine.Draw(grid.path[h]._position, grid.path[h + 1]._position, mate, 0.1f);
                            objs.transform.parent = tempObj.transform;
                        }
                        temp.Add(tempObj);
                    }

                }

            }

        }


    }
    public void Move()
    {
        if (m_isDrag)
        {

            m_STW = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, v.z));
            hit_parent.transform.position = m_STW + m_offset;

        }

        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit_parent, Mathf.Infinity))
            {
                if (hit_parent.transform.tag == "jiqi")
                {

                    v = Camera.main.WorldToScreenPoint(hit_parent.transform.position);
                    m_STW = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, v.z));
                    m_offset = hit_parent.transform.position - m_STW;
                    m_trans = hit_parent.transform.GetComponentsInChildren<Transform>();
                    m_isDrag = true;
                }
            }


        }
        if (Input.GetMouseButtonUp(0))
        {
            m_isDrag = false;
        }
    }
}
