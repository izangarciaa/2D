using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    public GameObject _ExplosioPrefab;

    private float _vel;
    public GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _vel = 12f;
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal y vertical estan definits per Unity
        // Horizontal detecta quan es prem les tecles A, D, Fletxa Esq, Fletxa Dreta.
        // Vertical detecta quan es prem les tecles W, S, Fletxa Arriba, Fletxa Abaix.
        float direccioInputX = Input.GetAxisRaw("Horizontal");
        float direccioInputY = Input.GetAxisRaw("Vertical");
        //Debug.Log(direccioInputX + " - " + direccioInputY);
        Vector2 direccioIndicada = new Vector2(direccioInputX, direccioInputY);
        //Debug.Log(direccioIndicada + " magnitude = " +direccioIndicada.magnitude);
        MoureNau(direccioIndicada);

    }
    void MoureNau(Vector2 direccioIndicada)
    {
        //Anem a moure la nau:
        // 1) Agafem la pos actual (x,y) de la nau:
        //  transform.position ens retorna la posicio actual de la nau.
        Vector2 posNau = transform.position;
        // 2) Trobem la nova posicio de la nau
        posNau = posNau + direccioIndicada * _vel * Time.deltaTime;
        //Debug.Log("Time.deltaTime= " + Time.deltaTime);

        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));


        maxPantalla.x = maxPantalla.x - 0.85f;
        minPantalla.x = minPantalla.x + 0.85f;
        maxPantalla.y = maxPantalla.y - 0.85f;
        minPantalla.y = minPantalla.y + 0.75f;


        posNau.x = Mathf.Clamp(posNau.x, minPantalla.x, maxPantalla.x);
        posNau.y = Mathf.Clamp(posNau.y, minPantalla.y, maxPantalla.y);

        // 3) Assignem la nova posicio a la nau
        transform.position = posNau;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NauEnemiga")
        {
            GameObject explosio = Instantiate(_ExplosioPrefab);
            explosio.transform.position = transform.position;

            _gameManager.GetComponent<GameManager>().PassarAGameOver();
            //Destroy(gameObject);

        }
    }
}
