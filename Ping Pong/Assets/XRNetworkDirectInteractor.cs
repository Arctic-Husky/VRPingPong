using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Mirror;
using System;

public class XRNetworkDirectInteractor : NetworkBehaviour
{
    public void SetAuthoraty(NetworkIdentity item)
    {
        CmdAssignClientAuthority(item);
    }
    public void RemoveAuthoraty(NetworkIdentity item)
    {
        CmdRemoveAuthoratyClientAuthority(item);
    }
    [Command]
    void CmdRemoveAuthoratyClientAuthority(NetworkIdentity item)
    {
        item.RemoveClientAuthority();
    }

    [Command]
    void CmdAssignClientAuthority(NetworkIdentity item)
    {
        item.AssignClientAuthority(connectionToClient);
    }
}
