using PhoneKeypad.Script;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyButton : MonoBehaviour
{
    [SerializeField] private key key;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI keyText;
    [SerializeField] private TextMeshProUGUI characterText;

    // Start is called before the first frame update
    void Start()
    {
        ApplyKey();
        button.onClick.AddListener(OnButtonClick);
    }

    private void ApplyKey()
    {
        var phonePad = Phone.Instance.PhonePad;
        string[] characters = null;
        char phoneKey = ' ';
        switch (key)
        {
            case key.Key0:
                phoneKey = phonePad.GetPhoneKey(3, 1);
                keyText.text = phoneKey.ToString();
                characters = new string[] { "_" };
                break;
            case key.Key1:
                phoneKey = phonePad.GetPhoneKey(0, 0);
                keyText.text = phoneKey.ToString();
                break;
            case key.Key2:
                phoneKey = phonePad.GetPhoneKey(0, 1);
                keyText.text = phoneKey.ToString();
                break;
            case key.Key3:
                phoneKey = phonePad.GetPhoneKey(0, 2);
                keyText.text = phoneKey.ToString();
                break;
            case key.Key4:
                phoneKey = phonePad.GetPhoneKey(1, 0);
                keyText.text = phoneKey.ToString();
                break;
            case key.Key5:
                phoneKey = phonePad.GetPhoneKey(1, 1);
                keyText.text = phoneKey.ToString();
                break;
            case key.Key6:
                phoneKey = phonePad.GetPhoneKey(1, 2);
                keyText.text = phoneKey.ToString();
                break;
            case key.Key7:
                phoneKey = phonePad.GetPhoneKey(2, 0);
                keyText.text = phoneKey.ToString();
                break;
            case key.Key8:
                phoneKey = phonePad.GetPhoneKey(2, 1);
                keyText.text = phoneKey.ToString();
                break;
            case key.Key9:
                phoneKey = phonePad.GetPhoneKey(2, 2);
                keyText.text = phoneKey.ToString();
                break;
            case key.KeyDelete:
                phoneKey = phonePad.GetPhoneKey(3, 0);
                keyText.text = phoneKey.ToString();
                characters = new string[] { "Delete" };
                break;
            case key.KeySend:
                phoneKey = phonePad.GetPhoneKey(3, 2);
                keyText.text = phoneKey.ToString();
                characters = new string[] { "Send" };
                break;
            default:
                break;
        }

        if(characters == null)
            characters = phonePad.GetCodesByKey(phoneKey);

        characterText.text = characterText.text = string.Join(", ", characters);
    }

    private void OnButtonClick()
    {
        var character = keyText.text;

        Phone.Instance.OnTextInput(character);

        if (key == key.KeySend)
        {
            Phone.Instance.OnConfirm();
        }
    }

    
}

public enum key
{
    Key0,
    Key1,
    Key2, 
    Key3, 
    Key4, 
    Key5, 
    Key6, 
    Key7, 
    Key8, 
    Key9, 
    KeyDelete, 
    KeySend
}