using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtroller:MonoBehaviour {

    private static GameCtroller _instance = null;
    public string nextScenceName;//下个要加载场景的名字
    //共有的唯一的，全局访问点
    public static GameCtroller Instance
    {
        get
        {
            if (_instance == null)
            {    //查找场景中是否已经存在单例
                _instance = GameObject.FindObjectOfType<GameCtroller>();
                if (_instance == null)
                {    //创建游戏对象然后绑定单例脚本
                    GameObject go = new GameObject("Singleton");
                    _instance = go.AddComponent<GameCtroller>();
                   
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {    //防止存在多个单例
        DontDestroyOnLoad(gameObject);
        if (_instance == null)
            _instance = this;
        else
            Destroy(this);
    }
   
}
