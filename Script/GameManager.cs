using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks
{
    public void Back()
    {
        PhotonNetwork.LeaveRoom();
    }
    //Метод фотон, который срабатывает при выходе
    public override void OnLeftRoom()
    {
        //запускаем сцену с Меню игры
        SceneManager.LoadScene(0);
    }
}
