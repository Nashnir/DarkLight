using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;

public class BagPanel : TTUIPage
{
    private Transform MyGrid;
    public Button ButtonBack;


    public BagPanel():base(UIType.Normal,UIMode.HideOther, UICollider.None)
    {
        uiPath = "UIPrefab/BagPanel";
    }
    public override void Awake(GameObject go)
    {
        base.Awake(go);
        base.Awake(go);
        MyGrid = transform.Find("MyGrid");
        ButtonBack = transform.Find("ButtonBack").GetComponent<Button>();
        ButtonBack.onClick.AddListener(() => ClosePage<BagPanel>());
        ShowBag();
        BagItem.UserEvent += ShowBag;
        DragImage.DragEvent += ShowBag;
        ForgingPanel.OnForging += ShowBag;
    }
    public override void Active()
    {
        base.Active();
        ShowBag();
    }

    public void ShowBag()
    {
        ClearBag();
        int j = 0;
        if (Save.GoodList.Count != 0)
        {
            foreach (GoodsModel item in Save.GoodList)
            {
                if (item.Num > 0)//物品数量不等于零时
                {
                    GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("UIPrefab/BagItem"));

                    go.transform.SetParent(MyGrid.GetChild(j));
                    go.transform.localScale = Vector3.one;
                    go.transform.localPosition = Resources.Load<GameObject>("UIPrefab/BagItem").transform.localPosition;
                    go.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon/" + item.Id.ToString());
                    go.transform.GetChild(0).GetComponent<Text>().text = item.Num + "";
                    j++;
                }
            }
        }
    }
    public void ClearBag()
    {
        for (int i = 0; i < MyGrid.childCount; i++)
        {
            if (MyGrid.GetChild(i).childCount != 0)
            {
                Transform tf = MyGrid.GetChild(i).GetChild(0);
                tf.SetParent(null);
                Object.Destroy(tf.gameObject);
            }
        }
    }
}
