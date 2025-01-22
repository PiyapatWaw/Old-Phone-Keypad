using PhoneKeypad.Script;
using TMPro;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public static Phone Instance;

    [SerializeField] private TextMeshProUGUI inputText;
    [SerializeField] private TextMeshProUGUI outputText;

    public OldPhonePad PhonePad = new OldPhonePad();

    private float delay = 1f;
    public float delayer = 1;
    public bool cut = false;
    private string previousKey = default;
    private string currentKey = default;

    private void Awake()
    {
        Instance = this;
    }

    public void OnTextInput(string character)
    {
        inputText.text += character;
        DisPlayText();
        delayer = delay;
        cut = false;

        if(previousKey == default)
            previousKey = character;
        currentKey = character;
    }

    public void OnConfirm()
    {
        inputText.text = "";
        outputText.text = "";
    }

    private void DisPlayText()
    {
        var result = PhonePad.ParseInput(inputText.text+"#");
        outputText.text = result;
    }

    private void Update()
    {
        if (delayer > 0)
        {
            delayer -= Time.deltaTime;
        }

        if (delayer <= 0 && !cut /*&& previousKey == currentKey*/)
        {
            inputText.text += " ";
            cut = true;
        }
    }
}
