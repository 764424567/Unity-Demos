using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
   
    public Node[,] _grid;
    public float nodeRadius;
    public float nodeDiameter;
    public  Vector2 gridSize;
    [SerializeField]
    internal int gridCountX;
    [SerializeField]
    internal int gridCountY;
    RaycastHit sphereHit;
    LayerMask obstacle=2<<7 ;
    public Transform player;
    public  List<Node> path;

 
    // Use this for initialization
    void Start() {
        
        nodeDiameter = nodeRadius * 2;
        gridCountX = Mathf.RoundToInt(gridSize.x / nodeDiameter);
        gridCountY = Mathf.RoundToInt(gridSize.y / nodeDiameter);
        _grid = new Node[gridCountY,gridCountX];
       

    }

	
	// Update is called once per frame
	void Update () {
        CreatGrid();
    }

    public void CreatGrid()
    {
        Vector3 startPosition = transform.position - new Vector3(gridSize.x/2,0,gridSize.y/2);
        for (int i = 0; i < gridCountY; i++)
        {
            for (int j = 0; j < gridCountY; j++)
            {
                Vector3 worldPosition = startPosition + new Vector3((2*i+1)*nodeRadius,0,(2*j+1)*nodeRadius);
                // bool walkable = !Physics.CheckSphere(worldPosition,nodeRadius,obstacle);
                Ray ray = new Ray((worldPosition-Vector3.up),Vector3.up);
              bool walkable = !Physics.SphereCast(ray,nodeRadius  ,Mathf.Infinity,obstacle);

                _grid[i, j] = new Node(worldPosition,walkable,i,j);
            }
        }
    }

    public Node FromPosition(Vector3 position)
    {
        float percentX = (position.x + gridSize.x / 2) / gridSize.x;
        float percentY = (position.z + gridSize.y / 2) / gridSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt(percentX*(gridCountX-1));
        int y = Mathf.RoundToInt(percentY * (gridCountY - 1));

        return _grid[x,y];




    }


    void OnDrawGizmos()
    {
      
        Gizmos.DrawWireCube(transform.position,new Vector3 (gridSize.x,0,gridSize.y));
        if (_grid==null)
        {
            return;
        }

        foreach (var item in _grid)
        {
            Gizmos.color = item._isWalkable ? Color.white : Color.red;
            Gizmos.DrawCube(item._position,Vector3.one*(nodeDiameter-0.025f));
        }
        Node playerNode = FromPosition(player.position);
        if (playerNode !=null&& playerNode._isWalkable)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawCube(playerNode._position, Vector3.one * (nodeDiameter - 0.025f));
        }
        //if (path != null)
        //{
        //    foreach (var node in path)
        //    {
        //        Gizmos.color = Color.blue;
        //        Gizmos.DrawCube(node._position, Vector3.one * (nodeDiameter - 0.025f));
        //    }
        //}
    }
}
