namespace Dialog
{
    public class DialogStarterState : IDialogState
    {
        private readonly DialogHandler _dialogHandler;
        private readonly DialogSceneVisualizator _sceneVisualizator;
        private int _currentTextId;

        public DialogStarterState(DialogHandler dialogHandler, DialogSceneVisualizator sceneVisualizator)
        {
            _dialogHandler = dialogHandler;
            _sceneVisualizator = sceneVisualizator;
            _currentTextId = 0;
        }

        public void Enter()
        {
            if (_currentTextId < _dialogHandler.Config.Texts.Count)
            {
                _currentTextId++;
                _sceneVisualizator.PlayNext();
                Exit();
            }
            else _dialogHandler.SetState(typeof(FinishDialogState));
        }

        public void Exit()
        {
            _dialogHandler.SetState(typeof(SlowReadingTextState));
        }
    }
}
