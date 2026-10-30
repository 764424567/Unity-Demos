using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPath : MonoBehaviour {
    public Transform startPosition;
    public Transform endPosition;
    Grid grid;
    List<Node> openList;
    List<Node> closeList;

	// Use this for initialization
	void Start () {
        grid = GetComponent<Grid>();
      
    }
	
	// Update is called once per frame
	void Update () {
      //  FindingPath(startPosition.position,endPosition.position);

    }
    public void FindingPath(Vector3 startPosition,Vector3 endPosition)
    {
        openList = new List<Node>();
        closeList = new List<Node>();
        Node  startNode= grid.FromPosition(startPosition);
        Node endNode = grid.FromPosition(endPosition);
        openList.Add(startNode);
        while (openList.Count>0)
        {
            Node currentNode = openList[0];
            for (int i = 0; i < openList.Count; i++)
            {
                if (openList[i].fCost < currentNode.fCost ||openList[i].fCost==currentNode.fCost&&openList[i]._hCost<currentNode._hCost)
                {
                    currentNode = openList[i];
                }
            }
            openList.Remove(currentNode);
            closeList.Add(currentNode);

            if (currentNode==endNode)
            {
                
                GetPath(startNode, endNode);
               // print(grid.path.Count);
                return;
            }

            List<Node> nearby = GetNearby(currentNode);
           
            foreach (var node in nearby)
            {
               
                if (node._isWalkable==false||closeList.Contains(node))
                {
                   
                    continue;
                }
                int newCost = currentNode._gCost + Getdistance(node, currentNode);
                if (!openList.Contains(node)||node._gCost>newCost)
                {
                    node._gCost = newCost;
                    node._hCost = Getdistance(endNode, node);
                    node.parent = currentNode;
                    if (!openList.Contains(node))
                    {
                        openList.Add(node);
                    }
                }
                //if (openList.Contains(node)&&node._gCost>newCost)
                //  {
                //        node._gCost = newCost;
                //        node._hCost = Getdistance(endNode, node);
                //        node.parent = currentNode;
                //  }
                //  else  if (!openList.Contains(node))
                //   {
                //        node._gCost = newCost;
                //        node._hCost = Getdistance(endNode, node);
                //        node.parent = currentNode;
                //        openList.Add(node);
                //   }


                
            }

        }
        if (grid.path==null)
        {
            Debug.Log("没有找到终点");
        }
    }

    public void GetPath(Node start,Node end)
    {
        List<Node> path = new List<Node>();
        Node tempNode = end;
        while (tempNode!=start)
        {
            path.Add(tempNode);
            tempNode = tempNode.parent;
        }
        //if (tempNode==start)
        //{
        //    path.Add(tempNode);
        //}
        path.Reverse();
        grid.path = path;
    }
    public List<Node> GetNearby(Node currentNode)
    {
        List<Node> nearby = new List<Node>();
        for (int i = -1; i < 2; i++)
        {

            for (int j = -1; j < 2; j++)
            {
                if (i == 0 && j == -1 || i == 0 && j == 1)
                {
                    int x = currentNode.x + i;
                    int y = currentNode.y + j;

                    if (x >= 0 && x < grid.gridCountX && y >= 0 && y < grid.gridCountY)
                    {
                        nearby.Add(grid._grid[x, y]);
                    }

                }

                if (i == -1 && j == 0 || i == 1 && j == 0)
                {
                    int x = currentNode.x + i;
                    int y = currentNode.y + j;

                    if (x >= 0 && x < grid.gridCountX && y >= 0 && y < grid.gridCountY)
                    {
                        nearby.Add(grid._grid[x, y]);
                    }
                }
            }
        }
        return nearby;
    }
    public int Getdistance(Node a,Node b)
    {
        int x = Mathf.Abs(a.x-b.x);
        int y = Mathf.Abs(a.y-b.y);
        //对角线法则
        //if (x>y)
        //{
        //    return y * 14 + 10 * (x-y);
        //}
        //else
        //{
        //    return x * 14 + 10 * (y-x);
        //}
        //曼哈顿法则
        return x * 10 + y * 10;
    }


}
