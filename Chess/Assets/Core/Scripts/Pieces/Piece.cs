using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    [SerializeField] protected EPieceColor pieceColor = EPieceColor.White;
    public EPieceColor PieceColor => pieceColor;
    [SerializeField] protected EPieceType pieceType = EPieceType.Pawn;
    public EPieceType PieceType => pieceType;

    public abstract bool IsValidMove(Vector2Int startPosition, Vector2Int targetPosition, Piece[,] board);
}