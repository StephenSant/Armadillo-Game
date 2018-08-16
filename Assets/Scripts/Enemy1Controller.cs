using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1Controller : MonoBehaviour
{
    public float seekRadius = 5f;

    public float moveSpeed;
    public float stoppingDistance = 1f;

    public NavMeshAgent agent;
    public Transform waypointParent;

    //Make a collection of transforms
    private Transform[] waypoints;
    private int currentindex = 1;

    void Patrol()
    {
        Transform point = waypoints[currentindex];
        float distance = Vector3.Distance(transform.position, point.position);

        if (distance < stoppingDistance)
        {
            currentindex++;
            if (currentindex >= waypoints.Length)
            {
                currentindex = 1;
            }
        }

        agent.SetDestination(point.position);

    }


    void Start()
    {
        //Getting childern of the waypointParent;
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }
}
