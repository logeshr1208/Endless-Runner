using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Platform;
  Vector3 spawnposition;


    void Start()
    {
        for(int i = 0; i < 2; i++)
        {
            Spawnplatform();
        }     
    }

    public void Spawnplatform()
    {
        GameObject temp= Instantiate(Platform, spawnposition, Quaternion.identity);
         spawnposition = temp.transform.GetChild(1).transform.position;
    }
}
