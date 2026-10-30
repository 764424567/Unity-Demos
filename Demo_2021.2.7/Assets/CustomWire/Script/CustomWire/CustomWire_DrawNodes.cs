using UnityEngine;

public partial class CustomWire {

    public bool drawNodes;//true：绘制节点
    public float nodeRadius = 0.01f;//表示节点的球体的半径

    void OnDrawGizmos()
    {
        if (drawNodes)
        {
            Gizmos.color = Color.red;
            
            foreach (var node in nodes)
            {
                Vector3 pos = node.transform.position;
                Gizmos.DrawSphere(pos, nodeRadius);
            }
        }
    }
}