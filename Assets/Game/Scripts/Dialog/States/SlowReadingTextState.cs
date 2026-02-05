using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialog
{
    public class SlowReadingTextState : IDialogState
    {
        private readonly DialogHandler _dialogHandler;
        private readonly List<DialogTextData> _texts;
        private readonly float _symbolsSpeed;
        private readonly CoroutineRunner _coroutineRunner;
        private readonly DialogTextVisualizer _textVisualizer;

        private int _currentTextId;
        public SlowReadingTextState(DialogHandler dialogHandler, CoroutineRunner coroutineRunner)
        {
            _dialogHandler = dialogHandler;
            _texts = _dialogHandler.Config.Texts;
            _currentTextId = 0;
            _symbolsSpeed = dialogHandler.Config.SymbolsSpeedInSeconds;
            _coroutineRunner = coroutineRunner;
            _textVisualizer = _dialogHandler.DialogTextVisualizer;
        }

        public void Enter()
        {
            _textVisualizer.SetName(_texts[_currentTextId].Name);
            _coroutineRunner.StartCoroutine(ReadingCoroutine(_texts[_currentTextId].Text));
            _currentTextId++;
        }

        private IEnumerator ReadingCoroutine(string text)
        {
            string symbolsRemained = text;
            string symbolsOnScreen = string.Empty;

            while(symbolsRemained.Length > 0 || Input.anyKeyDown)
            {
                yield return new WaitForSeconds(_symbolsSpeed);

                symbolsOnScreen += symbolsRemained[0];
                symbolsRemained = symbolsRemained.Remove(0, 1);
                _textVisualizer.SetDialogText(symbolsOnScreen);
            }
            _textVisualizer.SetDialogText(text);
            Exit();
        }

        public void Exit()
        {
            _dialogHandler.SetState(typeof(WaitingKeyPressState));
        }
    }
}
