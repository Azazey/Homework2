using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextWriter : MonoBehaviour
{
    [SerializeField] private Text _enginePowerText;
    [SerializeField] private Text _vehicleSpeed;
    [SerializeField] private Text _heightText;
    [SerializeField] private Text _coinsText;
    [SerializeField] private Text _winText;
    [SerializeField] private SceneLogic _sceneLogic;
    
    public void WinTextWriter()
    {
        _winText.enabled = true;
    }

    public void HeightWriter(float distance)
    {
        _heightText.text = "Высота    " + distance;
    }
    
    public void EnginePowerWriter(int engineWork)
    {
        _enginePowerText.text = "Мощность    " + engineWork;
    }

    public void CoinCollectionWriter(int coinsCollected, int coins)
    {
        _coinsText.text = "Монеток собрано:" + coinsCollected + "/" + coins;
        _sceneLogic.WinTextChecker();
    }

    public void VehicleSpeedWriter(float speedvalue)
    {
        _vehicleSpeed.text = "Скорость    " + speedvalue;
    }
}
