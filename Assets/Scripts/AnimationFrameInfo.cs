using System;

[Serializable]
public class AnimationFrameInfo
{
    public string Name;
    public int StartFrame;
    public int EndFrame;
    public int FrameCount;

    public AnimationFrameInfo(string name, int startFrame, int endFrame, int frameCount)
    {
        Name = name;
        StartFrame = startFrame;
        EndFrame = endFrame;
        FrameCount = frameCount;
    }
}