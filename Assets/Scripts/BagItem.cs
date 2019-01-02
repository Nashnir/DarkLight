using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
/// <summary>
/// 挂载在预设物上  
/// </summary>
public class BagItem : MonoBehaviour
{
    //当前物品的图片
    private Sprite Sprite;
    //当前物品
    //public GoodsModel CurrentGoods;
    //选中物品的Id
    public static int CurrentGoodsId;
    //物品信息显示框
    private Transform BagInfo;
    private Button InfoBtn, BackButton, UseButton;
    private DataMgr.Item item;
    public static event Action UserEvent;
    // Use this for initialization
    void Start()
    {       
        Sprite = GetComponent<Image>().sprite;
        CurrentGoodsId = int.Parse(Sprite.name);
        item = DataMgr.GetInstance().GetItemByID(CurrentGoodsId);

        BagInfo = transform.parent.parent.parent.Find("BagInfo");
        InfoBtn = transform.Find("InfoBtn").GetComponent<Button>();
        BackButton = BagInfo.Find("BackButton").GetComponent<Button>();
        UseButton = BagInfo.Find("UseButton").GetComponent<Button>();
        InfoBtn.onClick.AddListener(() => { Show(); UseButton.onClick.AddListener(Use); });
        BackButton.onClick.AddListener(() => BagInfo.gameObject.SetActive(false));
    }

    public void Use()
    {
        Save.UserGoods(item);
        UserEvent();
        BagInfo.gameObject.SetActive(false);
    }
    public void Show()
    {
        BagInfo.gameObject.SetActive(true);
        BagInfo.localScale = Vector3.one;
        BagInfo.Find("NameLabel").GetComponent<Text>().text = item.item_Name;
        BagInfo.Find("MessageLabel").GetComponent<Text>().text = item.description;
    }
}
