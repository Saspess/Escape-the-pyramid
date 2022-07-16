using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private InputField roomInputField;
    [SerializeField]
    private InputField nickInputField;
    [SerializeField]
    private GameObject levelCanvas;

    private void Start()
    {
        LoadSaves();
        levelCanvas.SetActive(false);
    }

    public void OnHostButtonClick()
    {
        levelCanvas.SetActive(true);
    }

    public void OnLevelButtonClick()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        EnterNick();
        PlayerPrefs.SetInt("id", 1);

        if (roomInputField.text != string.Empty)
            PhotonNetwork.CreateRoom(roomInputField.text, roomOptions);
    }

    public void OnJoinRoomButtonClick()
    {
        if(roomInputField.text != string.Empty)
        {
            PlayerPrefs.SetString("roomName", roomInputField.text);
            PhotonNetwork.JoinRoom(roomInputField.text);
        }
            

        EnterNick();

        levelCanvas.SetActive(false);

        PlayerPrefs.SetInt("id", 2);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Level1");
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    public void OnRulesButtonClick()
    {
        SceneManager.LoadScene("RulesScene");
    }

    private void EnterNick()
    {
        PlayerPrefs.SetString("nick", nickInputField.text);
        PhotonNetwork.NickName = nickInputField.text;
    }

    private void LoadSaves()
    {
         nickInputField.text = PlayerPrefs.GetString("nick");
         PhotonNetwork.NickName = nickInputField.text;

        roomInputField.text = PlayerPrefs.GetString("roomName");
    }
}
