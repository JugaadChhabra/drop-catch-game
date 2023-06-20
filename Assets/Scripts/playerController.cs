using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] public float rightBoundary; 
    [SerializeField] public float leftBoundary; 
    public Animator animator;
    bool isRight = false;
    private Vector2 fingerDown;
    private Vector2 fingerUp;
    public bool detectSwipeOnlyAfterRelease = false;

    public float SWIPE_THRESHOLD = 20f;
    public GameObject effect;

    private Touch touch;
    public float speed = 0.001f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("object"))
        {
            Destroy(collision.gameObject);
            ScoreManager.score += 1;
            GameObject gm = Instantiate(effect, objectController.pos, transform.rotation);
            Destroy(gm, 2f);
        }
    }
    void Update()
    {
        if (Input.touchCount > 0 && LifeManager.isRunning == true)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                foreach (Touch touch in Input.touches)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        fingerUp = touch.position;
                        fingerDown = touch.position;
                    }
                    if (touch.phase == TouchPhase.Moved)
                    {
                        if (!detectSwipeOnlyAfterRelease)
                        {
                            fingerDown = touch.position;
                            checkSwipe();
                        }
                    }

                    //Detects swipe after finger is released
                    if (touch.phase == TouchPhase.Ended)
                    {
                        fingerDown = touch.position;
                        checkSwipe();
                    }
                }
                if ((transform.position.x <= rightBoundary) && (transform.position.x >= leftBoundary))
                {
                    transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed, transform.position.y, 0);
                    animator.SetBool("isMoving",true);
                }
            }
        }
        else
        {
            animator.SetBool("isMoving",false);
        }
    }

    void checkSwipe()
    {
        if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {
            //Debug.Log("Horizontal");
            if (fingerDown.x - fingerUp.x > 0 && !isRight)//Right swipe
            {
                flip();
            }
            else if (fingerDown.x - fingerUp.x < 0 && isRight)//Left swipe
            {
                flip();
            }
            fingerUp = fingerDown;
        }
    }
    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

    void flip()
    {
        Vector3 currenScale = gameObject.transform.localScale;
        currenScale.x *= -1;
        gameObject.transform.localScale = currenScale;
        isRight = !isRight;
    }

}