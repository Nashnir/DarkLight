using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;
using UnityEditor;
using UnityEngine.UI;
using System;

public class MyUIManager : MonoBehaviour {

    public Text Hp, MaxHp, Attack, Speed;
    public GameObject GoodsPrefab;//物品预设物
    public GameObject BagInfo;//背包信息面板
    public GameObject ShowInfo;//显示信息面板
    public GameObject UserInfo;//用户信息面板
    public GameObject EquipInfo;//武器信息面板
    public Transform Grid;//背包空格
    public GameObject[] GridArray;
    public Button BagBtn;
    public Button EquipBtn;
    public Button UserBtn;
    public Button BackBtn;
    void Start()
    {
        BagBtn.onClick.AddListener(BagBtnClick);
        UserBtn.onClick.AddListener(UserBtnClick);
        EquipBtn.onClick.AddListener(EquipBtnClick);
        RefreshNature();
    }
    bool isUser = false;
    private void UserBtnClick()
    {
        if (isUser)
        {
            UserInfo.SetActive(false);
            isUser = false;
        }
        else
        {
            UserInfo.SetActive(true);
            isUser = true;
        }
    }
    bool isEquip = false;
    private void EquipBtnClick()
    {
        if (isEquip)
        {
            EquipInfo.SetActive(false);
            isEquip = false;
        }
        else
        {
            EquipInfo.SetActive(true);
            isEquip = true;
        }
    }

    /// <summary>
    /// 刷新属性界面数据
    /// </summary>
    public void RefreshNature()
    {
        //Hp.text = Nature.Instance.Hp + "";
        //MaxHp.text = Nature.Instance.MaxHp + "";
        //Attack.text = Nature.Instance.Attack + "";
        //Speed.text = Nature.Instance.Speed + "";
        //// 吃药的方法   使用物品后 属性改变
        //Nature.Instance.Eat();
    }
    /// <summary>
    /// 点击背包按钮
    /// </summary>
    int temp = 0;
    public void BagBtnClick()
    {
        if (temp % 2 == 0)
        {
            //显示背包数据            
            ShowBag();
            BagInfo.SetActive(true);
        }
        else
        {
            ClearBag();
            BagInfo.SetActive(false);
            ShowInfo.SetActive(false);
        }
        temp++;
    }
    /// <summary>
    /// 显示背包数据
    /// </summary>
    public void ShowBag()
    {
        //清除背包
        ClearBag();

        //遍历物品信息
        int j = 0;
        foreach (GoodsModel item in Save.GoodList)
        {
            // if (Save.SaveGoods.GoodsList[j].Num !=0)
            if (item.Num != 0)//物品数量不等于零时
            {
                
                GameObject go = Instantiate(GoodsPrefab);
                go.transform.SetParent(Grid.GetChild(j));
                go.transform.position = go.transform.parent.position;
                //显示物体的图片及数量
                go.GetComponent<Image>().sprite = Resources.Load<Sprite>(item.Nature);
                go.transform.GetChild(0).GetComponent<Text>().text = item.Num + "";
               
                j++;
            }
        }
        //for (int i = 0; i < Save.SaveGoods.GoodsList.Count; i++)
        //{
        //    if (Save.SaveGoods.GoodsList[i].Num != 0)//物品数量不等于零时
        //    {
        //        //创建物品 NGUITools.AddChild(父物体，预设物);
        //        GameObject go = NGUITools.AddChild(GameObject.Find("Grid").transform.GetChild(i).gameObject, GoodsPrefab);
        //        go.GetComponent<UISprite>().spriteName = Save.SaveGoods.GoodsList[i].Nature;
        //        go.transform.GetChild(0).GetComponent<UILabel>().text = Save.SaveGoods.GoodsList[i].Num + "";
        //    }
        //}

    }
    /// <summary>
    /// 清除背包数据
    /// </summary>
    public void ClearBag()
    {
        //删除之前创建物品的预设物
        for (int i = 0; i < GridArray.Length; i++)
        {
            if (GridArray[i].transform.childCount != 0)
            {
               Transform tf = GridArray[i].transform.GetChild(0);
                tf.SetParent(null);
                Destroy(tf.gameObject);
            }
        }
    }
    /// <summary>
    ///提示框的返回按钮
    /// </summary>
    public void ShowInfo_BackBtnClick()
    {
        //倒放 提示框动画
        ShowInfo.SetActive(false);

    }
    /// <summary>
    /// 提示框中的使用物品按钮方法
    /// </summary>
    //当前使用的物品
    public GoodsModel CurrentGoods;
    //public void ShowInfo_UseGoods(int id)
    //{
    //    id = BagItem.CurrentGoodsId;
    //    for (int i = 0; i < Save.GoodList.Count; i++)
    //    {
    //        if (id == Save.GoodList[i].Id)
    //        {
    //            CurrentGoods = Save.GoodList[i];
    //        }
    //    }
    //    //使用物品  类型
    //    switch (id)
    //    {
    //        case 0:
    //            Nature.Instance.Hp += CurrentGoods.Value;
    //            if (Nature.Instance.Hp >= Nature.Instance.MaxHp)
    //            {
    //                Nature.Instance.Hp = Nature.Instance.MaxHp;
    //            }
    //            break;
    //        case 1:
    //            Nature.Instance.MaxHp += CurrentGoods.Value;
    //            break;
    //        case 2:
    //            Nature.Instance.Attack += CurrentGoods.Value;
    //            break;
    //        case 3:
    //            Nature.Instance.Speed += CurrentGoods.Value;
    //            break;
    //        case 4:
    //            Nature.Instance.Hp += CurrentGoods.Value;
    //            break;
    //        default:
    //            break;
    //    }
    //    CurrentGoods.Num--;
    //    if (CurrentGoods.Num <= 0)
    //    {
    //        ShowInfo.SetActive(false);
    //        //ShowInfoAnimation.PlayReverse();
    //        CurrentGoods.Num = 0;
    //    }
    //    //刷新属性界面数据
    //    RefreshNature();
    //    //刷新背包界面数据
    //    ShowBag();

