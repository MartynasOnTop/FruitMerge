using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combining : MonoBehaviour
{
    public GameObject betterFruit;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == collision.gameObject.tag)
        {
           if (gameObject.transform.position.y > collision.transform.position.y)
            {
                Destroy(collision.gameObject);
            }
           else if (collision.transform.position.y > gameObject.transform.position.y)
            {
                Destroy(gameObject);
            }
            Instantiate(betterFruit, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
