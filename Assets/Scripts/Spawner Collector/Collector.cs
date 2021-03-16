using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    // OnTriggerEnter2D é chamado quando outro Collider2D entra no gatilho (somente física de 2D)
    private void OnTriggerEnter2D(Collider2D targed)
    {
        if(targed.tag == "BG" || targed.tag == "Platform" || targed.tag=="Push" || targed.tag=="ExtraPush"||targed.tag=="Enimed")
        {
            targed.gameObject.SetActive(false);//deixamos invisivel
        }
    }



}
