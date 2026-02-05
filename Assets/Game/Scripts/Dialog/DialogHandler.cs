using Characters;
using System.Collections.Generic;
using UnityEngine;

namespace Dialog
{
    public class DialogHandler
    {
        public readonly DialogConfig Config;
        public readonly DialogTextVisualizer DialogTextVisualizer;

        private System.Type _currentState;
        private Dictionary<System.Type, IDialogState> _states;

        public DialogHandler(DialogConfig config, DialogTextVisualizer dialogTextVisualizer, DialogCharacter dialogOwner, Player player, CoroutineRunner coroutineRunner)
        {
            Config = config;
            DialogTextVisualizer = dialogTextVisualizer;
            DialogSceneVisualizator sceneVisualizator = GameObject.Instantiate(config.DialogVisualizator, config.DialogPosition, Quaternion.identity);

            _states = new Dictionary<System.Type, IDialogState>
            {
                { typeof(DialogBootstrapState), new DialogBootstrapState(this, sceneVisualizator, dialogOwner, player, dialogTextVisualizer) },
                { typeof(DialogStarterState), new DialogStarterState(this, sceneVisualizator) },
                { typeof(SlowReadingTextState), new SlowReadingTextState(this, coroutineRunner) },
                { typeof(WaitingKeyPressState), new WaitingKeyPressState(this, coroutineRunner) },
                { typeof(FinishDialogState), new FinishDialogState(this, sceneVisualizator, dialogOwner, player, dialogTextVisualizer) },

            };
        }

        public void Start()
        {
            _states[typeof(DialogBootstrapState)].Enter();
        }

        public void SetState(System.Type stateType)
        {
            _currentState = stateType;
            _states[_currentState].Enter();
        }
    }
}
