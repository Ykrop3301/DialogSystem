using Dialog;
using UnityEngine;
using Zenject;

public class DialogsInstaller : MonoInstaller
{
    [SerializeField] private DialogTextVisualizer _textVisualizer;
    public override void InstallBindings()
    {
        DialogTextVisualizer textVisualizer = Container.InstantiatePrefabForComponent<DialogTextVisualizer>(_textVisualizer);
        Container.BindInterfacesAndSelfTo<DialogTextVisualizer>().FromInstance(textVisualizer);
    }
}