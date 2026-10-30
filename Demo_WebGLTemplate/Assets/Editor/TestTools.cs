using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class TestTools : EditorWindow
{
	/// <summary>
	/// 当前编辑器窗口实例
	/// </summary>
	private static TestTools instance;
	public GameObject Startobj=null;
	public GameObject Endobj = null;
	/// <summary>
	/// 显示当前窗口	
	/// </summary>
	[MenuItem("Plugins/TestTools")]
	static void Init()
	{
		instance = EditorWindow.GetWindow<TestTools>();
		instance.position = new Rect(250, 250, 500, 300);
		instance.Show();
	}

    private void OnInspectorUpdate()
    {
		Repaint();
    }

    void OnGUI()
	{
		DrawOptions();
	}

	/// <summary>
	/// 绘制插件界面配置项
	/// </summary>
	private void DrawOptions()
	{
		GUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("Start:", GUILayout.Width(85));
		Startobj = (GameObject)EditorGUI.ObjectField(new Rect(40, 0, 150, 20), Startobj, typeof(GameObject),true);
		EditorGUI.LabelField(new Rect(200, 0, 85, 20), "End: ");
		Endobj = (GameObject)EditorGUI.ObjectField(new Rect(230, 0, 150, 20), Endobj, typeof(GameObject), true);
		GUILayout.EndHorizontal();
		//输出
		if (GUI.Button(new Rect(400,0,50,20),"切换"))
		{
			Convert();
		}
	}

	void Convert()
    {
		Startobj.SetActive(false);
		Endobj.SetActive(true);
	}

	void OnSelectionChange() 
	{
		//当选择发生变化时重绘窗体
		Show();
		Repaint();
	}
}
