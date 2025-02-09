using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    [SerializeField] protected EPieceType pieceType = EPieceType.White;
    public EPieceType PieceType => pieceType;
}