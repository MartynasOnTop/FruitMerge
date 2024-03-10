using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public List<GameObject> fruits;
    public static int score;
    public TMP_Text scoreText;

    private void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        var index = Random.Range(0, fruits.Count);
        var fruit = Instantiate(fruits[index], transform.position, Quaternion.identity);
        var rg = fruit.GetComponent<Rigidbody2D>();
        rg.gravityScale = 0;
    }
    private void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    void Save()
    {
        PlayerPrefs.SetInt("score", score);
    }
    private void OnDisable()
    {
        Save();
    }
}
