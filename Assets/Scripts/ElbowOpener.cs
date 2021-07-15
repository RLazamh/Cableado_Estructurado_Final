using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElbowOpener : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anima;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame

    void OnMouseOver()
    {
        if (!isOpen)
        {
           
            if (Input.GetMouseButtonDown(0))
            {
                anima.Play("OpenElbowAnim");
                isOpen = !isOpen;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                anima.Play("OpenElbowAnim 0");
                isOpen = !isOpen;
            }
        }
    }
}
