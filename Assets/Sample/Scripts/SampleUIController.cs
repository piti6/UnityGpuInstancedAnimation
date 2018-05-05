using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SampleUIController : MonoBehaviour
{
    [SerializeField]
    Toggle UseAnimatedMeshToggle;
    [SerializeField]
    InputField ObjectCountinputField;
    [SerializeField]
    Button InstantiateButton;

    public event UnityAction<bool> UseAnimatedMeshToggleChanged = delegate { };
    public event UnityAction<string> ObjectCountInputFieldValueChanged = delegate { };
    public event UnityAction InstantiateButtonClicked = delegate { };

    private void Awake()
    {
        UseAnimatedMeshToggle
            .onValueChanged
            .AddListener((v) => UseAnimatedMeshToggleChanged(v));

        ObjectCountinputField
            .onValueChanged
            .AddListener((v) => ObjectCountInputFieldValueChanged(v));

        InstantiateButton
            .onClick
            .AddListener(() => InstantiateButtonClicked());
    }
}
