using UnityEngine;
using DG.Tweening;
using System.Collections;

public class MinimapPositionController : MonoBehaviour
{
    [SerializeField] private RectTransform miniMapRect;

    [Tooltip("Players Main Camera, not minimap camera")]
    [SerializeField] private Camera playerCamera;

    [Tooltip("Vertical Size of the orthogonal/Minimap camera view")]
    [SerializeField] private int miniMapCameraSize = 15;

    [Tooltip("Length of the square area formed by the minmap cam view, to find" +
        " out, put an object at a corner of the square area by watching at" +
        "the Minmap and get the position of the object,then do the calc to find length")]
    [SerializeField] private int miniMapRectSize = 250;

    private Vector2 pos;

    public bool canFocus = true;

    Vector3 camLastPos = Vector3.zero;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            FocusToObject();
        }
        if(Input.GetMouseButtonUp(0) && !canFocus)
        {
            FocusBackToPlayer();
        }
    }
    private void FocusToObject()
    {
        if (canFocus)
        {
            Vector2 screenPoint = Input.mousePosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(miniMapRect, screenPoint, null, out pos);
            if (pos.x > 125 || pos.y > 125 || pos.x < -125 || pos.y < -125)
                return;
            camLastPos = playerCamera.transform.position;
            canFocus = false;
            float xPos =  playerCamera.transform.position.x + pos.x * miniMapCameraSize * 2 / miniMapRectSize;
            float yPos =  playerCamera.transform.position.z + pos.y * miniMapCameraSize * 2 / miniMapRectSize;
            Vector3 endPos = new Vector3(xPos , playerCamera.transform.position.y, yPos);
            playerCamera.transform.DOMove(endPos, .1f, false).SetEase(Ease.Linear);
        }

    }
    private void FocusBackToPlayer()
    {
        playerCamera.transform.DOMove(camLastPos, .1f, false).OnComplete(ChangeCanFocusBool);
    }

    private void ChangeCanFocusBool()
    {
        canFocus = true;
    }

}
