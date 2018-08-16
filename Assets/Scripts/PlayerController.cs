using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [Header("Movement")]
    public float moveSpeed = 5;
    public float jumpHeight = 5;
    public float multpySpeed = 3;
    public float airSpeed= 2;
    public float groundSpeed =5;
    public Rigidbody rb;
    private bool isGrounded = false;
    private GameObject ballForm;
    private Vector3 spawnPoint;
    private bool isBall;
    #endregion

    // Use this for initialization
    void Start()
    {
        //Set up Components
        rb = GetComponent<Rigidbody>();
        ballForm = GameObject.Find("BallForm");
        spawnPoint = transform.position;
        ballForm.active = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        #region Move
            Vector3 moveVol = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
            rb.velocity = moveVol;
            if (Input.GetButton("Jump") && isGrounded)
            {
                Vector3 moveDir = new Vector3(moveVol.x, jumpHeight, moveVol.z);
                rb.velocity = moveDir;
            }
            if (moveVol.x == 0 && moveVol.z == 0)
            {
                Quaternion.LookRotation(new Vector3(transform.rotation.x, 0, transform.rotation.z));
            }
            else
            {
                transform.rotation = Quaternion.LookRotation(new Vector3(rb.velocity.x, 0, rb.velocity.z));
            }
        #endregion
        #region GroundCheck
        if (Physics.Raycast(ballForm.transform.position, transform.TransformDirection(new Vector3(0, -1, 0)), 1.1f))
        {
            isGrounded = true;
            moveSpeed = groundSpeed;
            
        }
        else
        {
            isGrounded = false;
            moveSpeed = airSpeed;
        }
        #endregion
        #region Ball mode
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            IsBall();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            moveSpeed /= multpySpeed;
            ballForm.active = false;
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<CapsuleCollider>().enabled = true;
            isBall = false;
        }
        #endregion
        if (transform.position.y < -10)
        {
            transform.position = spawnPoint;
        }
    }

    void IsBall()
    {
        moveSpeed *= multpySpeed;
        ballForm.active = true;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        isBall = true;
    }

}
