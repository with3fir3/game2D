using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using DG.Tweening;
using JetBrains.Annotations;
public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    [Header("Speed Setup")]
    public Vector2 friction = new Vector2 (-.1f, 0 );
    public float Speed;
    public float SpeedRun;
    public float forcejump = 2f;

    [Header("Animation Setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = .7f;
    public float animationduration = .3f;
    public Ease ease = Ease.OutBack;

    [Header("Animation Player")]
    public string boolRun = "Run";
    public Animator animator;
    public float PlayerSwipeDuration = 1f;

    private float _currentSpeed;
  
    private void Update()
    {
        Handlejump();
        Handlemoviment();
    }
    private void Handlemoviment()
    {
        if (Input.GetKey(KeyCode.LeftControl)) 
        { 
           _currentSpeed = SpeedRun;
            animator.speed = 2;
        }

        else
        {
            _currentSpeed = Speed;
            animator.speed = 1;
        }
           
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            //myrigidbody.MovePosition(myrigidbody.position - velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2 (-_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, PlayerSwipeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            //myrigidbody.MovePosition(myrigidbody.position + velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, PlayerSwipeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else
        {
            animator.SetBool(boolRun, false);
        }
       
        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += friction;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= friction;
        }
        
    
    }
    private void Handlejump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           myRigidbody.velocity = Vector2.up * forcejump;
           myRigidbody.transform.localScale = Vector2.one;


           DOTween.Kill(myRigidbody.transform);
           HandleScalejump();
        }
           
    }
    private void HandleScalejump()
    {
        myRigidbody.transform.DOScaleY(jumpScaleY, animationduration).SetLoops(2 ,LoopType.Yoyo).SetEase(ease);
        myRigidbody.transform.DOScaleX(jumpScaleX, animationduration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

}
