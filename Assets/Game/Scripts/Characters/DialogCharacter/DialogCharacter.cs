using Common;
using Dialog;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
namespace Characters
{
    public class DialogCharacter : MonoBehaviour, ICharacter
    {
        [SerializeField] private Trigger _trigger;
        [SerializeField] private DialogConfig _dialogConfig;
        [field: SerializeField] public List<DialogCharacter> OtherCharacters { get; private set; }

        private DialogHandler _dialogHandler;
        private DialogTextVisualizer _textVisualizer;
        private CoroutineRunner _coroutineRunner;
        private bool _used = false;

        [Inject]
        private void Initialize(DialogTextVisualizer textVisualizer, CoroutineRunner coroutineRunner)
        {
            _textVisualizer = textVisualizer;
            _coroutineRunner = coroutineRunner;
        }

        private void Start()
        {
            _trigger.Enter += StartDialog;
        }

        private void StartDialog(Player player)
        {
            if (!_used)
            {
                _used = true;
                _dialogHandler = new DialogHandler(_dialogConfig, _textVisualizer, this, player, _coroutineRunner);
                _dialogHandler.Start();
            }
        }
    }
}