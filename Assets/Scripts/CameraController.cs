using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float yOffset = 4, zOffset = 10;
    public float smoothness = 0.1f;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position=  Vector3.Lerp(transform.position,new Vector3(0,player.position.y + yOffset,player.position.z+zOffset),smoothness);
    }
}
