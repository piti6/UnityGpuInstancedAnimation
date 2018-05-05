using System.Linq;
using UnityEngine;

public class SampleObjectInitiator : MonoBehaviour
{
    [SerializeField]
    SampleUIController UIController;
    [SerializeField]
    GameObject SkinnedMeshObject;
    [SerializeField]
    GameObject AnimatedMeshObject;
    [SerializeField]
    Transform ObjectPlaceholer;

    private int _currentObjectCount = 0;
    private bool _useAnimatedMesh = true;

    private void Awake()
    {
        UIController.UseAnimatedMeshToggleChanged += OnUseAnimatedMeshToggleChange;
        UIController.ObjectCountInputFieldValueChanged += OnObjectCountInputFieldValueChange;
        UIController.InstantiateButtonClicked += OnInstantiateButtonClick;
    }

    private void OnUseAnimatedMeshToggleChange(bool useAnimatedMesh)
    {
        _useAnimatedMesh = useAnimatedMesh;

        SetupObjects();
    }

    private void OnObjectCountInputFieldValueChange(string value)
    {
        _currentObjectCount = int.Parse(value);
    }

    private void OnInstantiateButtonClick()
    {
        SetupObjects();
    }

    private void SetupObjects()
    {
        foreach (Transform child in ObjectPlaceholer)
        {
            Destroy(child.gameObject);
        }

        foreach (var _ in Enumerable.Range(0, _currentObjectCount))
        {
            var targetObject = _useAnimatedMesh ? AnimatedMeshObject : SkinnedMeshObject;

            var randomPosition = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 0f));
            var randomEulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);

            var go = GameObject.Instantiate(targetObject, randomPosition, Quaternion.Euler(randomEulerAngles), ObjectPlaceholer);
            go.SetActive(true);
        }
    }
}
