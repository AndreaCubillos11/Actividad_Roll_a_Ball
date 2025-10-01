using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody rb;
    public float speed;
    public Transform particulas;
    private ParticleSystem systemParticulas;
    private Vector3 posicion; 
    private AudioSource audioRecoleccion;
    private int contador = 0; 
    public int cubosParaGanar = 12;
    public Text textoContador; 
    


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        systemParticulas = particulas.GetComponent<ParticleSystem>();
        systemParticulas.Stop();

        audioRecoleccion = GetComponent<AudioSource> ();
        
        textoContador.text = "Contador: " + contador.ToString();

    }
    
  
    void Update()
    {
    
    }

    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        rb.AddForce(movimiento * speed);
    }

    void OnTriggerEnter (Collider other){

        audioRecoleccion.Play();

        
        if (other.gameObject.CompareTag("Recolectable"))
        {
            
            contador = contador + 1;

            textoContador.text = "Contador: " + contador.ToString();

            posicion = other.gameObject.transform.position;
            particulas.position = posicion;

            
            systemParticulas.Play();

            other.gameObject.SetActive(false);

            // Se comprueba si la cantidad de cubos recolectados es igual o mayor a la meta
            if (contador >= cubosParaGanar)
            {
                // Se ejecuta esta lógica solo si la condición se cumple
                Debug.Log("¡Has recolectado todos los cubos!");

                // Se carga la siguiente escena 
                SceneManager.LoadScene(1);
            }
        }
    }
}