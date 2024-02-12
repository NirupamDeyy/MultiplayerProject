using UnityEngine;
using Photon.Pun;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] private PlayerMovementScript playerMovementScript;
    [SerializeField] private PlayerOperations playerOperations;
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
       
            playerMovementScript.enabled = enable;
            playerOperations.enabled = enable;
            playerCam.SetActive(enable);
            minmapCam.SetActive(enable);
            canvas.SetActive(enable);
   
    }
}
