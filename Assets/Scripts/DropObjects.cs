using Photon.Pun;
using UnityEngine;

public class DropObjects : MonoBehaviour
{
    public GameObject dropObjectPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject dropObj = PhotonNetwork.Instantiate(dropObjectPrefab.name, Vector3.zero, Quaternion.identity);
            dropObj.transform.position = transform.position;
        }
    }
}
