using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorProjectilEnemic : MonoBehaviour
{

    public GameObject _ProjectilEnemicPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ProjectilEnemic", 0.3f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ProjectilEnemic()
    {
        GameObject projectil = Instantiate(_ProjectilEnemicPrefab);
        projectil.transform.position = transform.position;
    }
}
