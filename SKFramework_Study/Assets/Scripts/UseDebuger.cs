using UnityEngine;

public class UseDebuger : MonoBehaviour
{
    public Color m_Color;
    public bool m_isOn;
    public float m_value;
    public string m_info;
    public Vector3 m_pos;

    void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log(m_Color);
            Debug.Log(m_isOn);
            Debug.Log(m_value);
            Debug.Log(m_info);
            Debug.Log(m_pos);
        }
    }
}
