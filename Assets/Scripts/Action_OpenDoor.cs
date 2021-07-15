using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_OpenDoor : MonoBehaviour
{

    public float smooth = 2.0f;
    public float DoorOpenAngle = 90.0f;
    private bool open;
    private bool enter;
    private Vector3 defaultRot;
    private Vector3 openRot;



    public float Distance;
    public GameObject ActionDisplay;
    public GameObject ExtraCursor;
    public GameObject Door;

   void Start()
    {
        defaultRot = transform.eulerAngles;
        openRot = new Vector3(defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);
    }
    // Update is called once per frame
    void Update()
    {
        Distance = PlayerCasting.DistanceFromTarget;

        if (open)
        {
            //Open door
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
        }
        else
        {
            //Close door
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
        }

        if (Input.GetMouseButtonDown(0) && enter)
        {
            open = !open;
        }

    }

    void OnMouseOver(){
        if(Distance <= 15){
            ActionDisplay.SetActive(true);
            ExtraCursor.SetActive(true);
        }else{
            ActionDisplay.SetActive(false);
            ExtraCursor.SetActive(false);
        }

        if(Input.GetMouseButtonDown(0)){
            if(Distance <= 15){
                ActionDisplay.SetActive(false);
                ExtraCursor.SetActive(false);
            }
        }
    }

    void OnMouseExit(){
        ActionDisplay.SetActive(false);
        ExtraCursor.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enter = true;
        }
    }

    //Deactivate the Main function when player is go away from door
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enter = false;
        }
    }
}
