using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DataMgr
{
    private static DataMgr Instance = null;
    private DataMgr()
    {
        Awake();
    }
    public static DataMgr GetInstance()
    {
        
        if (Instance==null)
        {
            Instance = new DataMgr();
        }
        return Instance;
    }
    /// <summary>
    /// 存放所有物品
    /// </summary>
    public  List<Item> itemList = new List<Item>();

    // Start is called before the first frame update
    private  void Awake()
    {
        TextAsset ta = Resources.Load("Item/ItemData") as TextAsset;
        itemList = JsonConvert.DeserializeObject<List<Item>>(ta.text);
        //Debug.Log(itemList.Count);
    }
    /// <summary>
    /// 根据ID获取物品信息
    /// </summary>
    /// <param name="_id"></param>
    public Item GetItemByID(int _id)
    {
        return itemList.Find(item => item.item_ID == _id);
            
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 物品类
    /// </summary>
    [System.Serializable]
    public class Item
    {
        public string item_Name = "Item Name";
        public string item_Type = "Item Type";
        [Multiline]
        public string description = "Description Here";
        public int item_ID;
        public string item_Img;//图片名字
        public string item_Effect;//特效名字
        public string item_Sfx;//音效名字
        public Equipment_Type equipment_Type;
        public int price;
        public int hp, mp, atk, def, spd, hit;
        public float criPercent, atkSpd, atkRange, moveSpd;
    }
    public enum Equipment_Type
    {
        Null = 0, Head_Gear = 1, Armor = 2, Shoes = 3, Accessory = 4, Left_Hand = 5, Right_Hand = 6, Two_Hand = 7
    }
}
