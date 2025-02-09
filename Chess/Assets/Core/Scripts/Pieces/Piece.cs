using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    [SerializeField] protected EPieceType pieceType = EPieceType.White;
    public EPieceType PieceType => pieceType;
    [SerializeField] protected float liftHeight = 0.1f;
    protected abstract List<Vector2> GetAvailableMovements();

    private Coroutine movementCoroutine;

    public void Initialize()
    {

    }

    public void MoveTo(Vector2 nextPosition, System.Action onComplete)
    {
        if (movementCoroutine != null) StopCoroutine(movementCoroutine);
        movementCoroutine = StartCoroutine(MovementAnimation(nextPosition, onComplete));
    }

    private IEnumerator MovementAnimation(Vector2 targetPosition, System.Action onComplete)
    {
        Vector3 startPosition = transform.position;
        Vector3 liftPosition = new Vector3(startPosition.x, liftHeight, startPosition.z);
        Vector3 targetLiftPosition = new Vector3(targetPosition.x, liftHeight, targetPosition.y);
        Vector3 finalPosition = new Vector3(targetPosition.x, 0f, targetPosition.y);
        yield return MoveOverTime(startPosition, liftPosition, 0.1f);
        yield return MoveOverTime(liftPosition, targetLiftPosition, 0.2f);
        yield return MoveOverTime(targetLiftPosition, finalPosition, 0.1f);
        onComplete?.Invoke();
    }

    private IEnumerator MoveOverTime(Vector3 from, Vector3 to, float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(from, to, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = to;
    }
}