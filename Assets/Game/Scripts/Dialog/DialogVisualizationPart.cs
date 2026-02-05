using Dialog;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

namespace Dialog
{
    [System.Serializable]
    public class DialogVisualizationPart
    {
        [field: SerializeField] public List<DialogVisualizationData> DialogVisualizations { get; private set; }
        [field: SerializeField] public CinemachineCamera Camera { get; private set; }
    }
}
