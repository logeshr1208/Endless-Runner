using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Power : MonoBehaviour
{
    coin move;
    
    void Start()
    {
        move = GameObject.FindObjectOfType<coin>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            Destroy(gameObject);
            //move.movetoplayer();


        }
    }

    
}
