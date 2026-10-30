using RTEditor;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class t1 : MonoBehaviour
{
    [DllImport("user32.dll", EntryPoint = "keybd_event")]
    public static extern void Keybd_event(byte bvk, byte bScan, int dwFlags, int dwExtraInfo);
    Button b1;
    Button b2;
    Button b3;
    EditorUndoRedoSystem ss;
    EditorGizmoSystem editor;
    public GizmoType ActiveGizmoType;
    // Use this for initialization
    void Start()
    {
        b1 = GameObject.Find("Image_3").GetComponent<Button>();
        b2 = GameObject.Find("Image_4").GetComponent<Button>();
        b3 = GameObject.Find("Image_5").GetComponent<Button>();
        b1.onClick.AddListener(delegate () { ButtonOnClick(); });
        b2.onClick.AddListener(delegate () { ButtonOnClick2(); });
        b3.onClick.AddListener(delegate () { ButtonOnClick3(); });
        ss = GameObject.Find("(Singleton)RTEditor.EditorUndoRedoSystem").GetComponent<EditorUndoRedoSystem>();
        editor = GameObject.Find("(Singleton)RTEditor.EditorGizmoSystem").GetComponent<EditorGizmoSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonOnClick()
    {
        //Input.GetKeyDown(KeyCode.E);

            //Keybd_event(69, 0, 0, 0);
        ss.Undo();

    }
    public void ButtonOnClick2()
    {
        //Input.GetKeyDown(KeyCode.E);
            //Keybd_event(82, 0, 0, 0);
        ss.Redo();
    }

    public void ButtonOnClick3()
    {
        editor.ChangeActiveGizmo(GizmoType.Rotation);
    }
}
