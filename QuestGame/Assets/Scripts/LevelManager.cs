using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;


public class LevelManager : MonoBehaviourPunCallbacks
{
    public void OnMenuButtonClick()
    {
        Time.timeScale = 1;
        StartCoroutine(Disconnect());
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    IEnumerator Disconnect()
    {
        PhotonNetwork.LeaveRoom();

        while (PhotonNetwork.InRoom)
            yield return null;

        SceneManager.LoadScene("MainMenu");
    }
}
