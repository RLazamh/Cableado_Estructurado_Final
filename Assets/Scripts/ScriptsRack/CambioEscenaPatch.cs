using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaPatch : MonoBehaviour
{
    private const float DOUBLE_CLICK_TIME = .2f;
    private Ray ray;
    public RaycastHit hit;
    public Camera cam;
    private float lastClickTime;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            float timeSinceLastClick = Time.time - lastClickTime;
            if(timeSinceLastClick <= DOUBLE_CLICK_TIME)
            {
                //Double Click
                ray = cam.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    if (hit.collider.tag == "Patch_1RU")
                    {
                        Debug.Log("Detectó Collider Patch1");
                        SceneManager.LoadScene("Conexion");
                        Cursor.lockState = CursorLockMode.Confined;
                    }else if(hit.collider.tag == "Patch_2RU")
                    {
                        Debug.Log("Detectó Collider Patch2");
                        SceneManager.LoadScene("ConexionPatch2");
                        Cursor.lockState = CursorLockMode.Confined;
                    }
                }
            }
            lastClickTime = Time.time;
        }
    }
}
