using UnityEngine;

[RequireComponent (typeof (Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string IsJump = nameof(IsJump);
    private const string InputX = nameof(InputX);
    private const string InputY = nameof(InputY);

    [SerializeField] private InputReader _inputReader;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

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
            _animator.SetBool(IsJump, true);

            return;
        }

        _animator.SetBool(IsJump, false);

        _animator.SetFloat(InputX, coordinates.x);
        _animator.SetFloat(InputY, coordinates.y);
    }
}
