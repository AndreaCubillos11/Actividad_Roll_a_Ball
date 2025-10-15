using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer> ().material;
        material.color = Color.black; 
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
