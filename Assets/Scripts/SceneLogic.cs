using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLogic : MonoBehaviour
{
    [SerializeField] private UITextWriter _uiTextWriter;

    private GameObject[] _coins;
    private int _coinsCollected;

    public GameObject[] Coins => _coins;
    public int CoinsCollected => _coinsCollected;

    private void Awake()
    {
        _coins = GameObject.FindGameObjectsWithTag("Coin");
        _uiTextWriter.CoinCollectionWriter(_coinsCollected, _coins.Length);
    }
    public void WinTextChecker()
    {
        if (_coinsCollected == _coins.Length)
        {
            _uiTextWriter.WinTextWriter();
        }
    }

    public void CoinsCollectedValueChanger()
    {
        _coinsCollected++;
    }
}
