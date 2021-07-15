using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{

    public  Material[] BodyColorMat;
    Material CurrMat;
    Renderer r_renderer;
    public GameObject PanelObject;

    // Use this for initialization
    void Start()
    {

        r_renderer = this.GetComponent<Renderer>();
        

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void WhiteOrange()
    {
        r_renderer.material = BodyColorMat[0];
        CurrMat = r_renderer.material;
        PanelObject.SetActive(false);

    }

    public void Orange()
    {
        r_renderer.material = BodyColorMat[1];
        CurrMat = r_renderer.material;
        PanelObject.SetActive(false);
    }


    public void WitheGreen()
    {
        r_renderer.material = BodyColorMat[2];
        CurrMat = r_renderer.material;
        PanelObject.SetActive(false);
    }


    public void Blue()
    {
        r_renderer.material = BodyColorMat[3];
        CurrMat = r_renderer.material;
        PanelObject.SetActive(false);
    }


        public void WhiteBlue()
    {
        r_renderer.material = BodyColorMat[4];
        CurrMat = r_renderer.material;
        PanelObject.SetActive(false);
    }

        public void Green()
    {
        r_renderer.material = BodyColorMat[5];
        CurrMat = r_renderer.material;
        PanelObject.SetActive(false);
    }

        public void WhiteBrown()
    {
        r_renderer.material = BodyColorMat[6];
        CurrMat = r_renderer.material;
        PanelObject.SetActive(false);
    }
    
        public void Brown()
    {
        r_renderer.material = BodyColorMat[7];
        CurrMat = r_renderer.material;
        PanelObject.SetActive(false);
    }

    void OnMouseDown(){
        PanelObject.SetActive(true);
  
    }
}
