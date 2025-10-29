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
    Animator anim;
    public GameObject poder;
    


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        systemParticulas = particulas.GetComponent<ParticleSystem>();
        systemParticulas.Stop();

        audioRecoleccion = GetComponent<AudioSource> ();
        
        textoContador.text = "Contador: " + contador.ToString();

        anim = GetComponent<Animator> ();


    }
    

    void Update()
    {
        if (Input.GetButtonDown ("Fire1"))
        Animar();  
    }

    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        rb.AddForce(movimiento * speed);
    }

    void OnTriggerEnter (Collider other){


        audioRecoleccion.Play();

        StartCoroutine (DetenerParticulas (systemParticulas));

        
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

        public IEnumerator DetenerParticulas(ParticleSystem part){

        yield return new WaitForSecondsRealtime(5);

        part.Stop();
    }

    public void Animar(){

        //anim.SetBool ( "animar", true);
        StartCoroutine(Reiniciar());
    }

    public IEnumerator Reiniciar(){

        anim.SetBool ("animar", true);
        yield return new WaitForSecondsRealtime(0.6f);
        poder.transform.position = transform.position;
        poder.SendMessage ("Shoot");
        anim.SetBool("animar", false);
    }


}