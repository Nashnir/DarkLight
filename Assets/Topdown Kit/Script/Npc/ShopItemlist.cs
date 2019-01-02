 /// <summary>
/// Npc shop.
/// This script use to create a shop to sell item
/// </summary>

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using TinyTeam.UI;

public class ShopItemlist : MonoBehaviour {
	
	public List<int> itemIDs = new List<int>();
    public static event Action<bool,List<int>> OnNpcTrigger;//跟进入NPC触发器有关


    void Start()
	{
        
        //if(this.gameObject.tag == "Untagged")
        //	this.gameObject.tag = "Npc_Shop";
      

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            //tipsBtn.gameObject.SetActive(true);
            if (OnNpcTrigger != null)
            {
                OnNpcTrigger(true, itemIDs);
            }
            //ipBtn.onClick.AddListener()
            //点击按钮
            //打开商店
            //设置商店里的物品
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //tipsBtn.gameObject.SetActive(true);
            if (OnNpcTrigger != null)
            {
                //itemIDs.Clear();
                OnNpcTrigger(false, itemIDs);
            }
        }
    }   
}