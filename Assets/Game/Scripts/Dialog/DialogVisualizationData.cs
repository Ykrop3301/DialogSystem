using Unity.Cinemachine;
using UnityEngine;

namespace Dialog
{
    [System.Serializable]
    public class DialogVisualizationData
    {
        [field: SerializeField] public Animator CharacterAnimator { get; private set; }
        [field: SerializeField] public string AnimationName { get; private set; }
    }
}
