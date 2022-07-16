using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switcher : MonoBehaviour
{
    [SerializeField]
    private UnityEvent ActiveEvent;

    [SerializeField]
    private UnityEvent DeactiveEvent;

    private Vector2 startPos;
    private Vector2 endPos;

    private bool isMoovingUp;
    private bool isMoovingDown;

    private float velocity = 0.9f;

    void Start()
    {
        startPos = transform.position;
        endPos = new Vector2(startPos.x, startPos.y - 0.26f);
    }

    private void Update()
    {
        if (isMoovingUp)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPos, velocity * Time.deltaTime);
        }

        if (isMoovingDown)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, velocity * Time.deltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.tag == "Player" || collision.tag == "Box"))
        {
            isMoovingDown = false;
            isMoovingUp = true;
            ActiveEvent?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "Box")
        {
            isMoovingDown = true;
            isMoovingUp = false;
            DeactiveEvent?.Invoke();
        }
    }
}
