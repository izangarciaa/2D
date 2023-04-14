using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemics : MonoBehaviour
{/*
  * Crear multiples objectes d'un:
  * 
  * 1) Convertim l'objecte a copiar en Prefab.
  * 2) Creem un objecte buit a l'escena.
  * 3) Creem un script i l'assignem a l'objecte buit.
  * 4) En l'objecte buit:
  *     -Creem un atribut de tipus GameObject i públic.
  *     - Des de Unity, arroseguem el Prefab sobr el camp public anterior
  *         (el tipus de GameObject, que apareixerà a l'editor de Unity).
  *     -Creem un metode i hi fem el Instantiate(en l'exemple, el metode
  *         "CrearEnemic").
  *     -En el Start(), cridem el InvokeRepeating();
  */
    public GameObject _NauEnemicPrefab;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IniciGeneraEnemics()
    {
        //Param1: Nom metode a cridar.
        //Param2: Temps fins cridar-se.
        //Param3: Temps entre repeticions.
        InvokeRepeating("CreaEnemic", 3f, 1f);
    }
    public void AturaGenerarEnemics()
    {
        CancelInvoke("CreaEnemic");
    }
    private void CreaEnemic()
    {
        GameObject nauEnemic = Instantiate(_NauEnemicPrefab);

        //Anem a situar en una posicio aleatoria (pero a dalt) l'enemic creat.

        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f));
        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));

        //Trobem la posicio X aleatorio entre el marge esquerra i dret de la pantalla

        float posicioHoritzontalComponentX = Random.Range(minPantalla.x, maxPantalla.x);

        nauEnemic.transform.position = new Vector2(posicioHoritzontalComponentX, maxPantalla.y);
    }
}

