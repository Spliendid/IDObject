using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
public class SearchWindow :EditorWindow  {


	[MenuItem("Tools/IDManager/SearchID")]
	public static void GetWindow()
	{
		EditorWindow.GetWindow(typeof(SearchWindow));
	}

	private int  SerachID = 0;
	private int  PreSerachID = 0;

	private Dictionary<int,GameObject> objDic;
    Vector2 scrollPos;
	private void OnGUI() {
		SerachID = EditorGUILayout.IntField("输入要查询ID",SerachID);
		 if(PreSerachID!=SerachID)
		 {
			 if (SerachID == 0)
			 {
				 objDic = ObjID.ObjIDDic;
			 }else
			 {
				 if (ObjID.CheckID(SerachID))
				 {
					 objDic = new Dictionary<int, GameObject>{{SerachID,ObjID.ObjIDDic[SerachID]}};
				 }
			 }
		 }
		scrollPos = GUILayout.BeginScrollView(scrollPos,GUILayout.Height(200));	
		foreach (KeyValuePair<int,GameObject> item in objDic)
		{
			EditorGUILayout.BeginHorizontal();
			if (GUILayout.Button(item.Key.ToString(),GUILayout.MaxWidth(100)))
			{
				EditorGUIUtility.PingObject(item.Value);
			}
			
			EditorGUILayout.ObjectField(item.Value,typeof(GameObject),true);
			EditorGUILayout.EndHorizontal();
		}
		GUILayout.EndScrollView();	
		 PreSerachID = SerachID;
		
	}

	private void OnEnable() {
		objDic = ObjID.ObjIDDic;
	}
	
}
