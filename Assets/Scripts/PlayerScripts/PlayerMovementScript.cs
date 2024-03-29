using UnityEngine;
using Photon.Pun;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The move speed of the player")]
    private float moveSpeed = 5f;

    [SerializeField]
    private Camera playerCam;

    [SerializeField]
    private MinimapPositionController minimapPositionController;

    PhotonView view;

    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    void FixedUpdate()
    {
        if (view.IsMine && minimapPositionController.canFocus)
        {
            Move();
        }
    }

    void Move()
    {
        Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 lookPosition = transform.position;

        // If the ray hits something in the world, update the look position
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            lookPosition = hit.point;
            lookPosition.y = transform.position.y; // Keep the same height as the player
        }

        // Rotate the player to face the mouse position
        transform.LookAt(lookPosition);

        // Handle keyboard input for movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction based on keyboard input
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Move the player
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

}
