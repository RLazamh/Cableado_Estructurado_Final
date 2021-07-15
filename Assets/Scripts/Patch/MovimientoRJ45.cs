using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using System;
public class MovimientoRJ45 : MonoBehaviour
{
    #region Private Properties
    float ZPosition;
    float YPosition;
    Vector3 Offset;
    bool Dragging;
    #endregion


    #region Inspector Variables
    public Camera MainCamera;
    [Space]
    [SerializeField]
    public UnityEvent OnBeginDrag;
    [SerializeField]
    public UnityEvent OnEndDrag;
    #endregion

    #region Unity Function
    //Use this for initialization
    void Start()
    {
        ZPosition = MainCamera.WorldToScreenPoint(transform.position).z;
        YPosition = MainCamera.WorldToScreenPoint(transform.position).y;
    }

    //Update us called once per frame
    void Update()
    {
        if (Dragging)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, YPosition, ZPosition);
            transform.position = MainCamera.ScreenToWorldPoint(position + new Vector3(Offset.x, Offset.y));
        }
    }

    void OnMouseDown()
    {
        if (!Dragging)
        {
            BeginDrag();     
        }
    }

    private void OnMouseUp()
    {
        EndDrag();
    }
    #endregion

    #region User Interface
    public void BeginDrag()
    {
        OnBeginDrag.Invoke();
        Dragging = true;
        Offset = MainCamera.WorldToScreenPoint(transform.position) - Input.mousePosition;
    }

    public void EndDrag()
    {
        OnEndDrag.Invoke();
        Dragging = false;
    }
    #endregion
}
