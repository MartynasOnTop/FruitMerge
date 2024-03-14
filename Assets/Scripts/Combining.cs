using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combining : MonoBehaviour
{
    public GameObject betterFruit;
    public int fruitPoints;
    public Color fruitColor;
    public ParticleSystem combiningPart;
    public AudioClip mergeSound;
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

            if (gameObject.GetComponent<Combining>() == null) return;
            
            if (betterFruit != null)
            {
                Sound();
                Particles();
                var newFruit = Instantiate(betterFruit, transform.position, transform.rotation);
                newFruit.GetComponent<Falling>().isInAir = false;
                newFruit.GetComponent<Falling>().isLanded = true;
                Spawner.score += fruitPoints;

                await new WaitForSeconds(0.1f);
                Destroy(gameObject);
            }

            if (gameObject.GetComponent<Combining>() == null) return;

            if (betterFruit == null)
            {
                Sound();
                Particles();
                Spawner.score += fruitPoints;

                await new WaitForSeconds(0.1f);
                Destroy(gameObject);
            }
        }
    }

    public void Particles()
    {
        var prt = Instantiate(combiningPart, transform.position, transform.rotation);
        prt.startColor = fruitColor;
    }
    public void Sound()
    {
        var source = gameObject.GetComponent<AudioSource>();
        source.PlayOneShot(mergeSound);
    }
}
