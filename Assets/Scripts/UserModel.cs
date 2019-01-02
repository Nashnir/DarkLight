using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using LitJson;
using UnityEditor;
using System;

public class UserModel {
    /*  {"UserList":[{"Hp":80,"MaxHp":120,"Attack":35,"Speed":25}]}  */
    public int Hp;
    public int MaxHp;
    public int Mp;
    public int MaxMp;
    public int Attack;
    public int Speed;
    public int Def;  
}
public class GoodsModel //商品信息
{
    public int Id;
    public string Name;
    public string Nature;//图片种类(图片名)
    public string Function;//物品描述
    public int Value;//值
    public int Num;//数量
}
public class EquipModel
{

    public int id;
    public DataMgr.Equipment_Type Equipment_Type;  
}
public class MyTask
{
    public string taskId;
}



public  class Save
{
    /// <summary>
    /// 背包里物品
    /// </summary>
    public static List<GoodsModel> GoodList;
    
    /// <summary>
    /// 用户列表
    /// </summary>
    public static List<UserModel> UserList;
   
    /// <summary>
    /// 装备列表
    /// </summary>
    public static List<EquipModel> EquipList;

    /// <summary>
    /// 使用物品
    /// </summary>
    /// <param name="item"></param>
    public static void UserGoods(DataMgr.Item item)
    {
        if (GoodList == null)
        {
            GoodList = new List<GoodsModel>();
        }
        if (EquipList == null)
        {
            EquipList = new List<EquipModel>();
        }
        if (UserList == null)
        {
            UserList = new List<UserModel>();
        }
        GoodsModel gm = GoodList.Find(x => x.Id == item.item_ID);
        gm.Num -= 1;
        UserList[0].Attack += item.atk;
        UserList[0].Def += item.def;
        UserList[0].Speed += item.spd;
        if ((UserList[0].Hp += item.hp) <= UserList[0].MaxHp)
            UserList[0].Hp += item.hp;
        else
            UserList[0].Hp = UserList[0].MaxHp;

        if ((UserList[0].Mp += item.mp) <= UserList[0].MaxMp)
            UserList[0].Mp += item.mp;
        else
            UserList[0].Mp = UserList[0].MaxMp;
        for (int i = 0; i < EquipList.Count; i++)
        {

            if (item.equipment_Type == EquipList[i].Equipment_Type)
            {
                if ((int)item.equipment_Type == 0)//使用的是药水
                {                 
                    break;
                }
                if ((int)item.equipment_Type == 7)//使用的是双手武器
                {
                    GoodsModel good5 = GoodList.Find(x => x.Id == EquipList[5].id);
                    GoodsModel good6 = GoodList.Find(x => x.Id == EquipList[6].id);
                    if (good5 != null)
                    {
                        good5.Num += 1;
                    }
                    if (good6 != null)
                    {
                        good6.Num += 1;
                    }
                    EquipList[6].id = item.item_ID;
                    EquipList[5].id = 0;
                    break;
                }
                if (EquipList[i].id != 0)//武器的替换
                {
                    GoodsModel good = GoodList.Find(x => x.Id == EquipList[i].id);
                    good.Num += 1;
                }              
                EquipList[i].id = item.item_ID;
            }
        }
        SaveGoods();
    }

    /// <summary>
    /// 脱装备
    /// </summary>
    /// <param name="item"></param>
    public static void TakeOffEquip(DataMgr.Item item)
    {
        if (GoodList == null)
        {
            GoodList = new List<GoodsModel>();
        }
        if (EquipList == null)
        {
            EquipList = new List<EquipModel>();
        }
        GoodsModel gm = GoodList.Find(x => x.Id == item.item_ID);
        gm.Num += 1;

        UserList[0].Attack -= item.atk;
        UserList[0].Def -= item.def;
        UserList[0].Speed -= item.spd;

        for (int i = 0; i < EquipList.Count; i++)
        {
            if (item.equipment_Type == EquipList[i].Equipment_Type)
            {
                if ((int)item.equipment_Type == 7)
                {
                    EquipList[6].id = 0;
                }
                EquipList[i].id = 0;
            }
        }
        SaveGoods();
    }

    /// <summary>
    /// 购买物品
    /// </summary>
    /// <param name="item"></param>
    public static void BuyItem(DataMgr.Item item)
    {
        if (GoodList==null)
        {
            GoodList = new List<GoodsModel>();
        }
        GoodsModel gm = GoodList.Find(x => x.Id == item.item_ID);
        if (gm != null)
        {
            gm.Num += 1;
        }
        else
        {
            GoodList.Add(new GoodsModel() { Id = item.item_ID, Num = 1 });
        }
        SaveGoods();
    }

    /// <summary>
    /// 保存数据
    /// </summary>
    public static void SaveGoods()
    {
        string path = Application.dataPath + @"/Resources/Setting/EquipList.txt";
        FileInfo info = new FileInfo(path);
        StreamWriter sw = info.CreateText();
        string json = JsonConvert.SerializeObject(EquipList);
        sw.Write(json);
        sw.Close();
        sw.Dispose();

        string path1 = Application.dataPath + @"/Resources/Setting/GoodsList.json";
        FileInfo info1 = new FileInfo(path1);
        StreamWriter sw1 = info1.CreateText();
        string json1 = JsonConvert.SerializeObject(GoodList);
        sw1.Write(json1);
        sw1.Close();
        sw1.Dispose();

        string path2 = Application.dataPath + @"/Resources/Setting/UserJson.txt";
        FileInfo info2 = new FileInfo(path2);
        StreamWriter sw2 = info2.CreateText();
        string json2 = JsonConvert.SerializeObject(UserList);
        sw2.Write(json2);
        sw2.Close();
        sw2.Dispose();

        AssetDatabase.Refresh();
    }
}