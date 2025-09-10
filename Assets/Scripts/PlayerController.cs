using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody rb;
    public float speed;
    public Transform particulas;
    private ParticleSystem systemParticulas;
    private Vector3 posicion; 
    private AudioSource audioRecoleccion;
    
    // Esta es tu variable para el contador
    private int contador = 0; 

    // Aquí puedes definir cuántos cubos necesitas para ganar.
    public int cubosParaGanar = 12;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        systemParticulas = particulas.GetComponent<ParticleSystem>();
        systemParticulas.Stop();

        audioRecoleccion = GetComponent<AudioSource> ();
    }
    
    // El método Update y FixedUpdate están correctos
    void Update()
    {
        // No hay necesidad de código aquí para el contador
    }

    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        rb.AddForce(movimiento * speed);
    }

    void OnTriggerEnter (Collider other){

        audioRecoleccion.Play();

        // Aquí se comprueba si el objeto con el que colisionas tiene la etiqueta correcta
        if (other.gameObject.CompareTag("Recolectable"))
        {
            // Ahora, el contador solo se incrementa si el objeto es recolectable
            contador = contador + 1;

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