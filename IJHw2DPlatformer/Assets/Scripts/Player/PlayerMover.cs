using UnityEngine;

[RequireComponent (typeof (MovementRotator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private MovementRotator _movementRotator;  
    [SerializeField] private GroundChecker _groundChecker; 
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpSpeed = 3f;
    
    public Vector2 InputAxis { get; private set; }

    private new Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();        
    }

    private void OnEnable()
    {
        _inputReader.AxisesReceived += OnAxisesReceived;
    }

    private void OnDisable()
    {
        _inputReader.AxisesReceived -= OnAxisesReceived;
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(InputAxis.x * _moveSpeed, rigidbody.velocity.y);

        if (_groundChecker.IsGround)
        {
            rigidbody.AddForce(Vector2.up * _jumpSpeed * InputAxis.y, ForceMode2D.Impulse);
        }
    }

    private void OnAxisesReceived(Vector2 inputAxis)
    {
        _movementRotator.SetDirection(inputAxis);

        InputAxis = inputAxis;
    }
}
