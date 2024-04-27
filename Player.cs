using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public Rigidbody Playerrb;
    public float speed, horizontalmultiplier ;
    private float horizontalinput;
    public bool canstart;
    public Animator ani;
    private int life;
    public Image[] hearts;
    public TextMeshProUGUI Bullet;
    public TextMeshProUGUI gameover;
    public Image warning;
    public GameObject spawnbullet;
    public int bullet ;
    public GameObject spawnposition;
    bulletscore bullsco;
    coin colectcoin;
    public bool power;
    public bool onground=true;
    public float jumpforce;
    public gameoverpane over;
    public GameObject effect;
    public bool ismagnet;
    super sup;
    //public Score scoreview;
    obstacle obstacles;
    private float dis;
    private float maxdis=10;
    public ParticleSystem Exploiseparticle;
    public bool warningdie;

    void Start()
    {
        Playerrb = GetComponent<Rigidbody>();

        updatelife(3);
       // bulletupdate(100);
        canstart = true;
        ani = GetComponent<Animator>();
        bullsco = GetComponent<bulletscore>();
         colectcoin = GameObject.FindObjectOfType<coin>();  
        obstacles = GetComponent<obstacle>();
        warningdie = true;
    }

    public void restartbutton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    void Update()
    {
        if (canstart )

        {
            horizontalinput = Input.GetAxis("Horizontal");
            Vector3 horizontalmove = transform.right * horizontalinput * Time.deltaTime * horizontalmultiplier;
            transform.position += transform.forward * speed * Time.deltaTime;
            transform.position += horizontalmove;
            Vector3 tempTransform = transform.position;
            float temp = Mathf.Clamp(transform.position.x, -25f, 25f);
            tempTransform.x = temp;
            transform.position = tempTransform;
        }
       
        if (power)
        {
            Debug.Log("power");          
            speed = 60;
        }
        else
        {
            speed = 30;
        }

        if (Input.GetKeyDown(KeyCode.Space) && onground)
        {           
            Debug.Log("jump ");          
            Playerrb.AddForce(Vector3.up*jumpforce, ForceMode.Impulse);
            ani.SetTrigger("jump");
            onground = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ani.SetTrigger("Slide");
        }
  
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            bulletspawnarea();      
        }
             Bullet.text = "" + bullet;

        if (bullet <= 0)
        {
            gameObject.GetComponent<Player>().enabled = false;
            gameover.gameObject.SetActive(true);
            over.gameover();
            ani.SetTrigger("die");
            ani.SetTrigger("restart");
        }

        //warning message
        if (bullet < 80)
        {
            if (warningdie)

            {
                warning.gameObject.SetActive(true);
            }
            else
            {
                warning.gameObject.SetActive(false);
            }
        }
       
    }

    void bulletspawnarea()
    {
        bullet -= 1;
        Quaternion rotatebullet = Quaternion.Euler(90f, 0f, 0f);
        GameObject spawnObj = Instantiate(spawnbullet, spawnposition.transform.position, rotatebullet);
        if (power)
        {
            spawnObj.GetComponent<moveforward>().speed += 60;
        }
        else
        {
            spawnObj.GetComponent<moveforward>().speed = 100;
        }
    }

    public void updatelife(int lifetochange)
    {
            life += lifetochange;    
             heart();
    }
    public void heart()
    {
        if (life < 1)

        {
            Debug.Log("warning");
            canstart = false;
            hearts[2].gameObject.SetActive(false);
            gameover.gameObject.SetActive(true);
            over.gameover();
            warningdie = false;
            ani.SetTrigger("die");
            ani.SetTrigger("restart");

        }
        else if (life < 2)
        {
            canstart = false;
            hearts[1].gameObject.SetActive(false);
            ani.SetTrigger("die");
            StartCoroutine(ruagain());

        }
        else if (life < 3)
        {
          canstart=false;
            hearts[0].gameObject.SetActive(false);
           ani.SetTrigger("die");
            StartCoroutine(ruagain());
        }
    }

    IEnumerator ruagain()
    { 
        yield return new WaitForSeconds(3.0f);
        canstart = true;
    }

    //when trigger an power obstacle
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "poweup")
        {
             bullet += other.gameObject.GetComponent<super>().NumberOfBullet;


            if (bullet >= 0)
            {
                Bullet.text = "" + bullet;
            }
           

            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "obs1")
        {
            ismagnet=false;
            updatelife(-1);
            Exploiseparticle.Play();
            heart();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "magnet")
        {
            /* scoreview.Scor   += other.gameObject.GetComponent<super>().numberofcoin;
               scoreview.scoreupdate();*/
            StartCoroutine(magnetpowerup());
            Destroy(other.gameObject);
        }
    }

    IEnumerator magnetpowerup()
    {
        ismagnet = true;
        power = true;
        yield return new WaitForSeconds(6.0f);
        ismagnet = false;
        power = false;

    }
   
    private void OnCollisionEnter(Collision collision)
    {
        onground = true;
    }






   /* void obstacle()
    {
        Exploiseparticle.Play();
        if (life < 3)
        {
            hearts[2].gameObject.SetActive(false);
        }

        else if (life < 2)
        {
            hearts[1].gameObject.SetActive(false);
        }

        else if (life < 1)

        {

            hearts[0].gameObject.SetActive(false);
        }
    }

    IEnumerator powertime()
    {
        yield return new WaitForSeconds(5.0f);
        power = false;
    }
*/





    //* other.gameObject.GetComponent<super>().NumberOfBullet;


    /*  public void attack()
      {
          dis = Vector3.Distance(transform.position, obstacles.transform.position);

          if (dis < maxdis)
          {
              Debug.Log("ssss");
              ani.SetTrigger("attack");
          }*/

    /* //take magnet to collect coin
        if (other.gameObject.tag == "magnet")
        {
            Debug.Log("magnet");
            StartCoroutine(magnetpowerup());
            StartCoroutine(powertime());
            Destroy(other.gameObject);
        }*/

    /* public void bulletupdate(int bullets)
   {
       bullet += bullets;

       if (bullet >= 0)
       {
           Bullet.text = "" + bullet;
       }



       if (bullet <= 0)
       {
           gameObject.GetComponent<Player>().enabled = false;

           gameover.gameObject.SetActive(true);
           over.gameover();
           ani.SetTrigger("die");
           ani.SetTrigger("restart");



       }

       if (bullets < 95)
       {
           warning.gameObject.SetActive(true);
       }
       else
       {
           warning.gameObject.SetActive(false);
       }


   }*/


}
