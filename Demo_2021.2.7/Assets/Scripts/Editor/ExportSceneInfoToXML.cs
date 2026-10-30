using System.IO;
using System.Xml;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ExportSceneInfoToXML : Editor
{

    [MenuItem("Tool/ExportSceneInfoToXML")]
    static void ExportXML()
    {
        string filepath = Application.streamingAssetsPath + @"/sceneInfoXML.xml";
        if (File.Exists(filepath))
        {
            File.Delete(filepath);
        }
        XmlDocument xmlDoc = new XmlDocument();
        XmlElement root = xmlDoc.CreateElement("scenes");
        //遍历所有的游戏场景
        foreach (UnityEditor.EditorBuildSettingsScene s in UnityEditor.EditorBuildSettings.scenes)
        {
            //当关卡启用
            if (s.enabled)
            {
                //得到当前场景的名称
                string name = s.path;
                //打开这个场景
                EditorSceneManager.OpenScene(name);
                XmlElement scene = xmlDoc.CreateElement("scene");
                scene.SetAttribute("name", name);
                foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
                {
                    //因为场景内物体都制作为prefab，所以只需遍历父物体而无需遍历子物体(prefab已包含子物体的信息)
                    if (obj.transform.parent == null)
                    {
                        XmlElement gameObject = xmlDoc.CreateElement("gameObject");
                        gameObject.SetAttribute("name", obj.name);
                        gameObject.SetAttribute("asset", obj.name + ".prefab");
                        XmlElement transform = xmlDoc.CreateElement("transform");

                        XmlElement position = xmlDoc.CreateElement("position");
                        XmlElement position_x = xmlDoc.CreateElement("x");
                        position_x.InnerText = obj.transform.position.x + "";
                        XmlElement position_y = xmlDoc.CreateElement("y");
                        position_y.InnerText = obj.transform.position.y + "";
                        XmlElement position_z = xmlDoc.CreateElement("z");
                        position_z.InnerText = obj.transform.position.z + "";
                        position.AppendChild(position_x);
                        position.AppendChild(position_y);
                        position.AppendChild(position_z);

                        XmlElement rotation = xmlDoc.CreateElement("rotation");
                        XmlElement rotation_x = xmlDoc.CreateElement("x");
                        rotation_x.InnerText = obj.transform.rotation.eulerAngles.x + "";
                        XmlElement rotation_y = xmlDoc.CreateElement("y");
                        rotation_y.InnerText = obj.transform.rotation.eulerAngles.y + "";
                        XmlElement rotation_z = xmlDoc.CreateElement("z");
                        rotation_z.InnerText = obj.transform.rotation.eulerAngles.z + "";
                        rotation.AppendChild(rotation_x);
                        rotation.AppendChild(rotation_y);
                        rotation.AppendChild(rotation_z);

                        XmlElement scale = xmlDoc.CreateElement("scale");
                        XmlElement scale_x = xmlDoc.CreateElement("x");
                        scale_x.InnerText = obj.transform.localScale.x + "";
                        XmlElement scale_y = xmlDoc.CreateElement("y");
                        scale_y.InnerText = obj.transform.localScale.y + "";
                        XmlElement scale_z = xmlDoc.CreateElement("z");
                        scale_z.InnerText = obj.transform.localScale.z + "";
                        scale.AppendChild(scale_x);
                        scale.AppendChild(scale_y);
                        scale.AppendChild(scale_z);

                        transform.AppendChild(position);
                        transform.AppendChild(rotation);
                        transform.AppendChild(scale);

                        gameObject.AppendChild(transform);
                        scene.AppendChild(gameObject);
                        root.AppendChild(scene);
                        xmlDoc.AppendChild(root);
                        xmlDoc.Save(filepath);

                    }
                }
            }
        }
        //刷新Project视图， 不然需要手动刷新哦
        AssetDatabase.Refresh();
        Debug.Log("保存完成：" + filepath);
    }



}

