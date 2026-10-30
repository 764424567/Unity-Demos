using UnityEngine;
using UnityEngine.UI;

public class ClickEvent : MonoBehaviour
{
    public Button add_options_t;
    public Button add_options;
    public Transform canvasParent;

    void Start()
    {
        add_options_t.onClick.AddListener(() =>
        {
            if (PublicData.parent == null)
            {
                PublicData.parent = Instantiate(Resources.Load<Transform>("Options_triangle"));
                PublicData.parent.transform.SetParent(canvasParent, false);
                PublicData.currentPosition = new Vector2(PublicData.parent.position.x, PublicData.parent.position.y);
            }
            else
            {
                Transform option = Instantiate(Resources.Load<Transform>("Options_triangle"));
                option.transform.SetParent(PublicData.parent, false);
                option.transform.position = new Vector3(PublicData.currentPosition.x + 30, PublicData.currentPosition.y - 32, 0);
                PublicData.parent.GetComponent<Options_Triangle>().triangle.transform.eulerAngles = new Vector3(0, 0, -90);
                PublicData.parent.GetComponent<Options_Triangle>().children.Add(option);
                PublicData.parent = option;
                PublicData.currentPosition = new Vector2(PublicData.parent.position.x, PublicData.parent.position.y);
            }

        });
        add_options.onClick.AddListener(() =>
        {
            if (PublicData.parent == null)
            {
                return;
            }
            PublicData.parent.GetComponent<Options_Triangle>().triangle.transform.eulerAngles = new Vector3(0, 0, -90);
            Transform content = Instantiate(Resources.Load<Transform>("Options"));
            content.transform.SetParent(PublicData.parent, false);
            content.transform.position = new Vector3(PublicData.currentPosition.x + 16, PublicData.currentPosition.y - 32, 0);
            PublicData.parent.GetComponent<Options_Triangle>().children.Add(content);
            PublicData.currentPosition = new Vector2(content.position.x - 16, content.position.y);

        });
    }
}
