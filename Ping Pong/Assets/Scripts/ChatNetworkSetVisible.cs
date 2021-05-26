using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatNetworkSetVisible : MonoBehaviour
{
    public event Action<bool> OnMessage;


    public void SetVisible(bool isVis)
    {
        OnMessage.Invoke(isVis);
    }
}
