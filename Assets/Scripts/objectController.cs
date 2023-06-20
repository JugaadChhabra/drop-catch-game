using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectController : MonoBehaviour
{
    public static Vector3 pos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("deleter") || collision.CompareTag("basket"))
        {
            // Debug.Log("hit");
            // Destroy(this.gameObject);
            pos = transform.position;
        }
    }
}
