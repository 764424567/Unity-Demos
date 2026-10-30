using UnityEngine;

[ExecuteInEditMode]
public partial class CustomWire : MonoBehaviour {

    public bool setOnUpdate;//true：每次操作后实时更新线段
    
	// Update is called once per frame
	void Update ()
    {
	    if (setOnUpdate)
        {
            UpdateWire();
        }
	}

    /// <summary>
    /// 更新线段
    /// </summary>
    public void UpdateWire()
    {
        //检查是否存在空节点
        CheckNodes();

        //设置线
        SetWire();
    }
}