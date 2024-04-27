using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class obstacle : MonoBehaviour
{

    public ParticleSystem Exploiseparticle;
    Player play;
    PlayerManager mamnager;
    public int health;
    public bulletscore bullscore;
    //to take bullet
    public GameObject newpower;
    private int hea;
    public Animator ani;
    public TextMeshPro tex;
    private int enemytext;
    public bool eni;
    public int temp;
    public int boo;
    public GameObject[] magnetspawn;
    bool isDie;


    void Start()
    {
        play = GameObject.FindObjectOfType<Player>();

        bullscore = FindObjectOfType<bulletscore>();

        mamnager = FindAnyObjectByType<PlayerManager>();

        ani = GetComponent<Animator>();
      
        //random health for obstacle
        health = Random.Range(1, 10);

        temp = health; 

        // tex = GetComponent<TextMeshPro>().enabled = false;
        FindObjectOfType<TextMeshPro>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {      
        if (health <= 0 && !isDie)
        {
            StartCoroutine(fly());
            isDie = true;
       
        }
    }

    IEnumerator fly()
    {
        ani.SetTrigger("back");
       // Exploiseparticle.Play();
        yield return new WaitForSeconds(1);
        powerup();
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Player")
        {
            play.ismagnet = false;
                play.updatelife(-1);           
                Exploiseparticle.Play();
                Destroy(gameObject,0.5f);         
        }
  
        if (other.gameObject.tag == "bullet")
        {
            tex.enabled = true;
            health -= 1;
            tex.text = "" + health;

            if(health <= 0)
            {
                tex.enabled = false;

            }
            ani.SetBool("react", true);       
            Destroy(other.gameObject);       
        }

    }
    public void powerup()
    {
        int array = Random.Range(0, 2);     
        Quaternion rotate1 = Quaternion.Euler(0f, 180f, 0f);
        GameObject spawnpower = Instantiate(magnetspawn[array], transform.position, rotate1);
        spawnpower.transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        spawnpower.GetComponent<super>().NumberOfBullet = temp * 2;    
    }
}


//obstacle destory power will spawn collect bullet
/*  public void newspawnobj()
  {  
      GameObject g = Instantiate(newpower,transform.position, Quaternion.identity);
      g.GetComponent<super>().NumberOfBullet = temp*2;
  }*/

