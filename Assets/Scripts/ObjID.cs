/* 
 *  Name  : Arthur
 *  Title :物体信息
 *  Function:物体信息数据
 *  Time    : 2018.4
 *  Version : 1.0
 *
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
//物体唯一ID
[Serializable,ExecuteInEditMode,DisallowMultipleComponent]
public class ObjID : MonoBehaviour
{

    #region 静态方法

    #region 增、删、改、查

    #region 增

    //添加到字典
    public static bool AddDic(int _ID, GameObject obj)
    {
        if (_ID == 0)
        {
            return false;
        }
        if (ObjIDDic.ContainsKey(_ID))
        {
            if (ObjIDDic[_ID]!=obj)
            {
                try
                {
                    Debug.Log(obj.name +"<color=greed>"+_ID.ToString()+"</color>"+ "<color=red>ID已存在</color>"+GetObjByID(_ID).name);

                }
                catch (Exception)
                {
                    Debug.Log("<color=red>可能重新加载了场景，请点击Tools/IDManager/CleanDic清空字典，并重新运行</color>");
                }
            }
            return false;
        }
        else
        {
            ObjIDDic.Add(_ID, obj);
            return true;
        }
    }

    #endregion

    #region 删
    //根据ID删字典
    public static void DelObjIDDic(int _id)
    {
        ObjIDDic.Remove(_id);
    }
    //根据物体删字典
    public static void DelObjIDDic(GameObject go)
    {
        int _id = GetIDByObj(go);

        if (_id == 0)
        {
            return;
        }

        ObjIDDic.Remove(_id);
    }
    #endregion

    #region 改

    public bool  UpdateObj(int id,GameObject obj)
    {
        if (ObjIDDic.ContainsKey(id))
        {
            if (ObjIDDic[id]!=obj)
            {
                Debug.Log(obj.name + "<color=greed>" + id.ToString() + "</color>" + "<color=red>ID已存在</color>" + GetObjByID(id).name);
            }
            return  false;
            
        }
        if (ObjIDDic.ContainsValue(obj))//如果这个obj，先删除
        {
            DelObjIDDic(obj);
        }

        AddDic(id,obj);
        return true;
    }

    #endregion

    #region 查
      

    //根据ID找到Object
    public static GameObject GetObjByID(int _id)
    {
        if (_id == 0)
        {
            return null;
        }
        if (ObjIDDic.ContainsKey(_id))
        {
            return ObjIDDic[_id];
        }
        return null;
    }
    
    //根据物体获取ID(Linq方式)
    /*
    public static int GetIDByObj(GameObject go)
    {
        if (ObjIDDic.ContainsValue(go))
        {
            int id = (from d in ObjIDDic where d.Value == go select d.Key).ToList()[0];//USE Linq
         
        }
        return 0;
    }
    */

    //使用迭代器
    public static int GetIDByObj(GameObject go)
    {

        if (ObjIDDic.ContainsValue(go))
        {
            var enumerator = ObjIDDic.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.Value == go)
                {
                    return enumerator.Current.Key;
                }
            }
        }
        return 0;
    }
    //检查ID是否被占用
    public static bool CheckID(int _id,GameObject go)
    {
        return ObjIDDic.ContainsKey(_id);
    }

    public static bool Check_IDValue(int _id,GameObject go)
    {
        if (ObjIDDic.ContainsKey(_id))
        {
            return ObjIDDic[_id] == go;
        }
        return false;
    }
    #endregion

    #endregion

    /// <summary>
    /// 存储物体的字典
    /// 1.一个ID对应唯一的物体，ID肯定不能重复
    /// 2.一个物体只能有一个ID，不能重复
    /// 3.0key值不允许存入
    /// 4.如果value出现空值，场景可能重新加载，删除dic，重新赋值
    /// </summary>
    [NonSerialized]
    public static Dictionary<int, GameObject> ObjIDDic = new Dictionary<int, GameObject>();



    #endregion

    public bool testBool;
    public float testFloat;
    public int ID;
    [ContextMenu("自动生成ID")]
    public void CreatID()
    {
        ID = this.gameObject.GetInstanceID();
    }

    [ContextMenu("随机一个ID")]
    public void RandomID()
    {
        while (UpdateObj(ID, this.gameObject)==false)
        {
            ID = UnityEngine.Random.Range(0, 9999);
        }
    }

    #region 外部
    public void InitID()
    {
        if (!Check_IDValue(ID, this.gameObject))
        {
            while (AddDic(ID, this.gameObject) == false)
            {
                ID = UnityEngine.Random.Range(0, 9999);
            }
        }
    }

    public void UpdateThis()
    {
        UpdateObj(ID, this.gameObject);
    }

    public void DelThis()
    {
        if ( null==this)
        {
            DelObjIDDic(ID);
        }
    }
    [ContextMenu("添加到字典")]
    public void AddThis()
    {
        AddDic(ID, this.gameObject);
    }

    #endregion

    #region Mono

    public void Awake()
    {
        InitID();
        Debug.Log("_Start");
      
    }

    public void Update()
    {
    }
    public void OnDestroy()
    {
        Debug.Log("_Destroy");
        DelThis();
    }


    #endregion

    #region TEST

    private void EditorTest()
    {
        Debug.Log(testBool);
        Debug.Log(testBool);
    }

    #endregion
}
