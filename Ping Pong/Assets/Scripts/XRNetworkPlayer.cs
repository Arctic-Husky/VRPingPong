using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class XRNetworkPlayer : NetworkBehaviour
{
    [SerializeField] GameObject head;
    private void Start()
    {
        if (isLocalPlayer)
        {
            head.SetActive(false);
            print("fasffs");
        }
    }
}
