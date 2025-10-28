using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearCube : MonoBehaviour
{
    private bool recolectado = false; //estado de cubo recolectado
    public GameObject cuboObjetivo; // Referencia al cubo que se desea hacer desaparecer.
    private Color[] colores = { Color.green, Color.black, Color.red, Color.white, Color.blue }; // Arreglo que contiene varios colores
    private int indiceColor = 0; // Índice que se usará para recorrer el arreglo de colores.
    private Coroutine rutinaDesaparecer; // Variable para guardar la referencia de la corrutina.
    
    // Start is called before the first frame update
    void Start()
    {
        if (cuboObjetivo != null)
        {
            rutinaDesaparecer = StartCoroutine(DesaparecerReparecer());
        }
        else
        {
            Debug.LogError("No se asignó el cubo objetivo en el inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator DesaparecerReparecer()
    {
        //Mientras no se recolecte, repite el ciclo
        while(!recolectado)
        {
            //Desaparecer el cubo por 5 segundos
            cuboObjetivo.SetActive(false);
            yield return new WaitForSecondsRealtime(5f);

            // Cambiar color antes de reaparecer
            CambiarColor();

            //Reaparecer durante 3 segundos
            cuboObjetivo.SetActive(true);
            yield return new WaitForSecondsRealtime(3f);
        }
    }
    void CambiarColor()
    {
        if (cuboObjetivo != null)
        {
            Renderer rend = cuboObjetivo.GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material.color = colores[indiceColor];
                indiceColor = (indiceColor + 1) % colores.Length;
            }
            else
            {
                Debug.LogWarning("El cubo objetivo no tiene Renderer");
            }
        }
    }


    //Cuando el jugador lo toca
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !recolectado)
        {
        
        recolectado = true; //Detiene el ciclo 
        Debug.Log("Cubo recolectado. Se destruirá.");

            // Detiene la corrutina en ejecución
            if (rutinaDesaparecer != null)
            {
                StopCoroutine(rutinaDesaparecer);
            
                rutinaDesaparecer = null;
            }

            //Desactiva el cubo antes de destruirlo
            //cuboObjetivo.SetActive(false);

            //Destruye el cubo
            Destroy(cuboObjetivo, 0.1f);

            //Destruye el objeto vacío controlador
            Destroy(gameObject, 0.2f);
        }
        
        }
    }


