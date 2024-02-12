using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesHandler : MonoBehaviour
{
    public GameObject collectablePrefab;
    public int poolSize = 10;
    public int liveSpheresinScene = 0;
    private List<GameObject> collectablesList = new();
    private bool isInitialized = false;
    void Start()
    {
        // Check if this client is the master client
        if (PhotonNetwork.IsMasterClient && !isInitialized)
        {
            Initialize();
        }
    }

    void Initialize()
    {
        // Initialize the object pool
        for (int i = 0; i < poolSize; i++)
        {
            Debug.Log(i);
            GameObject obj = PhotonNetwork.Instantiate(collectablePrefab.name, new Vector3(0, -100, 0), Quaternion.identity);
            PUNOperationsHandler punOpHandler = obj.GetComponent<PUNOperationsHandler>();
            if (punOpHandler != null)
            {
                punOpHandler.CallDeactivate();
            }
            collectablesList.Add(obj);
        }
        isInitialized = true;
    }


    public GameObject GetObject()
    {
        // Find an inactive object in the pool and return it
        for (int i = 0; i < collectablesList.Count; i++)
        {
            if (!collectablesList[i].activeInHierarchy)
            {
                return collectablesList[i];
            }
        }

        // If no inactive object is found, expand the pool
        GameObject newObj = PhotonNetwork.Instantiate(collectablePrefab.name, Vector3.zero, Quaternion.identity);
        PUNOperationsHandler punOpHandler = newObj.GetComponent<PUNOperationsHandler>();
        if (punOpHandler != null)
        {
            punOpHandler.CallDeactivate();
        }
        //newObj.SetActive(false);
        collectablesList.Add(newObj);
        return newObj;
    }

    // To delete excess inactive collectables 
    void RemoveExcessObjects()
    {
        int inactiveCount = 0;
        foreach (GameObject obj in collectablesList)
        {
            if (!obj.activeInHierarchy)
            {
                inactiveCount++;
            }
        }

        if (inactiveCount > poolSize)
        {
            int countToRemove = inactiveCount - poolSize;
            for (int i = 0; i < countToRemove; i++)
            {
                GameObject obj = collectablesList[collectablesList.Count - 1];
                collectablesList.Remove(obj);
                PUNOperationsHandler punOpHandler = obj.GetComponent<PUNOperationsHandler>();
                if (punOpHandler != null)
                {
                    punOpHandler.CallDestroy();
                }
            }
        }
    }

    // To activate a collectable from the collectablesList in a given position
    public void InstatiateObject(Vector3 pos)
    {
        GameObject newObj = GetObject();
        newObj.transform.position = pos;
        PUNOperationsHandler punOpHandler = newObj.GetComponent<PUNOperationsHandler>();
        if (punOpHandler != null)
        {
            punOpHandler.CallActivate();
        }
        StartCoroutine(AddDelayToCollider(newObj));

        liveSpheresinScene++;
    }

    // Adding Delay so that the player activating a collectable does not deactivate it instantly
    //Optional if the collectable is activating in a differnt postion
    IEnumerator AddDelayToCollider(GameObject obj)
    {
        PUNOperationsHandler punOpHandler = obj.GetComponent<PUNOperationsHandler>();
        if (punOpHandler != null)
        {
            punOpHandler.CallDisableCollider();


            yield return new WaitForSeconds(1);

            punOpHandler.CallEnableCollider();
        }
    }

    // To deactivate a collectable when collided with a player
    public void DeactivateObject(GameObject obj)
    {
        if (obj.activeInHierarchy)
        {
            PUNOperationsHandler punOpHandler = obj.GetComponent<PUNOperationsHandler>();
            if (punOpHandler != null)
            {
                punOpHandler.CallDeactivate();
            }
            liveSpheresinScene--;
            RemoveExcessObjects();
        }

    }
}