using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataforScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _fruit, _fruit2;

    [SerializeField]
    private Transform _spawn_Point;

    // Start is called before the first frame update
    private void Start()
    {
        GameObject newFruit = null;

        if (Random.Range(0, 10) > 8)
        {
            newFruit = Instantiate(_fruit, _spawn_Point.position, Quaternion.identity);
        }
        else
        {
            newFruit = Instantiate(_fruit2, _spawn_Point.position, Quaternion.identity);
        }

        if(newFruit!=null)
            newFruit.transform.parent = transform;
    }

   
}
