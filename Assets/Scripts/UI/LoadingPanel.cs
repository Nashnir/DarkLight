using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using TinyTeam;
using UnityEngine.UI;

public class LoadingPanel : TTUIPage {



    public Slider sliderloading;
    public Text textprogress;
    public LoadingPanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    { 
        uiPath = "UIPrefab/LoadingPanel";
    }
    public override void Awake(GameObject go)
    {
        base.Awake(go);
        sliderloading = transform.Find("Slider").GetComponent<Slider>();
        textprogress = transform.Find("Text").GetComponent<Text>();
    }
}
