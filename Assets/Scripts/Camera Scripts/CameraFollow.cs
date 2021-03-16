using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform _target;
    private bool _followPlayer;

    public float min_Y_Treshold = -2.6f;

    // Despertado é chamado quando a instância do script for carregada
    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        if(_target.position.y < (transform.position.y - min_Y_Treshold))
        {
            _followPlayer = false;
        }
        if(_target.position.y > transform.position.y)
        {
            _followPlayer = true;
        }

        if (_followPlayer)
        {
            Vector3 temp = transform.position;
            temp.y = _target.position.y;
            transform.position = temp;
        }
    }
}
