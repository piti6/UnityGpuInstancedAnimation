# UnityGpuInstancedAnimation
based on theory: https://developer.nvidia.com/gpugems/GPUGems3/gpugems3_ch02.html - Chapter 2. Animated Crowd Rendering.

Created with Unity 2017.1.3f1. (At least you need 5.4 which supports Gpu Instancing)

## Gpu Instancing in Unity
https://docs.unity3d.com/Manual/GPUInstancing.html

basically, you can use Graphics.DrawMeshInstanced with your mesh data, or you can use MeshRenderer which supports instancing with some of preparations in your shader.

> When you use GPU instancing, the following restrictions apply:

> Unity automatically picks MeshRenderer components and Graphics.DrawMesh calls for instancing. Note that SkinnedMeshRenderer is not supported.

But, you can`t use Gpu Instancing into SkinnedMeshRenderer - which is animating. This means when you want to draw all same characters at once, Unity draws all of them one on one - such a big performance loss.
So I use MeshRenderer for this time.

## Theory
- Bake whole bone matrix informations in animation to Texture \
(81bones with 4 animations / total length 8.x seconds constantly sampled 30fps Texture was 0.5mb. which is fairly affordable.)
- Store bone weights and indexes as per-vertex-datas. used uv3/uv4.
- Pass animation informations you want to play by MaterialPropertyBlock. \
(Once in play, use _Time.y for animating)
- Read animation matrixes in texture at current time.
- Skinning current vertex.

### PROS
- Highly performanced with massive animation objects (Especially in mobile devices.)
- No need additional time or memory on runtime

### CONS
- You can`t use Unity Mecanim system at all.
- Thus, you should write codes about blending or whatever you need on animation control (could be hard way to go)

## QuickStart
### Sample Scene
- Play Sample/Scenes/SampleScene.unity.
- Camera control is same as Unity`s scene view control.
### With your custom FBX files
1. Create prefab with target file.
2. Make sure you have one SkinnedMeshRenderer on your prefab - (also counts children SkinnedMeshRenderer)\
I have no plan to support Nested SkinnedMeshRenderer.
3. Make sure you referenced AnimatorController to your skinnedMeshRenderer`s Animator with setup-wanted animations.
4. Click your prefab, then click top menu AnimatedMeshRendererGenerator -> MeshToAsset.
5. Call AnimatedMeshAnimator::Play(string animationName, float offsetSeconds) on your script.\
(Warning - animationName goes to original Animator`s display name, not file name.)
