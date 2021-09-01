using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private UITextWriter _uiTextWriter;
    [SerializeField] private SceneLogic _sceneLogic;

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, _speed);
    }


    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _playerTransform.position);
        if (distanceToPlayer < 10.2f)
        {
            Destroy(gameObject);
            _sceneLogic.CoinsCollectedValueChanger();
            _uiTextWriter.CoinCollectionWriter(_sceneLogic.CoinsCollected, _sceneLogic.Coins.Length);
        }
    }
}