using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class obstacle1 : MonoBehaviour
{
  
    public ParticleSystem Exploiseparticle;

    Player play;

    PlayerManager mamnager;
    public int health;

    public bulletscore bullscore;

  //to take bullet
    public GameObject newpower;

    private int hea;
   
    void Start()
    {
        play = GameObject.FindObjectOfType<Player>();
    
        bullscore = FindObjectOfType<bulletscore>();

        mamnager = FindAnyObjectByType<PlayerManager>();


        //random health for obstacle
        health = Random.Range(1, 10);

        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {

            
            newspawnobj();
        
            Destroy(gameObject);
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            //without magnet power player will stop life decrease
           /* if (play.magnet == false)
            {
                play.updatelife(-1);
                Exploiseparticle.Play();

                Destroy(gameObject, 1f);
            }*/
             

        }

        if (other.gameObject.tag == "bullet")
        {

              hea+=1;
           
            health -= 1;

            

         //   play.bulletupdate(-1);
         

            Destroy(other.gameObject);

        }
       
    }





    //obstacle destory power will spawn collect bullet
    public void newspawnobj()
    {
        
     GameObject g  = Instantiate(newpower, transform.position, transform.rotation);
        g.GetComponent<super>().NumberOfBullet=hea;
    }
}



