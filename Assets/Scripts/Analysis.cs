using UnityEngine;
using System.Collections;
using LitJson;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

/// <summary>
/// 解析数据
/// </summary>
public class Analysis : MonoBehaviour {


    void Awake () {
        // 用户数据解析
        UserAnalysis();
        // 物品数据解析
        GoodsAnalysis();
        //装备数据解析
        EquipAnalysis();

        TaskAnalysis();

      
    }

    /// <summary>
    /// 任务数据
    /// </summary>
    private void TaskAnalysis()
    {

        TextAsset myTextAsset = Resources.Load("TXT/MyTask") as TextAsset;
        if (!myTextAsset)
        {
            return;
        }
        DataManager.myTaskDic= JsonConvert.DeserializeObject<Dictionary<string, Task>>(myTextAsset.text);
    }

    /// <summary>
    /// 用户数据解析
    /// </summary>
    void UserAnalysis()
    {
        TextAsset u = Resources.Load("Setting/UserJson") as TextAsset;
        if (!u)
        {
            return;
        }
        Save.UserList = JsonConvert.DeserializeObject<List<UserModel>>(u.text);
        //print(u.text);
    }

    /// <summary>
    /// 物品数据解析
    /// </summary>
    void GoodsAnalysis()
    {
        TextAsset g = Resources.Load("Setting/GoodsList") as TextAsset;
        if (!g)
        {
            return;
        }
        Save.GoodList = JsonConvert.DeserializeObject<List<GoodsModel>>(g.text);
        //print(g.text);
    }
    /// <summary>
    /// 武器数据
    /// </summary>
    void EquipAnalysis()
    {
        TextAsset e = Resources.Load("Setting/EquipList") as TextAsset;
        if (!e)
        {
            return;
        }
        Save.EquipList = JsonConvert.DeserializeObject<List<EquipModel>>(e.text);
        //print(e.text);
    }

}
