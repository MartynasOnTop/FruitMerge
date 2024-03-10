using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Falling : MonoBehaviour
{
    public Spawner spawner;
    public bool isInAir = true;
    private async void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isInAir == false) return;

            isInAir = false;
            transform.position = new Vector2(mousePos.x, transform.position.y);
            var rg = gameObject.GetComponent<Rigidbody2D>();
            rg.gravityScale = 10;
            await new WaitForSeconds(1f);
            spawner.Spawn();
        }
        if (transform.position.y > 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
