using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text ChatText;
    [SerializeField] TMP_InputField InputText;
    [SerializeField] TMP_Text PlayersText;
    [SerializeField] GameObject startButton;

    void Log(string message)
    {
        ChatText.text += "\n";
        ChatText.text += message;
    }
    public void StartGame()
    {
        PhotonNetwork.LoadLevel("Game");
    }
    private void Start()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            startButton.SetActive(false);
        }
        RefreshPlayers();
        //���� � ��� ���� ����������� ���� Winner � ����� ������-������
        if (PlayerPrefs.HasKey("Winner") && PhotonNetwork.IsMasterClient)
        {
            //������� ��������� ����������, � ������� ������ ����������� ��� ������ 
            string winner = PlayerPrefs.GetString("Winner");
            //�������� ����� ����������� ��������� � ������� � ��� ��� ������, ������� ������� � ������� �����
            photonView.RPC("ShowMessage", RpcTarget.All, "The last match was won: " + winner);
            //������� ��� �����, ����� ��� ����������� ���� ��� �� �������� � ��� 
        }
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }
    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            startButton.SetActive(true);
        }
        //������� ��������� � ���, ��� ����� ����� �� ������� � ��� �������
        Log(otherPlayer.NickName + "left the room");
        RefreshPlayers();
    }
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        //������� ��������� � ���, ��� ����� ����� � ������� � ��� �������
        Log(newPlayer.NickName + " entered the room");
        RefreshPlayers();
    }

    [PunRPC]
    public void ShowMessage(string message)
    {
        ChatText.text += "\n";
        ChatText.text += message;
    }

    public void Send()
    {
        //���� � ���� ����� ��� ��������, �� ������ �� ������
        if (string.IsNullOrWhiteSpace(InputText.text)) { return; }
        //���� �� ������ �� ������� Enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //�������� ����� ShowMessage ��� ���� ������� �� �������
            // � ���������� ������� ����, ��� �������� ��������� + �����, ������� ����� ������� � ���� InputField
            photonView.RPC("ShowMessage", RpcTarget.All, PhotonNetwork.NickName + ": " + InputText.text);
            //������� ������ � InputField
            InputText.text = string.Empty;
        }
    }

    [PunRPC]
    public void ShowPlayers()
    {
        //�������� ������ ������� � ��������� ������ ������� Players: 
        PlayersText.text = "Players: ";
        //��������� ����, ������� ���������� ���� ������� �� �������
        foreach (Photon.Realtime.Player otherPlayer in PhotonNetwork.PlayerList)
        {
            //��������� �� ����� ������
            PlayersText.text += "/";
            //������� ��� ������
            PlayersText.text += otherPlayer.NickName;
        }
    }
    void RefreshPlayers()
    {
        //��������� ����� ����� ������ ������ ������(�����, ������� ������ ������)
        if (PhotonNetwork.IsMasterClient)
        {
            //�������� ����� ShowPlayers ��� ���� ������� � �����
            photonView.RPC("ShowPlayers", RpcTarget.All);
        }
    }
}
