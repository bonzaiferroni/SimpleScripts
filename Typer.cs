using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class TyperMessage
{
    public string Text;
    public float Duration;

    public TyperMessage(string text, float duration)
    {
        Text = text;
        Duration = duration;
    }
}

[RequireComponent (typeof (Text))]
public class Typer : MonoBehaviour
{
    public List<TyperMessage> Messages;

    private Text _display;
    private TyperMessage _currentMessage;
    private float _timeMessageStarted;
    private float _timeLastTyped;
    private int _currentProgress;
    private float _typeDelay = .05f;
    private const float AverageTypeDelay = .05f;

    void Start()
    {
        _display = GetComponent<Text>();
    }

    void Update () {
        if (_currentMessage == null)
        {
            if (Messages.Count > 0)
            {
                _currentMessage = Messages[0];
                Messages.Remove(_currentMessage);
                _timeMessageStarted = Time.time;
                _currentProgress = 0;
            }
            else
            {
                return;
            }
        }

        if (_currentProgress <= _currentMessage.Text.Length)
        {
            if (!(Time.time > _timeLastTyped + _typeDelay)) return;
            TypeNextCharacter(_currentMessage, _currentProgress);
            _currentProgress++;
            _timeLastTyped = Time.time;
            _typeDelay = AverageTypeDelay * (.5f + UnityEngine.Random.value);
        }
        else
        {
            if (!(Time.time > _timeMessageStarted + _currentMessage.Duration)) return;
            _currentMessage = null;
            _display.text = "";
        }
    }

    private void TypeNextCharacter(TyperMessage currentMessage, int currentProgress)
    {
        var sb = new StringBuilder();
        sb.Append(currentMessage.Text.Substring(0, currentProgress));
        sb.Append("<color=#ffffff00>");
        sb.Append(currentMessage.Text.Substring(currentProgress));
        sb.Append("</color>");

        _display.text = sb.ToString();
    }
}
