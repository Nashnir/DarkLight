using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;

public class MainGameSetCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TTUIPage.ShowPage<MainPanel>();
    }

    // Update is called once per frame
    bool isTaskPanelActive = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!isTaskPanelActive)
            {
                TTUIPage.ShowPage<TaskPanel>();
                isTaskPanelActive = true;
            }
            else
            {
                TTUIPage.ClosePage<TaskPanel>();
                isTaskPanelActive = false;
            }
        }
    }
}
