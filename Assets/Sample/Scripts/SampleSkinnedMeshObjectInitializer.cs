using UnityEngine;

public class SampleSkinnedMeshObjectInitializer : MonoBehaviour
{
    [SerializeField]
    Animator Animator;
    [SerializeField]
    MaterialPropertyBlockController PropertyBlockController;

    private readonly static string[] RandomAnimationNames = new string[]
    {
        "Victory",
        "ATK3",
        "Jump",
        "Idle",
    };

    private void Awake()
    {
        var randomColor = new Color(Random.Range(0.00f, 1.00f), Random.Range(0.00f, 1.00f), Random.Range(0.00f, 1.00f), 1);
        PropertyBlockController.SetColor("_Color", randomColor);
        PropertyBlockController.Apply();

        var offsetSeconds = Random.Range(0.0f, 3.0f);
        var randomIndex = Random.Range(0, RandomAnimationNames.Length);
        var randomAnimationNames = RandomAnimationNames[randomIndex];

        Animator.PlayInFixedTime(randomAnimationNames, -1, offsetSeconds);
    }
}
