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
    public static event Action<bool,List<int>> OnNpcTrigger;//������NPC�������й�


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
            //�����ť
            //���̵�
            //�����̵������Ʒ
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