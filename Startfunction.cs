using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Startfunction : MonoBehaviour
{

    public Button startButton;
    public GameObject gameStartPanel;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        gameStartPanel.SetActive(false); // Assuming gameStartPanel is a panel that should be hidden when the game starts
                                         // Add your game start logic here


        /*  Pos = transform.position;
        Pos.x += Input.GetAxis("Horizontal");
        Pos.x = Mathf.Clamp(Pos.x, -25f, 25f);
        transform.position = Pos;*/

        /*  float height = GetComponent<Collider>().bounds.size.y;
          bool isground = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundlayermask); 

        public void obstaclelast()
        {


            int y = Random.Range(3, 4);
            Transform Spawnpoint1 = transform.GetChild(y).transform;
            Instantiate(obstacle2, Spawnpoint1.position, Quaternion.identity);


         public void Spawnpower()
    {

        int p = Random.Range(10, 11);
        Transform powerspawn = transform.GetChild(p).transform;
        Instantiate(power, powerspawn.position, Quaternion.identity);
    }

        public GameObject coin;
    public void spawncoin()
    {

        int z = Random.Range(5, 8);
        Transform Spawnpoint2 = transform.GetChild(z).transform;
        Quaternion rotate = Quaternion.Euler(0f, 180f, 0f);
        Instantiate(coin, Spawnpoint2.position, rotate);
    }

    public GameObject coinspan;
    public void obstaclecenter()
    {
        int y = Random.Range(8, 11);
        Transform Spawnpoint1 = transform.GetChild(y).transform;
        Instantiate(coinspan, Spawnpoint1.position, Quaternion.identity);
    }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gunmove.bulletspawn();
        }








          public void bulletupdate(int bullettochange)
    {
        bullet += bullettochange;
        Bullet.text = "bullet" + bullet;

        if(bullet <= 0)
        {
            gameObject.GetComponent<Player>().enabled = false;

            //show game over message
            gameover.gameObject.SetActive(true);
            restartStart.SetActive(true);

        }

    }




        /*  if (Physics.Raycast(gunpoint.transform.position, gunpoint.transform.forward, out RaycastHit hit, range))
{*/




        /*  public AudioMixer mixer;
          public Slider slider;*/

        /*  public void setmusic()
          {
              float volume = slider.value;
              mixer.SetFloat("Master", volume);
          }
      */



        /*
          public AudioSource audiosrc;
            private float musicVolume = 1f;

            void Start()
            {
                //audiosrc = GetComponent<AudioSource>();
            }

             void Update()
            {
                audiosrc.volume = musicVolume;
            }


            public void setvolume(float volume)
            {
                musicVolume = volume;
            }*/
        /*
            public AudioSource audiosrc;
          public Slider slider;

            private void Start()
            {
                slider.value = PlayerPrefs.GetFloat("slider", 0.05f);
                audiosrc.volume = slider.value;
            }

           public void updatevolume()
            {
                PlayerPrefs.GetFloat("slider", slider.value);
                audiosrc.volume = slider.value;
            }*/


        //gameObject.GetComponent<Player>().enabled = false;

        //show game over message
        // gameover.gameObject.SetActive(true);
        // restartStart.SetActive(true);

    }
}



