using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipItem : MonoBehaviour
{

    private Transform EquipInfo;
    private Button InfoBtn, BackButton, TakeOffButton;
    private DataMgr.Item item;
    public static event Action TakeOffEquip;

    void Start()
    {
        item = DataMgr.GetInstance().GetItemByID(int.Parse(transform.GetComponent<Image>().sprite.name));
        InfoBtn = transform.GetComponent<Button>();
        EquipInfo = transform.parent.parent.Find("EquipInfo");
        BackButton = EquipInfo.Find("BackButton").GetComponent<Button>();
        TakeOffButton = EquipInfo.Find("TakeOffButton").GetComponent<Button>();
        BackButton.onClick.AddListener(() => EquipInfo.gameObject.SetActive(false));
        InfoBtn.onClick.AddListener(() => { Show(); TakeOffButton.onClick.AddListener(TakeOff); });
    }

    private void Show()
    {
        EquipInfo.gameObject.SetActive(true);
        EquipInfo.localScale = Vector3.one;
        EquipInfo.Find("NameLabel").GetComponent<Text>().text = item.item_Name;
        EquipInfo.Find("MessageLabel").GetComponent<Text>().text = item.description;
    }
    private void TakeOff()
    {
        Save.TakeOffEquip(item);
        TakeOffEquip();
        EquipInfo.gameObject.SetActive(false);
    }

}
