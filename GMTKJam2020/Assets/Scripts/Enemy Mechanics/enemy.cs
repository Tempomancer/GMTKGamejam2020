using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.IO;

public class enemy : MonoBehaviour {

    public float speed;
    public Transform playerPos;
    private playerController player;
    Rigidbody2D rb;
    Seeker seeker;

    public float nextWaypointDistance = 3f;

    Pathfinding.Path path;
    int currentWaypoint = 0;
    bool reachedEndofPath = false;






    // Start is called before the first frame update
    void Start()
    {


        seeker = GetComponent<Seeker>();    
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<playerController>();

        InvokeRepeating("UpdatePath", 0f, 1f);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        seeker.StartPath(rb.position, playerPos.position, OnPathComplete);
    }

    void OnPathComplete(Pathfinding.Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndofPath = true;
            return;
        }
        else
        {
            reachedEndofPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, path.vectorPath[currentWaypoint], speed * Time.deltaTime);


        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //Vector2 force = direction * speed * Time.deltaTime;
        //rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }


   

}
