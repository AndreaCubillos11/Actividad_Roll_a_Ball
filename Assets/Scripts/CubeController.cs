using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
}
