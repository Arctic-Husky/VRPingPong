using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;
using System;
using UnityEngine.XR;

public class XRNetworkPlayer : NetworkBehaviour
{
    //[SerializeField] GameObject head;
    [SerializeField] Transform leftXRMultiplayerHand;
    [SerializeField] Transform rightXRMultiplayerHand;
    [SerializeField] Transform XRMultiplayerHead;
    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;
    private void Start()
    {
        XRRig rig = FindObjectOfType<XRRig>();
        headRig = rig.transform.Find("Camera Offset/Main Camera");
        leftHandRig = rig.transform.Find("Camera Offset/LeftHand Controller");
        rightHandRig = rig.transform.Find("Camera Offset/RightHand Controller");
    }
    private void Update()
    {
        
        if (isLocalPlayer)
        {
            
            rightXRMultiplayerHand.gameObject.SetActive(false);
            leftXRMultiplayerHand.gameObject.SetActive(false);
            XRMultiplayerHead.gameObject.SetActive(false);

            MapPosition(leftXRMultiplayerHand, leftHandRig);
            MapPosition(rightXRMultiplayerHand, rightHandRig);
            MapPosition(XRMultiplayerHead, headRig);
        }
    }

    private void MapPosition(Transform target, Transform rigTransform)
    {
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }
}
