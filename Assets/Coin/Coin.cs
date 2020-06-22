using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    //Variable Global y estatica.
    public static int coinsCount = 0;
   

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Juego iniciado");
        Coin.coinsCount++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * Este metodo se llama cuando se entra en contacto con el collider del gameobject
     * */
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Algo ocurrio con la moneda");
            Coin.coinsCount--;

            if(Coin.coinsCount == 0)
            {
                Debug.Log("Juego Terminado.");
                GameObject gameManager = GameObject.Find("GameManager");
                Destroy(gameManager);

                GameObject[] fireWorkSystem = GameObject.FindGameObjectsWithTag("Fireworks");
                foreach (GameObject fireWork in fireWorkSystem)
                {
                    fireWork.GetComponent<ParticleSystem>().Play();
                }
            }
            Destroy(gameObject);
        }
        
    }
}
