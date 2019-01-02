using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class xiecheng : MonoBehaviour {
    public Slider s;
	// Use this for initialization
	void Start () {
        Debug.Log("111");
        StartCoroutine(testc());
        Debug.Log("正在下载");
	}
    WWW w;
    string url = "http://img18.3lian.com/d/file/201710/06/a16f372d86431558c0ab0a613c50ef0b.jpg";
   IEnumerator testc()
    {
         w = new WWW(url);
        s.value = w.progress;
       yield return w;
        //StartCoroutine(ss());
      GameObject g=  GameObject.CreatePrimitive(PrimitiveType.Plane);
        g.GetComponent<MeshRenderer>().material.mainTexture = w.texture;
    }
    //IEnumerator ss()
    //{
    //    if (w.progress>0.9)
    //    {
    //        s.value = 1;
    //    }
    //    yield break;
    //}
    private void Update()
    {
        s.value = w.progress;
    }
}
