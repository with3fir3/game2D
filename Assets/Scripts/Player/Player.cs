using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myrigidbody;

    public Vector2 velocity;

    public float Speed;

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            //myrigidbody.MovePosition(myrigidbody.position - velocity * Time.deltaTime);
            myrigidbody.velocity = new Vector2 (- Speed, myrigidbody.velocity.y);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            //myrigidbody.MovePosition(myrigidbody.position + velocity * Time.deltaTime);
            myrigidbody.velocity = new Vector2(Speed, myrigidbody.velocity.y);
        }


    }





}
