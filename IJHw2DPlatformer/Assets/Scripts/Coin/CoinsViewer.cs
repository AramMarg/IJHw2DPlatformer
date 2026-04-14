using TMPro;
using UnityEngine;

public class CoinsViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Player _player;

    private int _countCoins;

    private void OnEnable()
    {
        _player.CoinGetted += OnCoinGetted;
    }

    private void OnDisable()
    {
        _player.CoinGetted -= OnCoinGetted;
    }

    private void Start()
    {
        _text.text = "0";
    }

    private void OnCoinGetted()
    {
        _countCoins++;

        Display();
    }

    private void Display()
    {
        _text.text = _countCoins.ToString();
    }
}
