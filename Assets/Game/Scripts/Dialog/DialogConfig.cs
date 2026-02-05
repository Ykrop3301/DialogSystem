using System.Collections.Generic;
using UnityEngine;

namespace Dialog
{
	[CreateAssetMenu(menuName = "Config/Dialog", fileName = "New Dialog Config")]
	public class DialogConfig : ScriptableObject
	{
		[field: SerializeField] public DialogSceneVisualizator DialogVisualizator { get; private set; }
		[field: SerializeField] public List<DialogTextData> Texts { get; private set; }
		[field: SerializeField] public float SymbolsSpeedInSeconds { get; private set; }
		[field: SerializeField] public Vector3 DialogPosition { get; private set; }
	}
}