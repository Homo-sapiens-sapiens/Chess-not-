using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class MenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text logText;
    [SerializeField] TMP_InputField inputField;
    void Log(string message)
    {
        logText.text += "/n";
        logText.text += message;
    }

    void Start()
    {
        //присваиваем игроку них с рандомным числом
        PhotonNetwork.NickName = "Player" + Random.Range(1, 9999);
        //Отображаем ник игрока в поле Log
        Log("Player Name: " + PhotonNetwork.NickName);
        //Настройки игры
        PhotonNetwork.AutomaticallySyncScene = true; //Автопереключение сцены
        PhotonNetwork.GameVersion = "1"; //Версия игры
        PhotonNetwork.ConnectUsingSettings(); //Подключается к серверу Photon


    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 2 });

    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnConnectedToMaster()
    {
        Log("Connected to the server");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }

    public void ChangeName()
    {
        //Считываем то, что написал игрок в поле InputField
        PhotonNetwork.NickName = inputField.text;
        //Выводим в поле игрока его новый никнейм
        Log("New Player name: " + PhotonNetwork.NickName);
    }


    public void Setting()
    {
        PhotonNetwork.LoadLevel("Setting");
    }
}
