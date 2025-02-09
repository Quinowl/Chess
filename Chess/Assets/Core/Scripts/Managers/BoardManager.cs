using UnityEngine;

public class BoardManager : MonoBehaviour
{
    // Cada casilla del tablero es de 0.02 x 0.02; por ende, una pieza para ir de una casilla a otra se deberá
    // mover de 0.04 en 0.04 para que siempre acabe en el centro de la misma -> Sitio original de una pieza en
    // casilla es igual := (0.2,0.25,0.2), la Y es 0.25 para que esté por encima del tablero bien pegada.
    private const float TILE_SIZE = 0.02f;
    private const float PIECE_STEP = 0.04f;

    private float[,] coordinates;
    public float[,] Coordinates => coordinates;

    private Piece[,] pieces = new Piece[8, 8];

    public Vector3 GetWorldPosition(Vector2Int boardPosition)
    {
        return new Vector3(boardPosition.x * PIECE_STEP, 0f, boardPosition.y * PIECE_STEP);
    }

    public Vector2Int GetBoardPosition(Vector3 worldPosition)
    {
        int x = Mathf.RoundToInt(worldPosition.x / PIECE_STEP);
        int y = Mathf.RoundToInt(worldPosition.z / PIECE_STEP);
        return new Vector2Int(x, y);
    }

    public void PlacePiece(Piece pieceToPlace, Vector2Int position)
    {
        pieces[position.x, position.y] = pieceToPlace;
        pieceToPlace.Initialize();
    }

    /// <summary> True if there is a piece on this position. </summary>
    public bool IsPositionOccupied(Vector2Int position) => pieces[position.x, position.y] != null;

    private void InitializeAllCellsCoordinates()
    {
        coordinates = new float[8, 8];
    }
}