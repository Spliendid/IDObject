using UnityEngine;
using System.Collections;
using UnityEditor;
public class FindObjWindow : EditorWindow{
    string id = "";
    string info = "";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnGUI()
    {
        id = EditorGUILayout.TextField("请输入要查询的ID", id);
        EditorGUILayout.LabelField("查询结果", info);

        if (GUILayout.Button("确定"))
        {
            int objid;
            try
            {
                objid = int.Parse(id);
            }
            catch (System.Exception)
            {
                info = "输入格式不对请重新输入(1~999int数值)";
                return;
            }

            if (ObjID.GetObjByID(objid)==null)
            {
                info = "未查询到此ID对应的物体";
            }
            else
            {
                EditorGUIUtility.PingObject(ObjID.GetObjByID(objid));
                info = "查询成功";
            }
        }
    }
}
