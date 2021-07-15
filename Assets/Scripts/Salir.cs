using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salir : MonoBehaviour {

	public void MetodoSalir()
    {
        Application.Quit();
        Debug.Log("Se ha salido del juego");
    }
}
