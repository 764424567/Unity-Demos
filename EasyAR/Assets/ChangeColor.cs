using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material blue;
    public Material red;
    private bool isClick = false;
    void OnMouseDown()
    {
        if (!isClick)
        {
            gameObject.GetComponent<MeshRenderer>().material = blue;
            isClick = true;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = red;
            isClick = false;
        }
    }
}