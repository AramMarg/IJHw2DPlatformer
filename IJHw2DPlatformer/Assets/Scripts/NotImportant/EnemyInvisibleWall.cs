using UnityEngine;

[RequireComponent (typeof (Collider2D))]
public class EnemyInvisibleWall : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
}
