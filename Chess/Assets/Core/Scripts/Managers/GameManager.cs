using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BoardManager boardManager;
    [SerializeField] private InputHandler inputHandler;

    private EPieceColor currentTurn = EPieceColor.White;

    private void OnEnable()
    {
        inputHandler.OnMoveAttempted += HandleMoveAttempted;
    }

    private void Start()
    {
        boardManager.GenerateBoard();
    }

    private void OnDisable()
    {
        inputHandler.OnMoveAttempted -= HandleMoveAttempted;
    }

    private void HandleMoveAttempted(Vector2Int start, Vector2Int target)
    {
        Piece piece = boardManager.GetPieceAt(start);

        if (piece == null || piece.PieceColor != currentTurn)
            return;

        if (piece.IsValidMove(start, target, boardManager.Pieces))
        {
            boardManager.MovePiece(start, target);
            EndTurn();
        }

    }

    private void EndTurn()
    {
        currentTurn = currentTurn == EPieceColor.White ? EPieceColor.Black : EPieceColor.White;
        boardManager.RotateBoard();
    }
}