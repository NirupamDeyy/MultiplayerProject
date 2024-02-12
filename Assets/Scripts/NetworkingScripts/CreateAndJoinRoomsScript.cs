using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRoomsScript : MonoBehaviourPunCallbacks
{
    [SerializeField]
    [Tooltip("Text Reference")]
    private TMP_Text createInput, joinInput;

    [SerializeField]
    [Tooltip("Button Reference")]
    private Button createButton, joinButton;

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
