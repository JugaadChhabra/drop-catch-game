using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject effect;
    
    private Touch touch;
    public float speed = 0.001f;

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("object"))
        {
            Destroy(collision.gameObject);
            ScoreManager.score += 1;
            GameObject gm = Instantiate(effect, transform.position, transform.rotation);
            Destroy(gm,2f);
        }
    }
    void Update()
    {
        if(Input.touchCount > 0 && LifeManager.isRunning == true )
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed, transform.position.y,0);
            }
        }
    }
}