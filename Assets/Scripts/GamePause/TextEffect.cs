using TMPro;
using UnityEngine;

public class TextEffect : MonoBehaviour
{
    public float oscillationAmplitude = 0.5f;
    public float oscillationFrequency = 1.0f;

    public TextMeshProUGUI textGamePause;
    private Vector3[] _originalCharacterPositions;

    private void Awake()
    {
        // Store the original character positions
        _originalCharacterPositions = new Vector3[textGamePause.textInfo.characterCount];
        for (int i = 0; i < textGamePause.textInfo.characterCount; i++)
        {
            _originalCharacterPositions[i] = textGamePause.textInfo.characterInfo[i].bottomLeft;
        }
    }

    private void Update()
    {
        if (textGamePause != null)
        {
            for (int i = 0; i < textGamePause.textInfo.characterCount; i++)
            {
                // Calculate the oscillation offset based on time, amplitude, and frequency
                float oscillationOffset = Mathf.Sin(Time.time * oscillationFrequency) * oscillationAmplitude;

                // Apply the oscillation offset to the character's y-position
                textGamePause.textInfo.characterInfo[i].bottomLeft = _originalCharacterPositions[i] + new Vector3(0, oscillationOffset, 0);
            }

            // Update the text mesh pro object
            textGamePause.ForceMeshUpdate();
        }
    }
}