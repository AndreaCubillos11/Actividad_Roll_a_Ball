using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDisparo : MonoBehaviour
{

    public GameObject Player;
    public float TiempoEntreDisparos = 1f; // que tanto tiempo se dibuja el rayo en pantalla
    public float rango = 100f; // que tan lejos llega el rayo 


    float timer; // cuando debe dejar de dibujar el rayo
    Ray shootRay; // 
    RaycastHit shootHit; //
    int shootableMask; //guarda el identificador de la capa
    LineRenderer gunLine; //dibuja el rayo
    Light gunLight; //crea la iluminación del rayo
    float effctsDisplayTime = 1.2f; //que tanto tiempo dura dibujado el rayo

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      timer += Time.deltaTime; //cronometro

      if(timer >= TiempoEntreDisparos * effctsDisplayTime) // verifica que el rayo se dibuje 1.2 segundos
      {
       DisableEffects (); //desactiva el dibujo del rayo
      }

    }

    void Awake(){ //se llama antes del método start y se llama cada que el script se desactiva 

        shootableMask = LayerMask.GetMask ("Shootable"); //se obtiene una referencia a la capa shootable ( se obtiene un id y se guarda)
        gunLine = GetComponent<LineRenderer> (); //se obtinene referncia del rayo
        gunLight = GetComponent<Light>(); //se obtinene referncia de la iluminación 
    }

    void Shoot(){
        Vector3 ubicacion = new Vector3 (Player.transform.position.x,
        Player.transform.position.y + 1.1f,
        Player.transform.position.z); // A y se le suma 1.1 f para que el rayo salga más o menos del peho del avatar o de la alyura de la mano


        timer = 0f; //se vuelve 0 para empezar a cronometrar
        gunLine.enabled = true; //se activan para que se dibuje el rayo
        gunLight.enabled = true; // se activa para  que se active el efecto de luz
        shootRay.origin = ubicacion; // de donde sale el rayo
        shootRay.direction =transform.forward; //dirección del rayo, hacía dónde esté mirando el personaje
        gunLine.SetPosition (0, ubicacion); //dibujar la linea del rayo desde la ubicación del jugador

        if( Physics.Raycast (shootRay,out shootHit, rango, shootableMask)) //si en su trayectoria se encuentra con un objeto con esa capa , entra al if
        {
            Destroy(shootHit.collider.gameObject); //se accede al collider con el que se está impactando y con shootHit se verifica si está en la capa para destruirlo
            gunLine.SetPosition (1, shootHit.point); //el punto hasta donde se va a dibujar el rayo 

        }
        else
        {
            Debug.Log("No se impacto con ningún objeto");
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * rango); //sabe en donde el rayo impacto al cubo
        }
    }

    public void DisableEffects(){

        gunLine.enabled = false; // desactiva  el dibujo del rayo
        gunLight.enabled = false; //desactiva el efecto de la luz
    }
}
