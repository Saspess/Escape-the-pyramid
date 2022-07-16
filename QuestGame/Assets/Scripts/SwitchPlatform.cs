using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlatform : MonoBehaviour
{
    [SerializeField]
    private GameObject startPosObj;

    [SerializeField]
    private GameObject endPosObj;

    private Vector2 startPos;
    private Vector2 endPos;

    private bool isMoovingUp;
    private bool isMoovingDown;

    private float velocity = 0.9f;

    private void Start()
    {

        startPos = startPosObj.transform.position;
        endPos = endPosObj.transform.position;
        transform.position = startPos;
        isMoovingUp = false;
        isMoovingDown = true;

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

    public void ActivateEventHandler()
    {
        isMoovingDown = false;
        isMoovingUp = true;
    }

    public void DeactivateEventHandler()
    {
        isMoovingDown = true;
        isMoovingUp = false;
    }
}
