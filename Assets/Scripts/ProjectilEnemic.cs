using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilEnemic : MonoBehaviour
    {
    private float _vel;
    private bool _continuaUltimaDireccio;
    private Vector2 _direccioJugador;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ContinuaUltimaDireccio", 1.5f);
        _vel = 7f;
        _continuaUltimaDireccio = false;
        _direccioJugador = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("Nau") != null)
        { 
            if(!_continuaUltimaDireccio)
            {
                GameObject nauJugador = GameObject.FindWithTag("Nau");
                _direccioJugador = (nauJugador.transform.position - transform.position).normalized;

            }
            Vector2 novaPos = transform.position;
            novaPos = novaPos + _direccioJugador * _vel * Time.deltaTime;
            transform.position = novaPos;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
  private void MovimentVertical()
    {
        Vector2 novaPos = transform.position;

        novaPos = novaPos + Vector2.down * _vel * Time.deltaTime;
        transform.position = novaPos;
    }
    private void OnTriggerEnter2D(Collider2D objecteTocat   )
    {
        if(objecteTocat.tag == "Nau")
        {
            Destroy(gameObject);
        }
    }
    private void ContinuaUltimaDireccio()
    {
        _continuaUltimaDireccio = true;
    } 
}
