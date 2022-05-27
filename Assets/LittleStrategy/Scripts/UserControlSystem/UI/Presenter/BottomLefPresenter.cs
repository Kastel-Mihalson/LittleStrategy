using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BottomLefPresenter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _selectedName;
    [SerializeField]
    private Image _selectedImage;
    [SerializeField]
    private Slider _healthSlider;
    [SerializeField]
    private TextMeshProUGUI _text;
    [SerializeField]
    private Image _sliderBacnkground;
    [SerializeField]
    private Image _sliderFillImage;
    [SerializeField]
    private SelectableValue _selectedValue;

    private void Start()
    {
        _selectedValue.OnSelected += onSelected;
        onSelected(_selectedValue.CurrentValue);
    }

    private void onSelected(ISelectable selected)
    {
        _selectedImage.enabled = selected != null;
        _healthSlider.gameObject.SetActive(selected != null);
        _selectedName.enabled = selected != null;
        _text.enabled = selected != null;

        if (selected != null)
        {
            _selectedImage.sprite = selected.Icon;
            _selectedName.text = selected.Name;
            _text.text = $"{selected.Health} / {selected.MaxHealth}";
            _healthSlider.minValue = 0;
            _healthSlider.maxValue = selected.MaxHealth;
            _healthSlider.value = selected.Health;

            var color = Color.Lerp(Color.red, Color.green, selected.Health / (float)selected.MaxHealth);
            _sliderBacnkground.color = color * 0.5f;
            _sliderFillImage.color = color;
        }
    }
}
