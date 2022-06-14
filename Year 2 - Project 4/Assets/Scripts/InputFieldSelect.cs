using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class InputFieldSelect : MonoBehaviour
{
    public VirtualKeyboard keyboard;
	public GameObject mainInputField; 

	void Update()
	{
		if (mainInputField.GetComponent<InputField>().isFocused == true)
		{
			mainInputField.GetComponent<Image>().color = Color.green;
			keyboard.ShowOnScreenKeyboard();
		}
        else if (HideKeyBoardAfterInput())
        {
			keyboard.HideOnScreenKeyboard();
        }
	}

	
	public bool HideKeyBoardAfterInput()
    {
		if (mainInputField.GetComponent<InputField>().isActiveAndEnabled == false)
        {
			return true;
        }
		return false;
    }

}