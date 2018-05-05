using UnityEngine;

public class SampleAnimatedMeshObjectInitializer : MonoBehaviour
{
    [SerializeField]
    MaterialPropertyBlockController BodyPropertyBlockController;
    [SerializeField]
    AnimatedMeshAnimator BodyMeshAnimator;
    [SerializeField]
    AnimatedMeshAnimator FaceMeshAnimator;

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
        BodyPropertyBlockController.SetColor("_Color", randomColor);
        BodyPropertyBlockController.Apply();

        var offsetSeconds = Random.Range(0.0f, 3.0f);
        var randomIndex = Random.Range(0, RandomAnimationNames.Length);
        var randomAnimationNames = RandomAnimationNames[randomIndex];

        BodyMeshAnimator.Play(randomAnimationNames, offsetSeconds);
        FaceMeshAnimator.Play(randomAnimationNames, offsetSeconds);
    }
}
