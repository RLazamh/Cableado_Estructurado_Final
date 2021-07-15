using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCeiling : MonoBehaviour
{
    
    public float Distance;
    public GameObject ActionDisplay;
    public GameObject ExtraCursor;
    public Animator anim;
    

    void Start()
    {
        ActionDisplay.SetActive(false);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Distance = PlayerCasting.DistanceFromTarget;

    }
    
    void OnMouseOver(){
        if(Distance <= 40){
            ActionDisplay.SetActive(true);
            ExtraCursor.SetActive(true);
        }else{
            ActionDisplay.SetActive(false);
            ExtraCursor.SetActive(false);
        }

        if(Input.GetMouseButtonDown(0)){
            if(Distance <= 40){
                anim.Play("OpenCeiling");
                ActionDisplay.SetActive(false);
                ExtraCursor.SetActive(false);
            }
        }
    }
    void OnMouseExit(){
        ActionDisplay.SetActive(false);
        ExtraCursor.SetActive(false);
    }
}
