using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam;
using TinyTeam.UI;
using UnityEngine.UI;
using DG.DemiLib;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CreatPlayerPanel : TTUIPage
{

    public Button buttonPre, buttonNext, buttonRandom, buttonOK;
    public InputField inputFieldName;//名字输入框
    public string[] xings = { "赵", "钱", "孙", "李", "周", "吴", "郑", "王" };
    public string[] mings = { "宿舍", "上网", "2", "放", "图", "求", "并", "投入" };
    /// <summary>
    /// 随机姓名
    /// </summary>
    public void getRandomName()
    {
        string xing = xings[Random.Range(0, xings.Length)];
        string ming = mings[Random.Range(0, mings.Length)];
        string name = xing + ming;
        inputFieldName.text = name;
    }
    /// <summary>
    /// 构造函数
    /// </summary>
    /// 

    public GameObject[] hero;  //your hero
                               //public GameObject buttonNext,buttonPrev; //button prev and button next

    [HideInInspector]
    public int indexHero = 0;  //index select hero

    private GameObject[] heroInstance; //use to keep hero gameobject when Instantiate




    public CreatPlayerPanel() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "UIPrefab/CreatPlayerPanel";
    }


    public override void Awake(GameObject go)
    {
        base.Awake(go);
        buttonPre = transform.Find("ButtonPre").GetComponent<Button>();
        buttonNext = transform.Find("ButtonNext").GetComponent<Button>();
        buttonRandom = transform.Find("ButtonRandom").GetComponent<Button>();
        buttonOK = transform.Find("ButtonOK").GetComponent<Button>();
        inputFieldName = transform.Find("InputField").GetComponent<InputField>();


        int s = 0;

        buttonRandom.onClick.AddListener(() =>
        {

            getRandomName(); buttonRandom.transform.DORotate(Vector3.forward * (s + 180), 1f); buttonRandom.transform.rotation = Quaternion.Euler(0, 0, 0);

        });





        buttonOK.onClick.AddListener(buttonokonclick);



        hero = Resources.LoadAll<GameObject>("Player/HeroPreview");//加载指定路径下的所有Gameobject
        heroInstance = new GameObject[hero.Length]; //add array size equal hero size
        indexHero = 0; //set default selected hero
        SpawnHero(); //spawn hero to display current selected


        //check if hero is less than 1 , button next and prev will disappear
        if (hero.Length <= 1)
        {
            buttonNext.gameObject.SetActive(false);
            buttonPre.gameObject.SetActive(false);
        }

        ///上一个和下一个按钮
        buttonNext.onClick.AddListener(() =>
        {
            indexHero++;
            if (indexHero >= heroInstance.Length)
            {
                indexHero = 0;

            }
            UpdateHero(indexHero);
        });
        buttonPre.onClick.AddListener(() =>
        {
            indexHero--;
            if (indexHero < 0)
            {
                indexHero = heroInstance.Length - 1;

            }
            UpdateHero(indexHero);
        });
    }

    /// <summary>
    /// 显示指定索引所对应的角色
    /// </summary>
    /// <param name="_indexHero"></param>
    public void UpdateHero(int _indexHero)
    {
        for (int i = 0; i < hero.Length; i++)
        {
            //Show only select character
            if (i == _indexHero)
            {
                heroInstance[i].SetActive(true);
            }
            else
            {
                //Hide Other Character
                heroInstance[i].SetActive(false);
            }
        }
    }

    //Spawn all hero生成所有的角色 只显示默认的角色
    public void SpawnHero()
    {
        for (int i = 0; i < hero.Length; i++)
        {
            heroInstance[i] = (GameObject)GameObject.Instantiate(hero[i], Vector3.zero, new Quaternion(0, 180, 0, 1));
        }
        //Quaternion.Euler(0, 180, 0);
        UpdateHero(indexHero);
    }


    public void buttonokonclick()
    {
        PlayerPrefs.SetString("pName", inputFieldName.text);
        PlayerPrefs.SetInt("pSelect", indexHero);
        //切换场景
        //SceneManager.LoadScene("Dreamdev Village");
        kuozhan.qiehuan("Dreamdev Village");
    }
}
