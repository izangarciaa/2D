using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorProjectil : MonoBehaviour
{
 public GameObject _ProjectilNau;

    void Start()
    {
        //InvokeRepeating("ProjectilNau", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ProjectilNau();
        }
        
    }
    private void ProjectilNau()
    {
        GameObject projectiljugador = Instantiate(_ProjectilNau);
        projectiljugador.transform.position = new Vector2(transform.position.x, transform.position.y);
    }
}
