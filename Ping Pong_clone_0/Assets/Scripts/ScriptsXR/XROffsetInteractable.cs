
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetInteractable : XRGrabInteractable
{
    Vector3 initialAttachPos;
    Quaternion initialAttachLocalRot;


    void Start()
    {
        if (!attachTransform)
        {
            GameObject grab = new GameObject("Grab Pivot");
            grab.transform.SetParent(transform, false);
            attachTransform = grab.transform;
        }
        initialAttachPos = attachTransform.localPosition;
        initialAttachLocalRot = attachTransform.localRotation;
    } 


    protected override void OnSelectEntering(XRBaseInteractor interactor)
    {
        if (interactor is XRDirectInteractor)
        {
            attachTransform.position = interactor.transform.position;
            attachTransform.rotation = interactor.transform.rotation;

        }
        else
        {
            attachTransform.localPosition = initialAttachPos;
            attachTransform.localRotation = initialAttachLocalRot;
        }
        base.OnSelectEntering(interactor);
    }
}
