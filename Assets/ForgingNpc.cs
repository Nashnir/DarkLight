using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using System;
public class ForgingNpc : MonoBehaviour
{
    public static event Action<bool> isForgingNpc;
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        isForgingNpc(true);
    }
    private void OnTriggerExit(Collider other)
    {
        isForgingNpc(false);
    }
}
