using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine; 


public class CubeController : MonoBehaviour
{

    Material material;
    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer> ().material;
        material.color = Color.black; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(sliderX.value, sliderY.value, sliderZ.value);
    }

    public void RotarCubo (){
        transform.Rotate (new Vector3 (45,45,45));
    }

    public void EscalarCubo (float value){

        transform.localScale = new Vector3 (value, value, value); 
    }

    public void cambiarColor(int opcion){
    
        Debug.Log ("Parámetro: "+ opcion);

        switch(opcion){

        case 0: 
        Debug.Log("Opción 1");

        material.color = Color.black;
        break;

        case 1: 
        Debug.Log("Opción 2");

        material.color = Color.red;
        break;

        case 2: 
        Debug.Log("Opción 3");

        material.color = Color.yellow;
        break;

    }//cierra switch

    }

    public void ResetCube()
{
    // Posición (0,0,0)
    transform.position = new Vector3(0, 0, 0);

    // Rotación (0,0,0) 
    transform.rotation = new Quaternion(0, 0, 0, 1); 
    // Reinicia la rotación del cubo a su posición original (x, y, z = 0; w = 1 mantiene la orientación inicial)

    // Escala (1,1,1)
    transform.localScale = new Vector3(1, 1, 1);

    // Sliders regresan a su posición inicial 0
    sliderX.value = 0;
    sliderY.value = 0;
    sliderZ.value = 0;
}

}
