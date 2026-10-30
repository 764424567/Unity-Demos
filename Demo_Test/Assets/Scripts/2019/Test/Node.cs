using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node  {

    public Vector3 _position;
    public bool _isWalkable;
    public int x, y;

    public int _gCost;
    public int _hCost;
    public Node parent;
    public int fCost
    {
        get
        {
            return _gCost + _hCost;
        }

    }
    public Node(Vector3 _position, bool _isWalkable, int x, int y)
    {
        this._position = _position;
        this._isWalkable = _isWalkable;
        this.x = x;
        this.y = y;
    }

}
