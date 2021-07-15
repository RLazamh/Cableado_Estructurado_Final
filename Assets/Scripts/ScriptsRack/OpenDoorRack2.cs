using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoorRack2 : MonoBehaviour
{
    public float Distance;
    //public GameObject OpenActionDisplay;
    //public GameObject CloseActionDisplay;
    //public GameObject ExtraCursor;
    public Animator anim;
    public GameObject ObjectFound;
    private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        ObjectFound = GameObject.Find("Canvas");
        anim = GetComponent<Animator>();
        ObjectFound.transform.GetChild(1).gameObject.SetActive(false);
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
                ObjectFound.transform.GetChild(1).gameObject.SetActive(true);
                ObjectFound.transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                ObjectFound.transform.GetChild(1).gameObject.SetActive(false);
                ObjectFound.transform.GetChild(2).gameObject.SetActive(false);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (Distance <= 40)
                {
                    anim.Play("OpenDoorRight");
                    isOpen = !isOpen;
                    ObjectFound.transform.GetChild(1).gameObject.SetActive(false);
                    ObjectFound.transform.GetChild(2).gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if (Distance <= 40)
            {
                ObjectFound.transform.GetChild(4).gameObject.SetActive(true);
                ObjectFound.transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                ObjectFound.transform.GetChild(4).gameObject.SetActive(false);
                ObjectFound.transform.GetChild(2).gameObject.SetActive(false);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (Distance <= 40)
                {
                    anim.Play("OpenDoorRight 0");
                    isOpen = !isOpen;
                    ObjectFound.transform.GetChild(4).gameObject.SetActive(false);
                    ObjectFound.transform.GetChild(2).gameObject.SetActive(false);
                }
            }
        }
    }

    void OnMouseExit()
    {
        ObjectFound.transform.GetChild(1).gameObject.SetActive(false);
        ObjectFound.transform.GetChild(2).gameObject.SetActive(false);
        ObjectFound.transform.GetChild(4).gameObject.SetActive(false);
    }
}
