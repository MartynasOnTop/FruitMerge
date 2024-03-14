using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Combining : MonoBehaviour
{
    public GameObject betterFruit;
    public int fruitPoints;
    public Color fruitColor;
    public ParticleSystem combiningPart;
    public AudioSource mergeSound;

    private async void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag != collision.gameObject.tag) return;
        if (transform.position.y < collision.transform.position.y) return;

        var newFruit = Instantiate(betterFruit, transform.position, Quaternion.identity);
        newFruit.GetComponent<Falling>().isInAir = false;
        
        Particles();
        Instantiate(mergeSound);
        Spawner.score += fruitPoints;
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }

    public void Particles()
    {
        var prt = Instantiate(combiningPart, transform.position, transform.rotation);
        prt.startColor = fruitColor;
    }
}
