using UnityEngine;

public class HeightCalculator : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private UITextWriter _uiTextWriter;

    private int _heightInfelicity = 2;

    private void Update()
    {
        float distanceToPlayer = _playerTransform.position.y;
        _uiTextWriter.HeightWriter(Mathf.Round(distanceToPlayer) - _heightInfelicity);
    }
}
