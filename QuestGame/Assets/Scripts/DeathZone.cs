using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DeathZone : MonoBehaviour
{
    [SerializeField]
    private GameObject LoseCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Time.timeScale = 0;
            LoseCanvas.SetActive(true);
        }
    }
}
