using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TinyTeam.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScenceCtrol : MonoBehaviour
{
    public Camera cam;  //主摄像机
    public Transform targetPoint;//摄像机移动到的目标点
    public Transform cube;
    //public Button NewGame;
    //public Button LoadGame;
    // Use this for initialization
    void Start()
    {                                  //起点              目标点                 每次执行移动的距离
        //cam.transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, 3 * Time.deltaTime);
        cam.transform.DOMove(targetPoint.position, 5);
        TTUIPage.ShowPage<TitlePanel>();
        //NewGame.gameObject.SetActive(false);
        //LoadGame.gameObject.SetActive(false);
        //NewGame.onClick.AddListener(creat);
    }

    // Update is called once per frame
    void Update()
    {
        //cam.transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, 3 * Time.deltaTime);

        //if (Input.anyKeyDown&&Time.time>5)
        //{
        //    NewGame.gameObject.SetActive(true);
        //    LoadGame.gameObject.SetActive(true);



        //}


    }
    void creat()
    {
        SceneManager.LoadScene("My Character Creation");
    }
}
