using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIInteraction : MonoBehaviour
{
    public LocalDeepSeek localDeep;
    public Button BtnSeek;
    public Text TextContent;
    public InputField InputText;

    // Start is called before the first frame update
    void Start()
    {
        BtnSeek.onClick.AddListener(() =>
        {
            localDeep.PostMsg(InputText.text, (response) =>
            {
                Debug.Log("AI»Ø¸´:" + response);
                TextContent.text = response;
            });
        }        );
    }   

    // Update is called once per frame
    void Update()
    {

    }
}
