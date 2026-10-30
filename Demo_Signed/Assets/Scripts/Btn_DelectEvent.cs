using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Btn_DelectEvent : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(DelectFile);
    }

    public void DelectFile()
    {
        StartCoroutine(DelectFileImg());
    }

    IEnumerator DelectFileImg()
    {
        yield return new WaitForSeconds(1f);
        Destroy(transform.parent.gameObject);
        File.Delete("C:\\TempImg\\" + transform.parent.name + ".png");
    }
}
