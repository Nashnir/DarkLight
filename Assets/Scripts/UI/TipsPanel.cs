using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;

public class TipsPanel : TTUIPage
{
    public Text tips;
    public Button buttonOK;
    public TipsPanel():base(UIType.PopUp,UIMode.DoNothing,UICollider.Normal)
    {
        uiPath = "UIPrefab/TipsPanel";
    }
    public override void Awake(GameObject go)
    {
        base.Awake(go);
        tips = transform.Find("Text").GetComponent<Text>();
        tips.text = data.ToString();
        buttonOK = transform.Find("Button").GetComponent<Button>();
        buttonOK.onClick.AddListener(() => ClosePage<TipsPanel>());
    }
}
