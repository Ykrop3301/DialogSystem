using TMPro;
using UnityEngine;

namespace Dialog
{
	public class DialogTextVisualizer : MonoBehaviour
	{
		[SerializeField] private TMP_Text _nameTextField;
		[SerializeField] private TMP_Text _dialogTextField;

		public void SetName(string name) => _nameTextField.text = name;
		public void SetDialogText(string text) => _dialogTextField.text = text;
	}
}