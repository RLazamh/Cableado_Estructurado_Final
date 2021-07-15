using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    Vector3 mPrevPo = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(KeyCode.T))
        {
            if (Input.GetKey(KeyCode.R))
            {
                Cursor.lockState = CursorLockMode.None;
                if (Input.GetMouseButton(0))
                {
                    mPosDelta = Input.mousePosition - mPrevPo;
                    if (Vector3.Dot(transform.up, Vector3.up) >= 0)
                    {
                        transform.Rotate(transform.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
                    }
                    else
                    {
                        transform.Rotate(transform.up, Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
                    }

                    transform.Rotate(Camera.main.transform.right, Vector3.Dot(mPosDelta, Camera.main.transform.up), Space.World);
                }
                mPrevPo = Input.mousePosition;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
