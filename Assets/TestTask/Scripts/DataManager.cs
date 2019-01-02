using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DataManager : MonoSingletion<DataManager>
{
    /// <summary>
    /// 总的数据字典，存放所有的任务
    /// </summary>
    private Dictionary<string, Task> taskDic = new Dictionary<string, Task>();//id,task


    public static Dictionary<string, Task> myTaskDic = new Dictionary<string, Task>();//id,task

    /// <summary>
    /// 任务数据
    /// </summary>
    public TextAsset mTextAsset;

   
    void Awake()
    {
        if (mTextAsset == null)
        {
            mTextAsset = (TextAsset)Resources.Load("TXT/AllTask", typeof(TextAsset));
        }
        taskDic = JsonConvert.DeserializeObject<Dictionary<string, Task>>(mTextAsset.text);  
    }

    public Task GetTaskByID(string taskID)
    {
        if (taskDic.ContainsKey(taskID))
        {
            Task t = taskDic[taskID];
            return t;
        }
        else
        {
            Debug.LogError("不存在该任务！！");
            return null;
        }
    }
}
