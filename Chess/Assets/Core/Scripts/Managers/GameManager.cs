using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BoardManager boardManager;

    private void Start()
    {
        boardManager.GenerateBoard();
    }
}