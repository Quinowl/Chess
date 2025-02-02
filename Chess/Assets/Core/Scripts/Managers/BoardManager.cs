using UnityEngine;

public class BoardManager : MonoBehaviour
{
    // Cada casilla del tablero es de 0.02 x 0.02; por ende, una pieza para ir de una casilla a otra se deberá
    // mover de 0.04 en 0.04 para que siempre acabe en el centro de la misma -> Sitio original de una pieza en
    // casilla es igual := (0.2,0.25,0.2), la Y es 0.25 para que esté por encima del tablero bien pegada.
}