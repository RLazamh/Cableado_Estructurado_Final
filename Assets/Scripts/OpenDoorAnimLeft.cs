using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorAnimLeft : MonoBehaviour
{
    public float Distance;
    public GameObject OpenActionDisplay;
    public GameObject CloseActionDisplay;
    public GameObject ExtraCursor;
    public Animator anim;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        OpenActionDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Distance = PlayerCasting.DistanceFromTarget;
    }
    void OnMouseOver()
    {
        if (!isOpen)
        {
            if (Distance <= 40)
            {
                OpenActionDisplay.SetActive(true);
                ExtraCursor.SetActive(true);
            }
            else
            {
                OpenActionDisplay.SetActive(false);
                ExtraCursor.SetActive(false);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (Distance <= 40)
                {
                    anim.Play("OpenDoorLeft");
                    isOpen = !isOpen;
                    OpenActionDisplay.SetActive(false);
                    ExtraCursor.SetActive(false);
                }
            }
        }
        else
        {
            if (Distance <= 40)
            {
                CloseActionDisplay.SetActive(true);
                ExtraCursor.SetActive(true);
            }
            else
            {
                CloseActionDisplay.SetActive(false);
                ExtraCursor.SetActive(false);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (Distance <= 40)
                {
                    anim.Play("OpenDoorLeft 0");
                    isOpen = !isOpen;
                    CloseActionDisplay.SetActive(false);
                    ExtraCursor.SetActive(false);
                }
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