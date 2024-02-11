using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRoomsScript : MonoBehaviourPunCallbacks
{
    public TMP_Text createInput;
    public TMP_Text joinInput;

    public Button createButton;
    public Button joinButton;

    private void Start()
    {
        createButton.onClick.AddListener(() => CreateRoom());
        joinButton.onClick.AddListener(() => JoinRoom());
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameScene");
    }

}
