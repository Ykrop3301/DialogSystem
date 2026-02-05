using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

namespace Dialog
{
    public class DialogSceneVisualizator : MonoBehaviour
    {
        [SerializeField] private List<DialogVisualizationPart> _visualizationsParts;
        private int _currentDataId = 0;
        private CinemachineCamera _currentCamera = null;

        public void PlayNext()
        {
            if (_currentCamera != null) _currentCamera.gameObject.SetActive(false);
            if (_currentDataId < _visualizationsParts.Count)
            {
                foreach (DialogVisualizationData visualization in _visualizationsParts[_currentDataId].DialogVisualizations)
                {
                    visualization.CharacterAnimator.SetTrigger(visualization.AnimationName);
                }

                _currentCamera = _visualizationsParts[_currentDataId].Camera;
                _currentCamera.gameObject.SetActive(true);
                _currentDataId++;
            }
        }
    }
}
