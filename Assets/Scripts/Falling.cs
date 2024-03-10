using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public Spawner spawner;

    private async void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            transform.position = new Vector2(mousePos.x, transform.position.y);
            var rg = gameObject.GetComponent<Rigidbody2D>();
            rg.gravityScale = 1;
            await new WaitForSeconds(1f);
            spawner.Spawn();
            Destroy(gameObject.GetComponent<Falling>());
        }
    }
}
