using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItem : MonoBehaviour

{

    private Vector3 mOffset;
    private float mZCoord;


    public void Update()
    {
        if (!Input.GetKey(KeyCode.R))
        {
            if (Input.GetKey(KeyCode.T))
            {
                Cursor.lockState = CursorLockMode.None;

                if (Input.GetMouseButton(0))
                {
                    mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
                    // Store offset = gameobject world pos - mouse world pos
                    mOffset = gameObject.transform.position - GetMouseAsWorldPoint(mZCoord);

                    transform.position = GetMouseAsWorldPoint(mZCoord);// + mOffset;
                                                                       //transform.position = new Vector3(0.5f,0.3f,0.15f);
                   // Debug.Log(transform.position);
                }
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;

            }
        }
    }

    private Vector3 GetMouseAsWorldPoint(float mZCoord)
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world points


        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    /*void OnMouseDrag()
    {
        if (active)
        {
            transform.position = GetMouseAsWorldPoint() + mOffset;
        }
    }*/
}
