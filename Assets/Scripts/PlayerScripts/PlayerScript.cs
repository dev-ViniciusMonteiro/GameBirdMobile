using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D _myBody;

    public float move_speed = 2f;
    public float normal_Push = 10f;
    public float extra_Push = 14f;

    private bool _initialPush;
    private int _pushCount;
    private bool _playerDied;

    // Despertado é chamado quando a instância do script for carregada
    private void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Essa função será chamada a cada quadro da taxa de quadro fixada, se MonoBehaviour estiver habilitado
    private void FixedUpdate()
    {
        move();
    }

    void move()
    {
        if (_playerDied)
            return;

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            _myBody.velocity = new Vector2(move_speed, _myBody.velocity.y);
        }else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            _myBody.velocity = new Vector2(-move_speed, _myBody.velocity.y);
        }
    }


    // OnTriggerEnter2D é chamado quando outro Collider2D entra no gatilho (somente física de 2D)
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (_playerDied)
            return;

        if (target.tag == "ExtraPush")
        {
            if (!_initialPush)
            {
                _initialPush = true;

                _myBody.velocity = new Vector2(_myBody.velocity.x, 18f);

                target.gameObject.SetActive(false);

                // tocar o som aqui

                return;
            }
            else
            {
                _myBody.velocity = new Vector2(_myBody.velocity.x, extra_Push);

                target.gameObject.SetActive(false);

                _pushCount++;
            }
        }

        if (target.tag == "Push")
        { 
        _myBody.velocity = new Vector2(_myBody.velocity.x, normal_Push);

                target.gameObject.SetActive(false);

                _pushCount++;
        }

            if (_pushCount == 2)
        {
            _pushCount = 0;
            PlataformSpawner.instance.SpawnPlataforms();
        }


    }




}
