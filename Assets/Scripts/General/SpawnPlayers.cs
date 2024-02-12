using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The player prefab to instantiate")]
    private GameObject playerPrefab;

    [Tooltip("Set Range of Coordinates where the player can Instantiate")]
    [SerializeField] private float minX, maxX, minY, maxY;

    private void Start()
    {
        Screen.fullScreen = false;
        Vector3 pos = new Vector3 (Random.Range(minX, maxX), 0, Random.Range(minY, maxY));
        PhotonNetwork.Instantiate(playerPrefab.name, pos , Quaternion.identity);
    }
}
