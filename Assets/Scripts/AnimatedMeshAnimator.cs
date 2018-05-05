using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimatedMeshAnimator : MonoBehaviour
{
    [SerializeField]
    List<AnimationFrameInfo> FrameInformations;
    [SerializeField]
    MaterialPropertyBlockController PropertyBlockController;

    public bool IsPlaying { get; private set; }

    public void Setup(List<AnimationFrameInfo> frameInformations, MaterialPropertyBlockController propertyBlockController)
    {
        FrameInformations = frameInformations;
        PropertyBlockController = propertyBlockController;
    }

    public void Play(string animationName, float offsetSeconds)
    {
        var frameInformation = FrameInformations.First(x => x.Name == animationName);

        PropertyBlockController.SetFloat("_OffsetSeconds", offsetSeconds);
        PropertyBlockController.SetFloat("_StartFrame", frameInformation.StartFrame);
        PropertyBlockController.SetFloat("_EndFrame", frameInformation.EndFrame);
        PropertyBlockController.SetFloat("_FrameCount", frameInformation.FrameCount);
        PropertyBlockController.Apply();

        IsPlaying = true;
    }

    public void Stop()
    {
        PropertyBlockController.SetFloat("_StartFrame", 0);
        PropertyBlockController.SetFloat("_EndFrame", 0);
        PropertyBlockController.SetFloat("_FrameCount", 1);
        PropertyBlockController.Apply();

        IsPlaying = false;
    }
}