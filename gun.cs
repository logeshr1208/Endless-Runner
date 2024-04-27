using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class gun : MonoBehaviour
{
    // public float damage;
    //public float range;
    //public GameObject gunpoint;



    public GameObject bullet;

    public float totaltimespawn = 5;

//private float spawnlimit = 2;



    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (totaltimespawn >=0)
            {

             
                Quaternion rotatebullet = Quaternion.Euler(90f, 0f, 0f);
                Instantiate(bullet, transform.position, rotatebullet);
               
            }
        }
           

    }

    public void bulletspawn()
    {

        
    }

}  




