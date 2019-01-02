using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using System;

public class MainPanel : TTUIPage
{
    private Button StatusButton, BagButton, EquipButton, SkillButton, TipsButton;
    public MainPanel():base(UIType.Normal,UIMode.DoNothing,UICollider.None)
    {
        uiPath = "UIPrefab/MainPanel";
    }
    public override void Awake(GameObject go)
    {
        base.Awake(go);
        StatusButton = transform.Find("StatusButton").GetComponent<Button>();
        BagButton = transform.Find("BagButton").GetComponent<Button>();
        EquipButton = transform.Find("EquipButton").GetComponent<Button>();
        SkillButton = transform.Find("SkillButton").GetComponent<Button>();
        TipsButton = transform.Find("TipsButton").GetComponent<Button>();

        TipsButton.gameObject.SetActive(false);
        ShopItemlist.OnNpcTrigger += ShowTips;//提示按钮在靠近NPC时出现
        ForgingNpc.isForgingNpc += ShowForging;

        StatusButton.onClick.AddListener(() => ShowPage<StatusPanel>());
        BagButton.onClick.AddListener(() => ShowPage<BagPanel>());
        EquipButton.onClick.AddListener(() => ShowPage<EquipPanel>());
    }

    private void ShowForging(bool isShow)
    {
        TipsButton.gameObject.SetActive(isShow);//提示按钮默认隐藏
        if (isShow)
        {
            TipsButton.onClick.AddListener(() => TTUIPage.ShowPage<ForgingPanel>());
        }
        if (!isShow)
        {
            if (allPages.ContainsKey("ForgingPanel"))
            {
                TTUIPage.ClosePage<ForgingPanel>();

            }
            TipsButton.gameObject.SetActive(false);

            TipsButton.onClick.RemoveAllListeners();
        }
    }


    /// <summary>
    /// 是否显示提示按钮
    /// </summary>
    /// <param name="isShow">按钮是否显示</param>
    /// <param name="_itemLIst">NPC传来的物品列表</param>
    public void ShowTips(bool isShow,List<int> _itemLIst)
    {
        TipsButton.gameObject.SetActive(isShow);//提示按钮默认隐藏
        if (isShow)
        {
            TipsButton.onClick.AddListener(() => TTUIPage.ShowPage<ShopPanel>(_itemLIst));
        }
        if (!isShow)
        {
            if (allPages.ContainsKey("ShopPanel"))
            {
                TTUIPage.ClosePage<ShopPanel>();

            }
            TipsButton.gameObject.SetActive(false);

            TipsButton.onClick.RemoveAllListeners();
        }
    }
}
