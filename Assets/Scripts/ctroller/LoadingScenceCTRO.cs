using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using TinyTeam.UI;

//public class LoadingScenceCTRO : MonoBehaviour {

//    public Slider progressBar;
//    public Text text;

//    // 目标进度
//    float target = 0;
//    // 读取场景的进度，取值范围0~1
//    float progress = 0;
//    // 异步对象
//    AsyncOperation op = null;

//    void Start()
//    {
//        Debug.Log("开始LoadScene");

//        op = SceneManager.LoadSceneAsync("My Character Creation");
//        op.allowSceneActivation = false;
//        progressBar.value = 0;

//        // 开启协程，开始调用加载方法
//        StartCoroutine(processLoading());
//    }

//    float dtimer = 0;
//    void Update()
//    {
//        progressBar.value = Mathf.Lerp(progressBar.value, target, dtimer * 0.02f);
//        dtimer += Time.deltaTime;
//        if (progressBar.value > 0.99f)
//        {
//            progressBar.value = 1;
//            op.allowSceneActivation = true;
//        }
//        text.text =((int)(progressBar.value*100)/1).ToString()+"%";
//    }

//    // 加载进度
//    IEnumerator processLoading()
//    {
//        while (true)
//        {
//            target = op.progress; // 进度条取值范围0~1
//            if (target >= 0.9f)
//            {
//                target = 1;
//                yield break;
//            }
//            yield return 0;
//        }
//    }
   

//}
public class Globe
{
    public static string nextSceneName;
}
 
public class LoadingScenceCTRO : MonoBehaviour
{
    public Slider loadingSlider;

    public Text loadingText;

    private float loadingSpeed = 1;

    private float targetValue;

    private AsyncOperation operation;

    // Use this for initialization
    void Start()
    {
        TTUIPage.ShowPage<LoadingPanel>();
        LoadingPanel panel = TTUIPage.allPages["LoadingPanel"] as LoadingPanel;
        loadingSlider = panel.sliderloading;
        loadingText = panel.textprogress;
        loadingSlider.value = 0.0f;

        if (SceneManager.GetActiveScene().name == "Loading")
        {
            //启动协程
            StartCoroutine(AsyncLoading());
        }
    }

    IEnumerator AsyncLoading()
    {
        operation = SceneManager.LoadSceneAsync(GameCtroller.Instance.nextScenceName);
        //阻止当加载完成自动切换
        operation.allowSceneActivation = false;

        yield return operation;
    }

    // Update is called once per frame
    void Update()
    {
        targetValue = operation.progress;

        if (operation.progress >= 0.9f)
        {
            //operation.progress的值最大为0.9
            targetValue = 1.0f;
        }

        if (targetValue != loadingSlider.value)
        {
            //插值运算
            loadingSlider.value = Mathf.Lerp(loadingSlider.value, targetValue, Time.deltaTime * loadingSpeed);
            if (Mathf.Abs(loadingSlider.value - targetValue) < 0.01f)
            {
                loadingSlider.value = targetValue;
            }
        }

        loadingText.text = ((int)(loadingSlider.value * 100)).ToString() + "%";

        if ((int)(loadingSlider.value * 100) == 100)
        {
            //允许异步加载完毕后自动切换场景
            operation.allowSceneActivation = true;
        }
    }
}
