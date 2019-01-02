using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TinyTeam.UI;
using UnityEngine.UI;

/// <summary>
/// 任务面板
/// </summary>
public class TaskPanel : TTUIPage
{
    private Dictionary<string, TaskItemUI> taskUIDic = new Dictionary<string, TaskItemUI>();//id,taskItem
    private Button ButtonTask1, ButtonTask2, ButtonTask3, ButtonKill1, ButtonKill2, ButtonGet1,ButtonGet2, ButtonThrow1, ButtonThrow2;

    [SerializeField]
    private GameObject content;//内容

    [SerializeField]
    private GameObject item;//列表项

    public TaskPanel():base(UIType.Normal,UIMode.DoNothing,UICollider.None)
    {
        uiPath = "UIPrefab/TaskPanel";
    }
    public override void Awake(GameObject go)
    {
        base.Awake(go);
        content = transform.Find("Viewport/Grid").gameObject;
        item = Resources.Load("Item") as GameObject;
        

        ButtonTask1 = transform.Find("ButtonTask1").GetComponent<Button>();
        ButtonTask2 = transform.Find("ButtonTask2").GetComponent<Button>();
        ButtonTask3 = transform.Find("ButtonTask3").GetComponent<Button>();
        ButtonKill1 = transform.Find("ButtonKill1").GetComponent<Button>();
        ButtonKill2 = transform.Find("ButtonKill2").GetComponent<Button>();
        ButtonGet1 = transform.Find("ButtonGet1").GetComponent<Button>();
        ButtonGet2 = transform.Find("ButtonGet2").GetComponent<Button>();
        ButtonThrow1 = transform.Find("ButtonThrow1").GetComponent<Button>();
        ButtonThrow2 = transform.Find("ButtonThrow2").GetComponent<Button>();

        ButtonOnclick();

        TaskManager.Instance.OnGetEvent += AddItem;
        TaskManager.Instance.OnRewardEvent += RemoveItem;
        TaskManager.Instance.OnFinishEvent += FinishTaskItem;
        TaskManager.Instance.OnCancelEvent += RemoveItem;
        TaskManager.Instance.OnCheckEvent += CheckTaskItem;
    }
    void ButtonOnclick()
    {
        ButtonTask1.onClick.AddListener(() => TaskManager.Instance.AcceptTask("T001"));
        ButtonTask2.onClick.AddListener(() => TaskManager.Instance.AcceptTask("T002"));
        ButtonTask3.onClick.AddListener(() => TaskManager.Instance.AcceptTask("T003"));

        ButtonKill1.onClick.AddListener(() => {
            TaskEventArgs e = new TaskEventArgs();
            e.id = "Enemy1";
            e.amount = 1;
            MesManager.Instance.Check(e);
        });

        ButtonKill2.onClick.AddListener(() => {
            TaskEventArgs e = new TaskEventArgs();
            e.id = "Enemy2";
            e.amount = 1;
            MesManager.Instance.Check(e);
        });

        ButtonGet1.onClick.AddListener(() => {
            TaskEventArgs e = new TaskEventArgs();
            e.id = "Item1";
            e.amount = 1;
            MesManager.Instance.Check(e);
        });

        ButtonGet2.onClick.AddListener(() => {
            TaskEventArgs e = new TaskEventArgs();
            e.id = "Item2";
            e.amount = 1;
            MesManager.Instance.Check(e);
        });

        ButtonThrow1.onClick.AddListener(() => {
            TaskEventArgs e = new TaskEventArgs();
            e.id = "Item1";
            e.amount = -1;
            MesManager.Instance.Check(e);
        });

        ButtonThrow2.onClick.AddListener(() => {
            TaskEventArgs e = new TaskEventArgs();
            e.id = "Item2";
            e.amount = -1;
            MesManager.Instance.Check(e);
        });
    }
    //void Start()
    //{
    //    if(!content)
    //    {
    //        content = transform.Find("Scroll View/Viewport/Content").gameObject;
    //    }
    //    if(!item)
    //    {
    //        item = Resources.Load("Item") as GameObject;
    //    } 

    //    TaskManager.Instance.OnGetEvent += AddItem;
    //    TaskManager.Instance.OnRewardEvent += RemoveItem;
    //    TaskManager.Instance.OnFinishEvent += FinishTaskItem;
    //    TaskManager.Instance.OnCancelEvent += RemoveItem;
    //    TaskManager.Instance.OnCheckEvent += CheckTaskItem;
    //}

    /// <summary>
    /// 更新任务UI
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void CheckTaskItem(TaskEventArgs e)
    {
        string tempTaskId = e.taskID;
        if(taskUIDic.ContainsKey(tempTaskId))
        {
            taskUIDic[tempTaskId].Modify(e);
        }
    }

    public void FinishTaskItem(TaskEventArgs e)
    {
        string tempTaskId = e.taskID;
        if (taskUIDic.ContainsKey(tempTaskId))
        {
            taskUIDic[tempTaskId].Finish(true);
        }
    }

    /// <summary>
    /// 添加列表项
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void AddItem( TaskEventArgs e)
    {
        if(taskUIDic.ContainsKey(e.taskID))
        {
            Debug.LogError("已经接受了这个任务！");
            return;
        }
        GameObject taskGobj = GameObject.Instantiate(item) as GameObject;  
        taskGobj.transform.SetParent(content.transform);
        taskGobj.transform.localScale = Vector3.one;
        taskGobj.transform.localPosition = Resources.Load<GameObject>("Item").transform.localPosition;

        TaskItemUI t = taskGobj.GetComponent<TaskItemUI>();
        taskUIDic.Add(e.taskID,t);
        t.Init(e);
    }

    /// <summary>
    /// 移除列表项
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void RemoveItem( TaskEventArgs e)
    {
        if (taskUIDic.ContainsKey(e.taskID))
        {
            TaskItemUI t = taskUIDic[e.taskID];
            taskUIDic.Remove(e.taskID);
            GameObject.Destroy(t.gameObject);
        }      
    }
}
