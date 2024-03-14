using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private async void Start()
    {
        await new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
