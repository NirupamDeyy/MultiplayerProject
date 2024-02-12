using UnityEngine;

public class PlayerOperations : MonoBehaviour
{
    CollectablesHandler collectablesHandler;
    PlayerUIHandler playerUIHandler;
    void Start()
    {
        playerUIHandler = GetComponent<PlayerUIHandler>();
        GameObject collectablesHandlerObject = GameObject.FindGameObjectWithTag("collectablesHandler");
       
        if (collectablesHandlerObject != null)
        {
            collectablesHandler = collectablesHandlerObject.GetComponent<CollectablesHandler>();

            if (collectablesHandler != null)
            {
                Debug.Log("CollectablesHandler found!");
            }
            else
            {
                Debug.LogError("CollectablesHandler component not found on GameObject with tag 'CollectablesHandler'.");
            }
        }
        else
        {
            Debug.LogError("GameObject with tag 'CollectablesHandler' not found.");
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            collectablesHandler.InstatiateObject(transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.CompareTag("collectableSphere"))
        {
            if(collision.gameObject.activeInHierarchy)
            {
                collectablesHandler.DeactivateObject(collision.gameObject);
                playerUIHandler.CollectCoin();
            }
            
        }
    }
}
