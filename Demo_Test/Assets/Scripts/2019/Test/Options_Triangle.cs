using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options_Triangle : MonoBehaviour
{
    public Button triangle;
    public Image content;
    public List<Transform> children = new List<Transform>();
    void Start()
    {
        triangle.onClick.AddListener(() =>
        {
            if (triangle.transform.eulerAngles.z == 270)
            {
                triangle.transform.eulerAngles = Vector3.zero;
                for (int i = 0; i < children.Count; i++)
                {
                    children[i].gameObject.SetActive(false);
                }
            }
            else
            {
                triangle.transform.eulerAngles = new Vector3(0, 0, -90);
                for (int i = 0; i < children.Count; i++)
                {
                    children[i].gameObject.SetActive(true);
                }
            }
        });

    }
}
