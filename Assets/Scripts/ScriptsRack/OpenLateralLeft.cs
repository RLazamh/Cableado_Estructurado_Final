using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLateralLeft : MonoBehaviour
{
    public float Distance;
    public Animator anim;
    public GameObject ObjectFound;
    private bool isOpen = false;


    // Start is called before the first frame update
    void Start()
    {
        ObjectFound = GameObject.Find("Canvas").transform.Find("OpenCloseUI").gameObject;
        anim = GetComponent<Animator>();
        ObjectFound.transform.GetChild(0).gameObject.SetActive(false);
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
                ObjectFound.transform.GetChild(0).gameObject.SetActive(true);
                ObjectFound.transform.GetChild(3).gameObject.SetActive(true);
            }
            else
            {
                ObjectFound.transform.GetChild(0).gameObject.SetActive(false);
                ObjectFound.transform.GetChild(3).gameObject.SetActive(false);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (Distance <= 40)
                {
                    anim.Play("OpenColumnL");
                    isOpen = !isOpen;
                    ObjectFound.transform.GetChild(0).gameObject.SetActive(false);
                    ObjectFound.transform.GetChild(3).gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if (Distance <= 40)
            {
                ObjectFound.transform.GetChild(2).gameObject.SetActive(true);
                ObjectFound.transform.GetChild(3).gameObject.SetActive(true);
            }
            else
            {
                ObjectFound.transform.GetChild(2).gameObject.SetActive(false);
                ObjectFound.transform.GetChild(3).gameObject.SetActive(false);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (Distance <= 40)
                {
                    anim.Play("OpenColumnL 0");
                    isOpen = !isOpen;
                    ObjectFound.transform.GetChild(2).gameObject.SetActive(false);
                    ObjectFound.transform.GetChild(3).gameObject.SetActive(false);
                }
            }
        }
    }

    void OnMouseExit()
    {
        ObjectFound.transform.GetChild(0).gameObject.SetActive(false);
        ObjectFound.transform.GetChild(2).gameObject.SetActive(false);
        ObjectFound.transform.GetChild(3).gameObject.SetActive(false);
    }

}
