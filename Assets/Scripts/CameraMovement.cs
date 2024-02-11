using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public MinimapPositionController minimapPositionController;

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
