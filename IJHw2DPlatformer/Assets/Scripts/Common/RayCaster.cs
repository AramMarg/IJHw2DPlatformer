using System;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private float _rayDistance = 0.5f;
    private Vector2 _rayDirection;
    private float _changeDirection = -1f;

    public event Action WallFinded;

    private void Awake()
    {
        _rayDirection = Vector2.right;
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _rayDirection, _rayDistance, _layerMask);
        
        if (hit.collider != null &&  hit.collider.TryGetComponent<EnemyInvisibleWall>(out _))
        {
            Debug.DrawRay(transform.position, _rayDirection, Color.green);

            _rayDirection *= _changeDirection;

            WallFinded?.Invoke(); 
        }
    }
}
