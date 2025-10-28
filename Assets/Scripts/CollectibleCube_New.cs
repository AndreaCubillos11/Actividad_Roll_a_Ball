using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCube_New : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Inicia la co-rutina al iniciar el juego
        StartCoroutine(DesaparecerCubo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator DesaparecerCubo()
    {
        //Espera 10 segundos
        yield return new WaitForSecondsRealtime(10f);

        //Desactiva el cubo, es decir, desaparece de la escena
        gameObject.SetActive(false);
    }

}
