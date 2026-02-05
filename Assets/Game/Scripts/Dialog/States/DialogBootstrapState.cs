using Characters;
using Unity.Cinemachine;
using UnityEngine;

namespace Dialog
{
    public class DialogBootstrapState : IDialogState
    {
        private readonly DialogHandler _dialogHandler;
        private DialogCharacter _dialogOwner;
        private readonly DialogSceneVisualizator _sceneVisualizator;
        private readonly Player _player;
        private readonly DialogTextVisualizer _textVisualizer;

        public DialogBootstrapState(
            DialogHandler dialogHandler,
            DialogSceneVisualizator sceneVisualizator,
            DialogCharacter dialogOwner,
            Player player,
            DialogTextVisualizer dialogTextVisualizer
            )
        {
            _dialogHandler = dialogHandler;
            _dialogOwner = dialogOwner;
            _sceneVisualizator = sceneVisualizator;
            _sceneVisualizator.gameObject.SetActive(false);
            _player = player;
            _textVisualizer = dialogTextVisualizer;
        }
        public void Enter()
        {
            foreach (DialogCharacter character in _dialogOwner.OtherCharacters)
            {
                character.gameObject.SetActive(false);
            }

            _dialogOwner.gameObject.SetActive(false);
            _player.gameObject.SetActive(false);

            _sceneVisualizator.gameObject.SetActive(true);
            _textVisualizer.gameObject.SetActive(true);
            Debug.Log("Dialog Started");
            Exit();
        }

        public void Exit()
        {
            _dialogHandler.SetState(typeof(DialogStarterState));
        }
    }
}
