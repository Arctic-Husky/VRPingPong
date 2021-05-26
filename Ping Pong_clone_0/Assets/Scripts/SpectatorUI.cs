using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpectatorUI : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] TMP_Text cameraText;
    [SerializeField] GameObject camera1;
    [SerializeField] GameObject camera2;
    [SerializeField] GameObject camera3;
    [SerializeField] GameObject camera4;

    public void ChangeCamera(int camera)
    {
        if (camera==1)
        {
            cameraText.text = "Camera 1";
            camera1.SetActive(true);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(false);
;       }
        if (camera == 2)
        {
            cameraText.text = "Camera 2";
            camera2.SetActive(true);
            camera1.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(false);
        }
        if (camera == 3)
        {
            cameraText.text = "Camera 3";
            camera3.SetActive(true);
            camera2.SetActive(false);
            camera1.SetActive(false);
            camera4.SetActive(false);
        }
        if (camera == 4)
        {
            cameraText.text = "Free Camera Movement";
            camera4.SetActive(true);
            camera2.SetActive(false);
            camera1.SetActive(false);
            camera3.SetActive(false);
        }
    }
}
