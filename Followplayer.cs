using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followplayer : MonoBehaviour
{

    public Transform Player;
    Vector3 Offset;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        Offset = transform.position - Player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetpos = Player.position + Offset;
        targetpos.x = 0;
        transform.position = targetpos;

        
    }
}
