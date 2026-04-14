using UnityEngine;

[RequireComponent(typeof(MovementRotator))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private MovementRotator _movementRotator;

    private new Rigidbody2D rigidbody;

    private Vector2 _moveDirection = new Vector2(1,0);

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _rayCaster.WallFinded += OnWallFinded;
    }

    private void OnDisable()
    {
        _rayCaster.WallFinded -= OnWallFinded;
    }

    private void FixedUpdate()
    {
        if (_groundChecker.IsGround)
        {
            rigidbody.velocity = new Vector2(_moveDirection.x * _moveSpeed, rigidbody.velocity.y);
        }
    }

    private void OnWallFinded()
    {
        _movementRotator.TurnObject();

        _moveDirection.x = _movementRotator.TurnDirection(_moveDirection);
    }
}
