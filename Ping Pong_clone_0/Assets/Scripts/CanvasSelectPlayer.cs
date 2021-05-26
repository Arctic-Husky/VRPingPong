using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class CanvasSelectPlayer : NetworkBehaviour
{
    [Header("Referencias")]
    [SerializeField] GameObject canvasSelectPlayer;
    public override void OnStartClient()
    {
        base.OnStartClient();
        canvasSelectPlayer.SetActive(true);
    }

}
