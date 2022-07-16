using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject player;

    private PhotonView view;

    private GameObject spawnPos1;
    private GameObject spawnPos2;

    private void Start()
    {
        view = GetComponent<PhotonView>();

        spawnPos1 = GameObject.FindGameObjectWithTag("spawnPoint1");
        spawnPos2 = GameObject.FindGameObjectWithTag("spawnPoint2");

        if (PlayerPrefs.GetInt("id") == 1)
            PhotonNetwork.Instantiate(player.name, spawnPos1.transform.position, Quaternion.identity);

        if (PlayerPrefs.GetInt("id") == 2)
            PhotonNetwork.Instantiate(player.name, spawnPos2.transform.position, Quaternion.identity);
    }
}
