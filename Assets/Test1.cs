using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Test1:MonoBehaviour
{
    //public Dictionary<string, Task1> taskDic = new Dictionary<string, Task1>();
    public Dictionary<int, BB> bbDic = new Dictionary<int, BB>();

    public TextAsset mTextAsset;

    void Start()
    {

        //TaskCondition tc = new TaskCondition("E1", 0, 2);
        //TaskCondition tc1 = new TaskCondition("E2", 0, 3);
        //List<TaskCondition> tL = new List<TaskCondition>();
        //tL.Add(tc);
        //tL.Add(tc1);

        //TaskReward tr = new TaskReward("r1", 10);
        //TaskReward tr1 = new TaskReward("r2", 30);
        //List<TaskReward> trL = new List<TaskReward>();
        //trL.Add(tr);
        //trL.Add(tr1);


        //Task1 t1 = new Task1("t001", "村庄的宁静", "请去把村长弄死", tL, trL);

        //string ssss = JsonConvert.SerializeObject(t1);

        //Debug.Log(ssss);

        //bbDic.Add(1, new BB());
        //bbDic.Add(2, new BB() { a = 11, b = "dagfadg" });
        //string s = JsonConvert.SerializeObject(bbDic);
        //Debug.Log(s);

        //taskDic = JsonConvert.DeserializeObject<Dictionary<string, Task1>>(mTextAsset.text);

        //Debug.Log(taskDic.Count);

        //JObject jo = (JObject)JsonConvert.DeserializeObject(mTextAsset.text);
        //var jo = JObject.Parse(mTextAsset.text);

////        Debug.Log(jo.Count);


//        var ss  = jo["T001"][0].Value<string>();

//        Debug.Log(ss);
        //foreach (KeyValuePair<string, JToken> kv in jo)
        //{
        //    //Task1 t1 = kv.Value.ToObject<Task1>();

        //    //string sss = kv.Value.Last.ToString();

        //    //TaskReward tr1 = new TaskReward()
        //    //TaskReward tr = kv.Value.Last.ToObject<TaskReward>();
        //    //Debug.Log(sss);
        //    // Debug.Log(sss);
        //    // Debug.Log(t1.taskName);
        //    //var ss = jo["taskName"].Value<string>();
        //    //Debug.Log(ss);
        //    //Response
        //}
    }
}

public class AA 
{
    public Dictionary<int, BB> bbDic = new Dictionary<int, BB>();
}

public class BB
{
    public int a=1;
    public string b="BBlei";
}