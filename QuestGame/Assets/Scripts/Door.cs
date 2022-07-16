using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private GameObject winCanvas;

    private Animator animator;

    private int _playersInZone = 0;

    private void Start()
    {
        _playersInZone = 0;

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(_playersInZone == 2)
        {
            StartCoroutine(EndGame());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _playersInZone++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _playersInZone--;
        }
    }

    IEnumerator EndGame()
    {
        animator.SetTrigger("endGame");

        yield return new WaitForSeconds(1.0f);

        winCanvas.SetActive(true);
    }
}
