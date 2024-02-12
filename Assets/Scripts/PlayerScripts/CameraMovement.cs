using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Player Parent Reference")]
    private Transform player;

    [SerializeField] 
    private MinimapPositionController minimapPositionController;

    private void LateUpdate()
    {
        
        if (!minimapPositionController.canFocus)
        {
            return;
        }
        else
        {
            transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
        }
    }
}
