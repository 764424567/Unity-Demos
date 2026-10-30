using UnityEngine;

public class TestGetAnget : MonoBehaviour
{
    public Transform m_target1;
    public Transform m_target2;
    public Transform target;
    public Transform target1;

    void Update()
    {
        GetAnglev3();
        GetAngle(m_target1, m_target2);
    }

    void GetAnglev3()
    {
        Vector3 relative = target1.InverseTransformPoint(target.position);
        float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
        target1.Rotate(0, angle, 0);
    }

    void GetAngle(Transform target1,Transform target2)
    {
        Vector3 dir = target1.position - target2.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        m_target1.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
