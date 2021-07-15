using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationQuit : MonoBehaviour
{
    public void ExitApp()
    {
        Application.Quit();
        Debug.Log("Hasta Pronto");
    }
}
