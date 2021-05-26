using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatSetVisible : MonoBehaviour
{
    [SerializeField]
    GameObject menuBox;
    
    void Start()
    {
        
        menuBox.GetComponent<ChatNetworkSetVisible>().OnMessage += menuBox_OnMessage;
        
    }

    private void menuBox_OnMessage(bool cu)
    {
        gameObject.SetActive(cu);
    }

}
