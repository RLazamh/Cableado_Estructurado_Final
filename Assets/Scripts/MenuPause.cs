using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public GameObject optionsMenu;
    public int count = 0;

    public void Start()
    {
        optionsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            count++;           
            optionsMenu.gameObject.SetActive(!optionsMenu.gameObject.activeSelf);
            if (count%2 == 1)
            {
                Cursor.lockState = CursorLockMode.Confined;                
            }else if(count % 2 == 0){
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

    }

  
}
