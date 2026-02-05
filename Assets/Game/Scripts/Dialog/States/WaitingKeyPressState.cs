using System.Collections;
using UnityEngine;

namespace Dialog
{
    public class WaitingKeyPressState : IDialogState
    {
        private readonly DialogHandler _dialogHandler;
        private readonly CoroutineRunner _coroutineRunner;

        public WaitingKeyPressState(DialogHandler dialogHandler, CoroutineRunner coroutineRunner)
        {
            _dialogHandler = dialogHandler;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter()
        {
            _coroutineRunner.StartCoroutine(WaitingCoroutine());
        }

        private IEnumerator WaitingCoroutine()
        {
            yield return new WaitUntil(() => 
            {
                return Input.anyKeyDown;
            });

            Exit();
        }

        public void Exit()
        {
            _dialogHandler.SetState(typeof(DialogStarterState));
        }
    }
}
