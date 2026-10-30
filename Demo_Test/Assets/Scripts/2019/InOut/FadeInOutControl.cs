using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;//注意添加RawImage命名空间

public class FadeInOutControl : MonoBehaviour

{

    FadeInOut fadeInOut;

    public GameObject rawImage;

    void Start()

    {

        rawImage.SetActive(true);

        fadeInOut = rawImage.GetComponent<FadeInOut>();

    }

    public void BackGroundControl(bool b)

    {

        if (b == true)

            fadeInOut.isBlack = true;

        else

            fadeInOut.isBlack = false;

    }

}