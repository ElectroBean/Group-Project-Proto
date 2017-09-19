﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{

    float h;
    float v;
    Vector3 direction;
    public float speed;

    //JUMP STUFF
    public bool grounded;
    public float JumpVel;
    public float JumpTime;
    public float JumpTimeCounter;
    public bool StoppedJumping;
    public string type;
    public float maxSpeed;

    public Transform Ground;

    Rigidbody rb;
    public Vector3 grav;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {
        JumpTimeCounter = JumpTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        //transform.Translate(direction);
        if (grounded)
        {
            JumpTimeCounter = JumpTime;
        }
    }


    //Uses collision events and calculates if your object is inside a different one
    // handy for making sure you dont go inside other things
    private void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal" + type);
        //v = Input.GetAxis("Vertical");
        direction = new Vector3(h, 0, 0);
        direction *= speed;

        rb.AddForce(grav);

        if (rb.velocity.x < maxSpeed)
        {
            rb.velocity = direction;
            //rb.AddForce(direction * Time.deltaTime, ForceMode.VelocityChange);
        }

        //Gravity
        //rb.velocity += grav;
        //if you press down the mouse button...
        if (Input.GetAxis("Vertical" + type) > 0)
        {
            //and you are on the ground...
            if (grounded)
            {
                //jump!
                rb.velocity = new Vector3(rb.velocity.x, JumpVel, 0);
                StoppedJumping = false;
            }
        }
        //if you keep holding down the mouse button...
        if ((Input.GetAxis("Vertical" + type) > 0) && !StoppedJumping)
        {
            //and your counter hasn't reached zero...
            if (JumpTimeCounter > 0)
            {
                //keep jumping!
                rb.velocity = new Vector3(rb.velocity.x, JumpVel, 0);
                JumpTimeCounter -= Time.deltaTime;
            }
        }

        //if you stop holding down the mouse button...
        if (Input.GetAxis("Vertical" + type) <= 0)
        {
            //stop jumping and set counter to zero.
            JumpTimeCounter = 0;
            StoppedJumping = true;
        }
    }

    public void Slow()
    {
        StartCoroutine("slow");
        //StopCoroutine("slow");
    }

    IEnumerator slow()
    {
        speed /= 2.0f;
        yield return new WaitForSeconds(2f);
        speed *= 2.0f;
    }

    IEnumerator speedUp()
    {
        speed *= 2.0f;
        yield return new WaitForSeconds(2f);
        speed /= 2.0f;
    }

    IEnumerator stun()
    {
        yield return new WaitForSeconds(5f);
    }
}
