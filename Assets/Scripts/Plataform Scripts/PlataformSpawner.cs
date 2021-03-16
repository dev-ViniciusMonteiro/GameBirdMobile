using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformSpawner : MonoBehaviour
{

    public static PlataformSpawner instance;

    [SerializeField]
    private GameObject _Left_Plataform, _Right_Plataform;

    private float _left_X_Min = -3.6f, _left_X_Max = -2.6f, _right_X_Min = 3.6f, _right_X_Max = 2.6f;
    private float _y_Treshold = 2.8f;
    private float _last_Y;

    public int spawn_count = 8;
    private int _plataform_Spawned;

    [SerializeField]
    private Transform _plataform_Parent;

    //mais variaveis para apawn de inimigos

    // Despertado é chamado quando a instância do script for carregada
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        _last_Y = transform.position.y;

        SpawnPlataforms();
    }

    public void SpawnPlataforms()
    {
        Vector2 temp = transform.position;
        GameObject newPlataform = null;

        for(int i = 0; i<spawn_count; i++)
        {
            temp.y = _last_Y;

            if((_plataform_Spawned % 2) == 0)
            {

                temp.x = Random.Range(_left_X_Min, _left_X_Max);

                newPlataform = Instantiate(_Right_Plataform, temp, Quaternion.identity);
            }
            else
            {
                temp.x = Random.Range(_right_X_Min, _right_X_Max);

                newPlataform = Instantiate(_Left_Plataform, temp, Quaternion.identity);
            }

            newPlataform.transform.parent = _plataform_Parent;

            _last_Y += _y_Treshold;
            _plataform_Spawned++;

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