    //    for (int i = 0; i < Save.GoodList.Count; i++)
    //    {
    //        if (Save.GoodList[i].Id == CurrentGoods.Id)
    //        {
    //            Save.GoodList[i] = CurrentGoods;
    //        }
    //    }
    //}
    /// <summary>
    /// 点击保存按钮
    /// </summary>
    //public void SaveBtnClick()
    //{
    //    string path = Application.dataPath + @"/Resources/Setting/UserJson.txt";
    //    FileInfo info = new FileInfo(path);
    //    StreamWriter sw = info.CreateText();
    //    string json = JsonMapper.ToJson(Save.SaveUser);
    //    sw.Write(json);
    //    sw.Close();
    //    sw.Dispose();
    //    AssetDatabase.Refresh();

    //    string path1 = Application.dataPath + @"/Resources/Setting/GoodsList.json";
    //    FileInfo info1 = new FileInfo(path1);
    //    StreamWriter sw1 = info1.CreateText();
    //    string json1 = JsonMapper.ToJson(Save.SaveGoods);
    //    sw1.Write(json1);
    //    sw1.Close();
    //    sw1.Dispose();
    //    AssetDatabase.Refresh();
    //}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (GridArray[GridArray.Length-1].transform.childCount != 0)
            {
                Debug.Log("背包已满");
            }
            else
            {
                for (int i = 0; i < GridArray.Length; i++)
                {
                    if (GridArray[i].transform.childCount == 0)
                    {
                        GameObject go = Instantiate(GoodsPrefab);
                        go.transform.SetParent(Grid.transform.GetChild(i));
                        go.transform.position = go.transform.parent.transform.position;

                        go.GetComponent<Image>().sprite = Resources.Load<Sprite>("29000001");

                        go.transform.GetChild(0).GetComponent<Text>().text = "1";
                        break;
                    }
                }
            }
        }      
    }
}
