using UnityEngine;

[RequireComponent (typeof (Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] InputReader _inputReader;   

    private void OnEnable()
    {
        _inputReader.AxisesReceived += OnAxisesReceived;
    }

    private void OnDisable()
    {
        _inputReader.AxisesReceived -= OnAxisesReceived;
    }

    private void OnAxisesReceived(Vector2 coordinates)
    {
        if (coordinates.y == 1)
        {
            _animator.SetBool("IsJump", true);

            return;
        }

        _animator.SetBool("IsJump", false);

        _animator.SetFloat("InputX", coordinates.x);
        _animator.SetFloat("InputY", coordinates.y);
    }
}
