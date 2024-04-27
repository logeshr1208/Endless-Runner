using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public float turnspeed = 3;

    Player play;
    public GameObject coinmov;
    public GameObject coinmov1;

 public float movespeed = 150;
    Score increasescore;

    // public Transform Player;
    public float maxdistance;
   private float distance;

    void Start()
    {
        increasescore = GameObject.FindObjectOfType<Score>();
        play = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnspeed * Time.deltaTime);

       if (play.ismagnet)
        {
            powercoinmove();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            increasescore.scoreupdate();
            Destroy(gameObject);
        }
    }

    

    public void powercoinmove()
    {
        distance = Vector3.Distance(transform.position, play.transform.position);

        if(distance < maxdistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, play.transform.position, movespeed * Time.deltaTime);
        }
        else
        {
            distance = maxdistance;
        }
    }
   


}




