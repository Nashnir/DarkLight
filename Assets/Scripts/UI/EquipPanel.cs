using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using System;

public class EquipPanel : TTUIPage
{
    private Transform Head_Gear, Armor, Right_Hand, Left_Hand, Shoes, Accessory;
    public Button ButtonBack;

    public EquipPanel() : base(UIType.Normal, UIMode.HideOther, UICollider.Normal)
    {
        uiPath = "UIPrefab/EquipPanel";
    }
    public override void Awake(GameObject go)
    {
        base.Awake(go);
        Head_Gear = transform.Find("Head_Gear");
        Armor = transform.Find("Armor");
        Right_Hand = transform.Find("Right_Hand");
        Left_Hand = transform.Find("Left_Hand");
        Shoes = transform.Find("Shoes");
        Accessory = transform.Find("Accessory");
        EquipItem.TakeOffEquip += ShowEquip;
        ButtonBack = transform.Find("ButtonBack").GetComponent<Button>();
        ButtonBack.onClick.AddListener(() => ClosePage<EquipPanel>());
        ShowEquip();
    }
    public override void Active()
    {
        base.Active();
        ShowEquip();
        
    }
    public void ShowEquip()
    {
        ClearEquip();
        if (Save.EquipList != null)
        {
            foreach (EquipModel item in Save.EquipList)
            {

                if (item.id != 0)
                {
                    if ((int)item.Equipment_Type == 0)
                    {
                        continue;
                    }
                    if ((int)item.Equipment_Type == 7)
                    {
                        continue;
                    }
                    GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("UIPrefab/EquipItem"));
                    go.transform.SetParent(transform.Find(item.Equipment_Type.ToString()));
                    go.transform.localScale = Vector3.one;
                    go.transform.localPosition = Resources.Load<GameObject>("UIPrefab/EquipItem").transform.localPosition;
                    go.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon/" + item.id.ToString());
                }
            }
        }    
    }

    private void ClearEquip()
    {
        for (int i = 0; i < 7; i++)
        {
            if (transform.GetChild(i).childCount != 0)
            {
                Transform tf = transform.GetChild(i).GetChild(0);
                tf.SetParent(null);
                GameObject.Destroy(tf.gameObject);
            }
        }
    }
}