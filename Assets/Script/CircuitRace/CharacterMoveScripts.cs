﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMoveScripts : MonoBehaviour
{
    public Vector3 speed;
    float Accel;
    public Rigidbody PlayerRigidBody;
    public bool Is_MyCharacter = false;

    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Is_MyCharacter)
        {
            CharacterMove();
        }
    }

    void CharacterMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Accel < 0.1f && Accel > -0.1f)
            {
                transform.Rotate(new Vector3(0, -Time.deltaTime * 320.0f, 0) * Accel);
            }
            else
                transform.Rotate(new Vector3(0, -Time.deltaTime * 160.0f, 0) * Accel);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Accel < 0.1f && Accel > -0.1f)
            {
                transform.Rotate(new Vector3(0, Time.deltaTime * 320.0f, 0) * Accel);
            }
            else
                transform.Rotate(new Vector3(0, Time.deltaTime * 160.0f, 0) * Accel);
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Accel <= 0.5f)
            {
                Accel += 0.003f;
                transform.position += (transform.forward) * Accel;
                //speed += new Vector3(0, 0, 0.1f);
                //PlayerRigidBody.velocity = speed;
                //PlayerRigidBody.AddForce(0, 0, 80f * Time.deltaTime);
                //transform.GetComponent<Rigidbody>().AddForce(0,0, 80f * Time.deltaTime);
            }
            else
            {
                transform.position += (transform.forward) * Accel;
            }
        }
        else
        {
            if (Accel > 0)
            {
                Accel -= 0.003f;
                transform.position += (transform.forward) * Accel;
            }
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (Accel >= 0f)
            {
                Accel -= 0.001f;

            }
            else if (Accel < 0f && Accel >= -0.3f)
            {
                Accel -= 0.001f;
                transform.position += (transform.forward) * Accel;
            }
            else
            {
                transform.position += (transform.forward) * Accel;
            }
        }
        else
        {
            if (Accel < 0)
            {
                Accel += 0.001f;
                transform.position += (transform.forward) * Accel;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<TypeScript>() != null)
        {
            if (collision.gameObject.GetComponent<TypeScript>().GetTypeScript().Equals("Blue Item"))
            {    
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.GetComponent<TypeScript>().GetTypeScript().Equals("Red Item"))
            {
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.GetComponent<TypeScript>().GetTypeScript().Equals("Yellow Item"))
            {
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.GetComponent<TypeScript>().GetTypeScript().Equals("Green Item"))
            {    
                Destroy(collision.gameObject);
            }
        }
    }
}
