using Photon.Pun;
using UnityEngine;
public class PUNOperationsHandler : MonoBehaviourPunCallbacks
{
    public SphereCollider sphereCollider;
    void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    [PunRPC]
    void ActivateGameObject()
    {
        gameObject.SetActive(true);
    }

    [PunRPC]
    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }

    [PunRPC]
    void DestroyGameObject()
    {
        PhotonNetwork.Destroy(gameObject);
    }

    // Method to call to activate the GameObject across the network
    public void CallActivate()
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("ActivateGameObject", RpcTarget.All);
    }

    // Method to call to deactivate the GameObject across the network
    public void CallDeactivate()
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("DeactivateGameObject", RpcTarget.All);
    }

    // Method to call to destroy the GameObject across the network
    public void CallDestroy()
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("DestroyGameObject", RpcTarget.All);
    }


    [PunRPC]
    void EnableCollider()
    {
        sphereCollider.enabled = true;
    }

    [PunRPC]
    void DisableCollider()
    {
        sphereCollider.enabled = false;
    }

    // Method to call to enable the sphere collider across the network
    public void CallEnableCollider()
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("EnableCollider", RpcTarget.All);
    }

    // Method to call to disable the sphere collider across the network
    public void CallDisableCollider()
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("DisableCollider", RpcTarget.All);
    }
}