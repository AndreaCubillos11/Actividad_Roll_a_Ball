using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody rb;
    public float speed;
    public Transform particulas;
    private ParticleSystem systemParticulas;
    private Vector3 posicion; 

    void Start()
    {
        rb=GetComponent<Rigidbody>();// Obtener un componente del objeto asociado  

        systemParticulas = particulas.GetComponent<ParticleSystem> ();

        systemParticulas.Stop();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate(){

        // se ejcuta muchas veces por segundo
        float moveHorizontal=Input.GetAxis("Horizontal");
        float moveVertical=Input.GetAxis("Vertical");

        Vector3 movimiento=new Vector3(moveHorizontal,0.0f,moveVertical);
        
        rb.AddForce(movimiento*speed);
    }

    void OnTriggerEnter (Collider other){

        if (other.gameObject.CompareTag ("Recolectable")){
            //el objeto es recolectable
            other.gameObject.SetActive (false);
        } else {
            //el objeto No es recolectable
        }
    }
}