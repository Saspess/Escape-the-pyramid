using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Photon.Pun;

public class Lever : MonoBehaviour
{
    [SerializeField]
    private GameObject text;

    [SerializeField]
    private UnityEvent ActiveEvent;

    private PhotonView view;

    private Animator animator;
    private bool isInTriggerZone = false;
    private bool isLeverOff = true;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        ActivateLever();
    }

    private void ActivateLever()
    {
        if (Input.GetKeyDown((KeyCode.R)) && isInTriggerZone)
        {
            view.RPC("OnActivateLever", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    private void OnActivateLever()
    {
        ActiveEvent?.Invoke();
        animator.SetBool("isOn", isLeverOff);
        isLeverOff = !isLeverOff;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            text.SetActive(true);
            isInTriggerZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            text.SetActive(false);
            isInTriggerZone = false;
        }
    }
}
