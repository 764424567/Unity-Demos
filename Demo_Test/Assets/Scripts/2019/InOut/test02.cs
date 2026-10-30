using UnityEngine;

public class test02 : MonoBehaviour
{
    public FadeInOut m_Fade;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_Fade.BackGroundControl(true);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            m_Fade.BackGroundControl(false);
        }
    }
}
