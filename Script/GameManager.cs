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
    //����� �����, ������� ����������� ��� ������
    public override void OnLeftRoom()
    {
        //��������� ����� � ���� ����
        SceneManager.LoadScene(0);
    }
}
