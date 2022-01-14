using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextWriterScript : MonoBehaviour
{
    public float letterPause = 0.2f;

    private string _Message;
    private TextMeshProUGUI _TextComp;

    // Use this for initialization
    void Start()
    {
        _TextComp = GetComponent<TextMeshProUGUI>();
        _Message = _TextComp.text;
        _TextComp.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in _Message.ToCharArray())
        {
            _TextComp.text += letter;
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
    }
}
