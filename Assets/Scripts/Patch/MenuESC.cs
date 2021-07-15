using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuESC : MonoBehaviour
{
    public void cambiarEscena()
    {
        SceneManager.LoadScene("Menu Principal");
    }
}
