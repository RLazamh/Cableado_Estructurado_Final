using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;

public class AgarrarObjetoPatch2 : MonoBehaviour, IDragHandler
{
    public float z = 3.16f;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            z = 3.16f;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            z = 2.70f;
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        UnityEngine.Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = z;
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
