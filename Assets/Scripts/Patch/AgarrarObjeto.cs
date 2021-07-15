using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;

public class AgarrarObjeto : MonoBehaviour, IDragHandler
{
    public float z = 3.16f;

    public void OnDrag(PointerEventData eventData)
    {
        UnityEngine.Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = z;
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
