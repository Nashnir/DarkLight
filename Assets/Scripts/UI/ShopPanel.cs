using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TinyTeam.UI;
using Newtonsoft.Json;
using System;

public class ShopPanel : TTUIPage
{
    public Image imageSlot, image;
    public Button buttonBuy;
    public Text textName, textType, textPrice;
    Transform Grid;
    public Button ButtonBack;

    public ShopPanel():base(UIType.Normal,UIMode.HideOther, UICollider.None)
    {
        uiPath = "UIPrefab/ShopPanel";    
    }
    public List<int> itemList;
    public override void Awake(GameObject go)
    {
        base.Awake(go);
        itemList = new List<int>((List<int>)data);
        Grid = transform.Find("Viewport").transform.Find("Grid");
        ButtonBack = transform.Find("ButtonBack").GetComponent<Button>();
        ButtonBack.onClick.AddListener(() => ClosePage<ShopPanel>());
        ShowShop();
        //ShopItemlist.OffNpcTrigger += ClearShop;
    }
    public void ShowShop()
    {     
        //遍历物品信息
        int j = 0;
        foreach (int id in itemList)
        {
            DataMgr.Item item= DataMgr.GetInstance().GetItemByID(id);
            GameObject go =GameObject.Instantiate( Resources.Load<GameObject>("UIPrefab/ShopItem"));          
            go.transform.SetParent(Grid.GetChild(j));
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Resources.Load<GameObject>("UIPrefab/ShopItem").transform.localPosition;
            
            go.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon/" + item.item_ID);
            go.transform.Find("TextName").GetComponent<Text>().text = item.item_Name;
            go.transform.Find("TextType").GetComponent<Text>().text = item.item_Type;
            go.transform.Find("TextPrice").GetComponent<Text>().text = item.price.ToString();
            j++;         

        }
    }



    public override void Hide()
    {
        base.Hide();
        GameObject.Destroy(gameObject);
    }
}
