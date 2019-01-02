using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TinyTeam.UI;

public class ShopItem : MonoBehaviour
{
    private Button ButtonOK,ButtonBuy;
    int id;
    private GameObject ImageInfo;
    private Toggle checkToggle;
    public DataMgr.Item item;
    void Start()
    {
        id =int.Parse(transform.Find("Image").GetComponent<Image>().sprite.name);
        item = DataMgr.GetInstance().GetItemByID(id);

        ImageInfo = transform.parent.parent.parent.parent.Find("ShopInfo").gameObject;
        ImageInfo.SetActive(false);

        checkToggle = transform.Find("Image").Find("Toggle").GetComponent<Toggle>();
        checkToggle.onValueChanged.AddListener((bool isOn) => { OnToggleClick(isOn); });

        ButtonOK = ImageInfo.transform.Find("ButtonOK").GetComponent<Button>();
        ButtonBuy = transform.Find("ButtonBuy").GetComponent<Button>();
        ButtonBuy.onClick.AddListener(() => 
        {   Save.BuyItem(item);
            SoundManager.instance.PlayingSound("BuyItem");
            TTUIPage.ShowPage<TipsPanel>("购买成功");
        });
        ButtonOK.onClick.AddListener(CloseInfo);
    }

    private void OnToggleClick(bool isOn)
    {
        ImageInfo.SetActive(isOn);
        ImageInfo.transform.Find("TextName").GetComponent<Text>().text = item.item_Name;
        ImageInfo.transform.Find("TextInfo").GetComponent<Text>().text = item.description;
    }

    private void CloseInfo()
    {
        ImageInfo.SetActive(false);
        checkToggle.isOn = false;

    }
}
