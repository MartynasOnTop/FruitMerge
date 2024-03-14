using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Falling : MonoBehaviour
{
    public Spawner spawner;
    public bool isInAir = true;
    public bool isLanded = false;
    public AudioClip fallSound;
    public AudioSource gameOver;
    private async void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x < -2.6 || mousePos.x > 2.6) return;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isInAir == false) return;

            GetComponent<AudioSource>().PlayOneShot(fallSound);

            isInAir = false;
            transform.position = new Vector2(mousePos.x, transform.position.y);
            var rg = gameObject.GetComponent<Rigidbody2D>();
            rg.gravityScale = 10;
            await new WaitForSeconds(1f);
            isLanded = true;
            spawner.Spawn();
        }
    }
    private async void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "DeadLine" && isLanded == true)
        {
            foreach (var item in FindSceneObjectsOfType(typeof(Combining))) 
            {
                item.GetComponent<Combining>().Particles();
                Destroy(item.GameObject());
            }
            Instantiate(gameOver);
            await new WaitForSeconds(1f);
            SceneManager.LoadScene("Menu");
        }
    }
}
