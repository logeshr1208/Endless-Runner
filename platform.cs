using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class platform : MonoBehaviour
{

    Spawn spawnplay;
    obstacle obs;
    public GameObject[] obstacle;

    public GameObject coinspawn;
    public GameObject coinspawn1;

   public GameObject[] destoryobject;


    public GameObject[] magnet;
 
    void Start()
    {
        spawnplay = GameObject.FindObjectOfType<Spawn>();
      obs = GameObject.FindObjectOfType<obstacle>();
        enemyspawn();
    
        spawncoin();
        spawncoin1();
        magnet1();
       spawncoin();
        //spawncoin1();
     

    }

  

    //player trigger and enter on another platform 
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //new platform spawn nextspawn point
            spawnplay.Spawnplatform();

            //destory obstacles
            for(int i=0;i< destoryobject.Length; i++)
            {
                if (destoryobject[i] != null)
                {
                    Destroy(destoryobject[i], 2f);
                }
              
            }

            //old destory
            Destroy(gameObject, 2f);

        }
    }

   
    
    public void enemyspawn() {


      
        int array = Random.Range(0, 3);
       int x =  Random.Range(2,5);
        Transform Spawnpoint = transform.GetChild(x);
        Quaternion rotate1 = Quaternion.Euler(0f, 180f, 0f);
        GameObject spawnobstacle=   Instantiate(obstacle[array] , Spawnpoint.position, rotate1);
        destoryobject[0] = spawnobstacle;
    }

    
    public void spawncoin()
    {
        int coin = Random.Range(5, 8);
       Transform coinspa = transform.GetChild(coin);
       GameObject spawnobj1=  Instantiate(coinspawn, coinspa.position, Quaternion.identity);
        destoryobject[1] = spawnobj1;
    }


    public void spawncoin1()
    {
        int coin1 = Random.Range(8, 11);
        Transform coinspa1 = transform.GetChild(coin1);
      GameObject coindestory1=  Instantiate(coinspawn1, coinspa1.position, Quaternion.identity);
        destoryobject[2] = coindestory1;
    }

  public void magnet1()
    {
        int magnetarray = Random.Range(0, 3);
        int mag = Random.Range(11, 14);
        Transform magnetspa1 = transform.GetChild(mag).transform;
        Quaternion en=Quaternion.Euler(0f, 180f, 0f);
        GameObject magn = Instantiate(magnet[magnetarray], magnetspa1.position, en);
        destoryobject[3] = magn;
    }

   /*public void enemy1()
    {
        int coinarray = Random.Range(0, 3);
        int mag1 = Random.Range(14, 17);
        Transform conspa1 = transform.GetChild(mag1).transform;
        Quaternion en1 = Quaternion.Euler(0f, 180f, 0f);
        GameObject magn = Instantiate(ene[coinarray], conspa1.position, en1);
        destoryobject[3] = magn;
    }*/

}
