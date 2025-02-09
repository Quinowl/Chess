using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Piece selectedPiece = null;
    private Camera cam = null;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            HandleTouchInput();
        }
        else
        {
            HandleMouseInput();
        }
    }

    public void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
            ProcessInput(Input.mousePosition);
    }

    public void HandleTouchInput()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            ProcessInput(Input.GetTouch(0).position);
    }

    private void ProcessInput(Vector3 inputPosition)
    {
        Ray ray = cam.ScreenPointToRay(inputPosition);
        if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.TryGetComponent(out Piece piece))
        {
            if (selectedPiece == null)
            {
                selectedPiece = piece;
            }
            else
            {
                // selectedPiece.MoveTo(new Vector2((int)piece.transform.position.x, (int)piece.transform.position.z) + Vector2.up * 0.04f, () => Debug.Log("A"));
                // Move the piece if it can do it
            }
        }
    }
}