using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMove : MonoBehaviour
{
   
    Rigidbody2D rb;
    Animator animator;

    [SerializeField]
    float speed = 500f;

    Touch touch;
    Vector3 touchPos, moveDir;
    float previousTouch, currentTouch;

    bool isMoving = false;
   
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(GameManager.Instance.stopTrigger)
        {
            animator.SetTrigger("start");
            PlayerMove();
        }
        
        
        if(!GameManager.Instance.stopTrigger)
        {
            animator.SetTrigger("dead");
        }
    }


    public void PlayerMove()
    {
        if (isMoving)
            currentTouch = (touchPos - transform.position).magnitude;
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                previousTouch = 0;
                currentTouch = 0;
                isMoving = true;
                touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                touchPos.z = 0;
                moveDir = (touchPos - transform.position).normalized;
                rb.velocity = new Vector2(moveDir.x * speed * Time.deltaTime,
                    moveDir.y * speed * Time.deltaTime);
                    // moveDir.y * 0 );
            }
        }

        if(currentTouch > previousTouch)
        {
            isMoving = false;
            rb.velocity = Vector2.zero;
        }

        if(isMoving)
            previousTouch = (touchPos - transform.position).magnitude;

    }
}
