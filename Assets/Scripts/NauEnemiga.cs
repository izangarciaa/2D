using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NauEnemiga : MonoBehaviour
{
    private float _vel;
    public GameObject _ExplosioPrefab;

    private TMPro.TextMeshPro _textPuntsJugador;
    // Start is called before the first frame update
    void Start()
    {
        _vel = 4f;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direccioIndicada = new Vector2(0f, -1f);
        MoureNau(direccioIndicada);
        
       
    void MoureNau(Vector2 direccioIndicada)
        {
            //Anem a moure la nau:
            // 1) Agafem la pos actual (x,y) de la nau:
            //  transform.position ens retorna la posicio actual de la nau.
            Vector2 posNauEnemiga = transform.position;
            // 2) Trobem la nova posicio de la nau
            posNauEnemiga = posNauEnemiga + direccioIndicada * _vel * Time.deltaTime;
            //Debug.Log("Time.deltaTime= " + Time.deltaTime);


            // 3) Assignem la nova posicio a la nau
            transform.position = posNauEnemiga;

            Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            if(minPantalla.y > transform.position.y)
            {
                //gameObject es igual a this
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ProjecJug"|| collision.tag == "Nau")
        {

            GameObject explosio = Instantiate(_ExplosioPrefab);
            explosio.transform.position = transform.position;

            int puntsEnemic = 100;
            GameObject.Find("TextPunts").GetComponent<TextPuntsJugador>().setPuntsJugador(puntsEnemic);   

            Destroy(gameObject);

        }
       
    }
    private void OnBecameInvisible()
    {
        //Debug.Log("La nave ha salido de la pantalla");
    }
}
