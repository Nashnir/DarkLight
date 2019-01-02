using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TinyTeam.UI;
using Newtonsoft.Json;
using System;

public class ForgingPanel : TTUIPage
{
    private Image ItemA, ItemB, ItemC;
    private Button ButtonForging;
    public static event Action OnForging;

    public ForgingPanel():base(UIType.Normal,UIMode.DoNothing,UICollider.Normal)
    {
        uiPath = "UIPrefab/ForgingPanel";
    }
    public override void Awake(GameObject go)
    {
        base.Awake(go);
        ItemA = transform.Find("ItemA/Image").GetComponent<Image>();
        ItemB = transform.Find("ItemB/Image").GetComponent<Image>();
        ItemC = transform.Find("ItemC/Image").GetComponent<Image>();
        ButtonForging = transform.Find("ButtonForging").GetComponent<Button>();
        ButtonForging.onClick.AddListener(Forging);
    }
    private void Forging()
    {
        ParseFormulaJSON();
        ForgeItem();
    }

    private List<Formula> formulaList = null;//用来存放解析出来的材料
    public void ParseFormulaJSON()
    {
        formulaList = new List<Formula>();
        TextAsset formulaText = Resources.Load<TextAsset>("Setting/Formulas");
        //string formulaJson = formulaText.text;
        List<Formula> tempList = JsonConvert.DeserializeObject<List<Formula>>(formulaText.text);
        foreach (Formula temp in tempList)
        {
            int item1ID = (int)temp.Item1ID;
            int item1Amount = (int)temp.Item1Amount;
            int item2ID = (int)temp.Item2ID;
            int item2Amount = (int)temp.Item2Amount;
            int resID = (int)temp.ResID;
            Formula formula = new Formula(item1ID, item1Amount, item2ID, item2Amount, resID);
            formulaList.Add(formula);
        }
        //Debug.Log(formulaList[1].ResID);
    }
    public void ForgeItem()
    {
        //得到当前锻造面板里面有哪些材料
        List<int> haveMaterialIDList = new List<int>();//存储当前锻造面板里面拥有的材料的ID
        haveMaterialIDList.Add(int.Parse(ItemA.sprite.name));
        haveMaterialIDList.Add(int.Parse(ItemB.sprite.name));

        //foreach (Slot slot in slotArray)
        //{
        //    if (slot.transform.childCount > 0)
        //    {
        //        ItemUI currentItemUI = slot.transform.GetChild(0).GetComponent<ItemUI>();
        //        for (int i = 0; i < currentItemUI.Amount; i++)
        //        {
        //            haveMaterialIDList.Add(currentItemUI.Item.ID);//物品槽里有多少个物品，就存储多少个ID
        //        }
        //    }
        //}
        //Debug.Log(haveMaterialIDList[0].ToString());
        //判断满足哪一个锻造配方的需求
        Formula matchedFormula = null;
        foreach (Formula formula in formulaList)
        {
            bool isMatch = formula.Match(haveMaterialIDList);
            //Debug.Log(isMatch);
            if (isMatch)
            {
                matchedFormula = formula;
                break;
            }
        }
        // Debug.Log(matchedFormula.ResID);
        if (matchedFormula != null)
        {

            //Knapscak.Instance.StoreItem(matchedFormula.ResID);//把锻造出来的物品放入背包
            DataMgr.Item item = DataMgr.GetInstance().GetItemByID(matchedFormula.ResID);
            Save.BuyItem(item);
            //减掉消耗的材料
            ItemA.sprite = Resources.Load<Sprite>("Icon/0");
            ItemB.sprite = Resources.Load<Sprite>("Icon/0");
            OnForging();
            ItemC.sprite = Resources.Load<Sprite>("Icon/" + matchedFormula.ResID.ToString());
            //foreach (int id in matchedFormula.NeedIDList)
            //{

            //foreach (Slot slot in slotArray)
            //{
            //    if (slot.transform.childCount > 0)
            //    {
            //        ItemUI itemUI = slot.transform.GetChild(0).GetComponent<ItemUI>();
            //        if (itemUI.Item.ID == id && itemUI.Amount > 0)
            //        {
            //            itemUI.RemoveItemAmount();
            //            if (itemUI.Amount <= 0)
            //            {
            //                DestroyImmediate(itemUI.gameObject);
            //            }
            //            break;
            //        }
            //    }
            //}
            //}
        }
    }
}
