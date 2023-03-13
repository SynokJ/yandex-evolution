using UnityEngine;

public class EvolutionBarFitter : MonoBehaviour
{
    [Header("Bar Componenets:")]
    [SerializeField] private UnityEngine.UI.Slider _slider;

    private void OnSetSliderValue(float otherValue)
    {
        _slider.value = otherValue;
    }
}
