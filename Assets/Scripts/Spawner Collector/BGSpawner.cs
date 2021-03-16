using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour
{
    private GameObject[] _bgs;
    private float _height;
    private float _highest_Y_Pos;

    // Despertado é chamado quando a instância do script for carregada
    private void Awake()
    {
        _bgs = GameObject.FindGameObjectsWithTag("BG");
    }



    // Start is called before the first frame update
    void Start()
    {
        _height = _bgs[0].GetComponent<BoxCollider2D>().bounds.size.y;
        _highest_Y_Pos = _bgs[0].transform.position.y;

        for(int i = 0; i<_bgs.Length; i++)
        {
            if (_bgs[i].transform.position.y > _highest_Y_Pos)
            {
                _highest_Y_Pos = _bgs[i].transform.position.y;
            }
        }
    }

    // OnTriggerEnter2D é chamado quando outro Collider2D entra no gatilho (somente física de 2D)
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "BG")
        {
            if(target.transform.position.y >= _highest_Y_Pos)
            {
                Vector3 temp = target.transform.position;

                for(int i = 0; i < _bgs.Length; i++)
                {
                    //se nao estiver desenhado
                    if (!_bgs[i].activeInHierarchy)
                    {
                        temp.y += _height;
                        _bgs[i].transform.position = temp;
                        _bgs[i].gameObject.SetActive(true);//deixamos visivel depois de reposicionar (ficou invisivel no collector)

                        _highest_Y_Pos = temp.y;
                    }

                }
            }
        }
    }


}
