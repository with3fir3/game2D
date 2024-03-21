using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myrigidbody;

    public Vector2 friction = new Vector2 (-.1f, 0 );

    public float Speed;

    public float forcejump = 2f;

    private void Update()
    {
        Handlejump();
        Handlemoviment();
    }
    private void Handlemoviment()
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
        if (myrigidbody.velocity.x > 0)
        {
            myrigidbody.velocity += friction;
        }
        else if (myrigidbody.velocity.x < 0)
        {
            myrigidbody.velocity -= friction;
        }
        
    
    }
    private void Handlejump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            myrigidbody.velocity = Vector2.up * forcejump;
    }



}
