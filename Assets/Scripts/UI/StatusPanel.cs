using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;

public class StatusPanel : TTUIPage
{
    public Text Hp, MaxHp, Mp, MaxMp, Atk, Def, Spd;
    public Button ButtonBack;
    public StatusPanel():base(UIType.Normal,UIMode.HideOther,UICollider.Normal)
    {
        uiPath = "UIPrefab/StatusPanel";
    }
    public override void Awake(GameObject go)
    {
        base.Awake(go);
        Hp = transform.Find("Hp").GetComponent<Text>();
        MaxHp = transform.Find("MaxHp").GetComponent<Text>();
        Mp = transform.Find("Mp").GetComponent<Text>();
        MaxMp = transform.Find("MaxMp").GetComponent<Text>();
        Atk = transform.Find("Atk").GetComponent<Text>();
        Def = transform.Find("Def").GetComponent<Text>();
        Spd = transform.Find("Spd").GetComponent<Text>();

        ButtonBack = transform.Find("ButtonBack").GetComponent<Button>();
        ButtonBack.onClick.AddListener(() => ClosePage<StatusPanel>());
        RefreshProperties();
    }
    public override void Active()
    {
        base.Active();
        RefreshProperties();
    }
    /// <summary>
    /// 刷新属性
    /// </summary>
    private void RefreshProperties()
    {
        Hp.text = Save.UserList[0].Hp.ToString();
        MaxHp.text = Save.UserList[0].MaxHp.ToString();
        Mp.text = Save.UserList[0].Mp.ToString();
        MaxMp.text = Save.UserList[0].MaxMp.ToString();
        Atk.text = Save.UserList[0].Attack.ToString();
        Def.text = Save.UserList[0].Def.ToString();
        Spd.text = Save.UserList[0].Speed.ToString();
    }
}
