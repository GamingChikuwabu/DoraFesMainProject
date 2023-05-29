using UnityEngine;
using DG.Tweening;

public class RandomHopping : MonoBehaviour
{
    [SerializeField] private float minJumpHeight = 1f;
    [SerializeField] private float maxJumpHeight = 3f;
    [SerializeField] private float minJumpDuration = 0.5f;
    [SerializeField] private float maxJumpDuration = 1f;
    [SerializeField] private Ease jumpEaseType = Ease.InOutSine;

    private Vector3 _startPosition;
    private Sequence _jumpSequence;

    private void Start()
    {
        _startPosition = transform.position;
        StartRandomJump();
    }

    private void StartRandomJump()
    {
        float jumpHeight = Random.Range(minJumpHeight, maxJumpHeight);
        float jumpDuration = Random.Range(minJumpDuration, maxJumpDuration);

        _jumpSequence?.Kill();

        _jumpSequence = transform.DOJump(
            _startPosition + Vector3.up * jumpHeight, 
            jumpHeight, 
            1, 
            jumpDuration
        ).SetEase(jumpEaseType).OnComplete(StartRandomJump);
    }
}

