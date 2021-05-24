using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCameraReference : MonoBehaviour
{
    [SerializeField]
    Camera camera;
    Canvas canvas;
    void Awake()
    {
        camera = Camera.main;
        canvas = GetComponent<Canvas>();
        canvas.worldCamera=camera;
    }
}
