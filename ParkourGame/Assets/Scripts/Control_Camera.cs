using UnityEngine;

public class Control_Camera : MonoBehaviour
{
	//间隔距离
	public float m_DistanceAway = 5f;
	//间隔高度
	public float m_DistanceHeight = 10f;
	//平滑值
	public float smooth = 2f;
	//目标点
	private Vector3 m_TargetPosition;
	//参照点
	Transform m_Follow;

	void Start()
	{
		//获取到玩家的位置
		m_Follow = GameObject.Find("Player").transform;
		//设置一个初始角度
		transform.rotation = Quaternion.Euler(new Vector3(28, 90, 0));
	}

	void LateUpdate()
	{
		//根据主角位置计算一个目标点
		m_TargetPosition = m_Follow.position + Vector3.up * m_DistanceHeight - m_Follow.forward * m_DistanceAway;
		//将摄像机平滑的移动到目标点
		transform.position = Vector3.Lerp(transform.position, m_TargetPosition, Time.deltaTime * smooth);
	}
}