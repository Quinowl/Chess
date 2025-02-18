using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private BoardManager boardManager;
    private Vector2Int selectedCell = new Vector2Int(-1, -1);
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
        Vector2Int cell = GetClickPosition(inputPosition);
        boardManager.ClearMoveIndicators();

        // If there is some piece on the board's cell...
        if (boardManager.IsCellOccupied(cell))
        {
            // Select it
            selectedCell = cell;
            // Show all piece available movements
            boardManager.ShowAvailableMoves(cell);
        }
        // SelectedCell == (-1, -1) => there isnt anything selected
        // so, if we have some cell selected and we select other...
        else if (selectedCell != Vector2Int.one * -1)
        {
            // It moves the piece to new selected
            boardManager.MovePiece(selectedCell, cell);
            // Updates selectedCell to (-1,-1) => there isnt anything selected
            selectedCell = Vector2Int.one * -1;
        }
    }

    private Vector2Int GetClickPosition(Vector3 inputPosition)
    {
        Ray ray = cam.ScreenPointToRay(inputPosition);
        if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.TryGetComponent(out Cell cell))
            return cell.transform.position.ToVector2Int();
        return Vector2Int.one * -1;
    }
}