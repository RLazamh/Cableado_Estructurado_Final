using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RJ45_CanvasActivate : MonoBehaviour
{
    public GameObject canvasObject;
    void Start()
    {
        canvasObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
