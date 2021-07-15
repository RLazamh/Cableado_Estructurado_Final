using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RJ45_StandarVerification : MonoBehaviour
{
    public  Material[] BodyColorMat;
    public GameObject[] CablesArr;
    public GameObject text568A;
    public GameObject text568B;
    public GameObject textNoStandar;
    public GameObject saveButton;
    public GameObject btnStrike;
    InventoryManager inventory;

   

    public void verifyStandar(){
        if(CablesArr[0].GetComponent<MeshRenderer>().material.color == BodyColorMat[0].color
            &&CablesArr[1].GetComponent<MeshRenderer>().material.color == BodyColorMat[1].color
            &&CablesArr[2].GetComponent<MeshRenderer>().material.color == BodyColorMat[2].color
            &&CablesArr[3].GetComponent<MeshRenderer>().material.color == BodyColorMat[3].color
            &&CablesArr[4].GetComponent<MeshRenderer>().material.color == BodyColorMat[4].color
            &&CablesArr[5].GetComponent<MeshRenderer>().material.color == BodyColorMat[5].color
            &&CablesArr[6].GetComponent<MeshRenderer>().material.color == BodyColorMat[6].color
            &&CablesArr[7].GetComponent<MeshRenderer>().material.color == BodyColorMat[7].color){
            text568A.SetActive(true);
        }else if(CablesArr[0].GetComponent<MeshRenderer>().material.color == BodyColorMat[2].color
            &&CablesArr[1].GetComponent<MeshRenderer>().material.color == BodyColorMat[5].color
            &&CablesArr[2].GetComponent<MeshRenderer>().material.color == BodyColorMat[0].color
            &&CablesArr[3].GetComponent<MeshRenderer>().material.color == BodyColorMat[3].color
            &&CablesArr[4].GetComponent<MeshRenderer>().material.color == BodyColorMat[4].color
            &&CablesArr[5].GetComponent<MeshRenderer>().material.color == BodyColorMat[1].color
            &&CablesArr[6].GetComponent<MeshRenderer>().material.color == BodyColorMat[6].color
            &&CablesArr[7].GetComponent<MeshRenderer>().material.color == BodyColorMat[7].color)
        {
             text568B.SetActive(true);;
        }else{
             textNoStandar.SetActive(true);
        }
    }

    public void saveWire(){
        GameObject RJ45Copy = Instantiate(GameObject.Find("RJ45wire"));

        if(text568A.activeInHierarchy == true){
            RJ45Copy.tag = "Rj45_568A";
        }
        else if(text568B.activeInHierarchy == true){
            RJ45Copy.tag = "Rj45_568B";
        }
        else{
            RJ45Copy.tag = "Rj45_";
        }
        
        DontDestroyOnLoad(RJ45Copy);
        SceneManager.LoadScene(4);
    }

    public void saveButtonF(){
        saveButton.SetActive(true);
        btnStrike.SetActive(false);
    }
}
