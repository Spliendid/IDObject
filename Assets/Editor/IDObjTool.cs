using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
public class IDObjTool {
#if UNITY_EDITOR
    #region TEST
    //清空字典
    [MenuItem("Tools/IDManager/CleanDic")]
    public static void ClenDic()
    {
        ObjID.ObjIDDic = new Dictionary<int, GameObject>();
    }
    //打印出字典
    [MenuItem("Tools/IDManager/LogDic")]
    public static void LogDic()
    {
        string info = "";
        var enumerator = ObjID.ObjIDDic.GetEnumerator();
        while (enumerator.MoveNext())
        {
            try
            {
                info += enumerator.Current.Key.ToString() + ":\t" + enumerator.Current.Value.name + "\n";
            }
            catch (System.Exception)
            {
                Debug.Log("<color=red>可能重新加载了场景，请点击Tools/IDManager/CleanDic清空字典，并重新运行</color>");
            }
        }
        Debug.Log(info == "" ? "字典为空" : info);
    }
    
    //检查DIC,将value为Null 的 数据清空
    [MenuItem("Tools/IDManager/CheckDic")]
    public static void Check()
    {
        var enumerator = ObjID.ObjIDDic.GetEnumerator();
        while (enumerator.MoveNext())
        {
            if (enumerator.Current.Value == null)
            {
                ObjID.ObjIDDic.Remove(enumerator.Current.Key);
            }
        }
    }

  [MenuItem("Tools/IDManager/FindObj")]
    public static void FindObj()
    {
        EditorWindow.GetWindow(typeof(FindObjWindow));
    }

    #endregion
#endif
}
