using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor(typeof(ObjID))]
public class IDObjEditor : Editor
{
    //主要物体
    ObjID _Objid;
    private SerializedObject _SerObj;
    private SerializedProperty ID;

    private GUIContent content = GUIContent.none;

    private void Awake()
    {
      
        Debug.Log("Awake");
    }
    private void OnEnable()
    {
        _SerObj = new SerializedObject(target);
        ID = _SerObj.FindProperty("ID");
        _Objid = target as ObjID;
        //_Objid.InitID();
        //_Objid.AddThis();
        Debug.Log("OnEnable");
    }

    private void OnSceneGUI()
    {
       
    }

    private void OnDestroy()
    {
     
        Debug.Log("OnDestroy");
    }

    //重写Inspector检视面板
    public override void OnInspectorGUI()
    {
       _SerObj.Update();
        EditorGUILayout.PropertyField(ID);
        _SerObj.ApplyModifiedProperties();
       // EditorUtility.SetDirty(target);
        if (GUI.changed)
        {
            _Objid.UpdateThis();
        }
    }
}
