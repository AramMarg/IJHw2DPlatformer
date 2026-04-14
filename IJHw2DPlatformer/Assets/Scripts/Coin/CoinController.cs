using System.Collections;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private CoinSpawner _coinSpawner;  
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Coin _prefab;

    private Coroutine _coroutine;
    private WaitForSeconds _wait;
    private float _delay = 5f;

    private void Awake()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
           Create(_spawnPoints[i].position);
        }
    }
    
    private void Start()
    {
        _wait = new(_delay);
    }

    public void OnInteract(Coin coin)
    {
        coin.Interacted -= OnInteract;

        _coroutine = StartCoroutine(CreateNew(coin.transform.position));

        coin.RunDestroy();
    }

    private IEnumerator CreateNew(Vector2 position)
    {
        yield return _wait;

        Create(position);
    }

    private void Create(Vector2 position)
    {
        Coin coin = _coinSpawner.Create(_prefab, position);

        coin.Interacted += OnInteract;
    }
}
