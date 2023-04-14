using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilJug : MonoBehaviour
{
    private float _vel;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 6f;

    }

    // Update is called once per frame
    void Update()
    {
       
            Vector2 projectil = transform.position;

        projectil = projectil + new Vector2(0f, 1f) * _vel * Time.deltaTime;

        transform.position = projectil;

            Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0f, 1f));
            if (transform.position.y > maxPantalla.y)
            {
                Destroy(gameObject);
            }
        }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NauEnemiga")
        {
            Destroy(gameObject);
        }
    }
}


