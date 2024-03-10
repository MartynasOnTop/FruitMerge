using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combining : MonoBehaviour
{
    public GameObject betterFruit;
    public int fruitPoints;
    private async void OnCollisionEnter2D(Collision2D collision)
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
            await new WaitForSeconds(0.1f);

            if (betterFruit != null)
            {
                var newFruit = Instantiate(betterFruit, transform.position, transform.rotation);
                newFruit.GetComponent<Falling>().isInAir = false;
                Spawner.score += fruitPoints;
                Destroy(gameObject);
            }
            if (betterFruit == null)
            {
                Spawner.score += fruitPoints;
                Destroy(gameObject);
            }
        }
    }
}
