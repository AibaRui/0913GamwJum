using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    public Transform[] waypoints;
    int cur = 0;



    GameManager _gm;

    void Start()
    {
        _gm = FindObjectOfType<GameManager>();

 
    }

    // Update is called once per frame
    void Update()
    {
        if (_gm._isGame)
        {
            if (transform.position != waypoints[cur].position)
            {
                Vector2 p = Vector2.MoveTowards(transform.position,
                                                waypoints[cur].position,_gm._enemySpeed);
                GetComponent<Rigidbody2D>().MovePosition(p);
            }
            // Waypoint reached, select next one
            else cur = (cur + 1) % waypoints.Length;
        }
    }
}
