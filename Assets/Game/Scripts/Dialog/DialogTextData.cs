using UnityEngine;

namespace Dialog
{
    [System.Serializable]
    public class DialogTextData
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField, TextArea(4, 10)] public string Text { get; private set; }
    }
}
