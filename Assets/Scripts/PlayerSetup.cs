using UnityEngine;
using Photon.Pun;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] private PlayerMovementScript playerMovementScript;
    [SerializeField] private DropObjects dropObjects;
    public GameObject playerCam, minmapCam, canvas;
    PhotonView view;
    private void Awake()
    {
        //Why? because manually disabling them doesnot work
        //they activates automatically in the saved prefab
        IsLocalPlayer(false);

        view = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (view.IsMine)
        {
            IsLocalPlayer(true);
        }
    }

    public void IsLocalPlayer(bool enable)
    {
        if (enable)
        {
            playerMovementScript.enabled = true;
            dropObjects.enabled = true;
            playerCam.SetActive(true);
            minmapCam.SetActive(true);
            canvas.SetActive(true);
        }
        else
        {
            playerMovementScript.enabled = true;
            dropObjects.enabled = false;
            playerCam.SetActive(false);
            minmapCam.SetActive(false);
            canvas.SetActive(false);
        }
        
    }
}
