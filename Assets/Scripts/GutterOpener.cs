using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GutterOpener : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject OpenActionDisplay;
    public GameObject CloseActionDisplay;
    public GameObject ExtraCursor;
    public Animator anima;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
        OpenActionDisplay.SetActive(false);
    }

    // Update is called once per frame

    void OnMouseOver()
    {
        if (!isOpen)
        {
            OpenActionDisplay.SetActive(true);
            ExtraCursor.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                anima.Play("OpenGutter");
                isOpen = !isOpen;
                OpenActionDisplay.SetActive(false);
                ExtraCursor.SetActive(false);
            }
        }
        else
        {
            CloseActionDisplay.SetActive(true);
            ExtraCursor.SetActive(false);
            if (Input.GetMouseButtonDown(0))
            {
                anima.Play("OpenGutter 0");
                isOpen = !isOpen;
                CloseActionDisplay.SetActive(false);
                ExtraCursor.SetActive(false);
            }
        }
    }

    void OnMouseExit()
    {
        OpenActionDisplay.SetActive(false);
        ExtraCursor.SetActive(false);
        CloseActionDisplay.SetActive(false);
    }
}