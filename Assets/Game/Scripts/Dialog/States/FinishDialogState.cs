using Characters;
using UnityEngine;

namespace Dialog
{
    public class FinishDialogState : IDialogState
    {
        private readonly DialogHandler _dialoghandler;
        private readonly DialogSceneVisualizator _sceneVisualizator;
        private readonly DialogCharacter _dialogCharacter;
        private readonly Player _player;
        private readonly DialogTextVisualizer _textVisualizer;

        public FinishDialogState(
            DialogHandler dialogHandler,
            DialogSceneVisualizator sceneVisualizator,
            DialogCharacter dialogCharacter,
            Player player,
            DialogTextVisualizer dialogTextVisualizer
            )
        {
            _dialoghandler = dialogHandler;
            _sceneVisualizator = sceneVisualizator;
            _dialogCharacter = dialogCharacter;
            _player = player;
            _textVisualizer = dialogTextVisualizer;
        }
        public void Enter()
        {
            GameObject.Destroy(_sceneVisualizator.gameObject);
            _textVisualizer.gameObject.SetActive(false);
            foreach(DialogCharacter character in _dialogCharacter.OtherCharacters)
            {
                character.gameObject.SetActive(true);
            }

            _dialogCharacter.gameObject.SetActive(true);
            _player.gameObject.SetActive(true);

            Exit();
        }

        public void Exit()
        {
            Debug.Log("Dialog ended");
        }
    }
}
