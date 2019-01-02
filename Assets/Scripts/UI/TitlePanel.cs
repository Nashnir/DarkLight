using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TinyTeam.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TitlePanel : TTUIPage
{

    public Image imageTitle;
    public Image imageAnyKey;
    public Image imageWhite;
    public Button buttonLoad, buttonnew;
    public TitlePanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "UIPrefab/TitlePanel";
    }
    public override void Awake(GameObject go)
    {
        imageTitle = transform.Find("ImageTitle").GetComponent<Image>();
        imageAnyKey = transform.Find("ImageAnyKey").GetComponent<Image>();
        imageWhite = transform.Find("ImageBG").GetComponent<Image>();
        imageTitle.color = new Color(1, 1, 1, 0);
        buttonnew = transform.Find("ButtonNewGane").GetComponent<Button>();
        buttonLoad = transform.Find("ButtonLoadGame").GetComponent<Button>();
        buttonLoad.gameObject.SetActive(false);
        buttonnew.gameObject.SetActive(false);



        imageAnyKey.gameObject.SetActive(false);
        imageWhite.DOFade(0, 2f).SetDelay(0.2F);
        imageTitle.DOFade(1, 2).SetDelay(3);
        //GameObject.Destroy(buttonnew.GetComponent<Button>());
        buttonnew.GetComponent<Image>().DOFade(1, 1).SetDelay(5).OnStart(() => buttonnew.gameObject.SetActive(true));
        buttonLoad.GetComponent<Image>().DOFade(1, 1).SetDelay(5).OnStart(() => buttonLoad.gameObject.SetActive(true));
        //  imageAnyKey.DOFade(0, 1).SetLoops(-1).SetDelay(5).OnStart(() => imageAnyKey.gameObject.SetActive(true));
        buttonnew.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Loading");
            GameCtroller.Instance.nextScenceName = "My Character Creation";
        });


        buttonLoad.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Loading");
            GameCtroller.Instance.nextScenceName = "Dreamdev Village";
        });
        //kuozhan.qiehuan("My Character Creation");
        //判断是否有存档
        if (PlayerPrefs.HasKey("SaveData"))

        {
            buttonLoad.interactable = false;
        }
    }
}
public class kuozhan
{
    public static void qiehuan(string name)
    {
        SceneManager.LoadScene("Loading");
        GameCtroller.Instance.nextScenceName = name;

    }
}
