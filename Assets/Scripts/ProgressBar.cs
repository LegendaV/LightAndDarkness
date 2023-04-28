using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Text _text;
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private float _maxValue;

    private void Update()
    {
        var amount = _playerStats.Energy / _maxValue;
        _image.fillAmount = Mathf.Lerp(_image.fillAmount, amount, 2.5f * Time.deltaTime);
        _text.text = _playerStats.Energy.ToString();
    }
}