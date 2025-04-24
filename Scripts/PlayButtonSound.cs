using UnityEngine;
using UnityEngine.UI;

public class PlayButtonSound : MonoBehaviour
{
    public AudioSource audioSource; // Drag the Audio Source here in the Inspector
    public AudioClip clickSound;   // Drag the SFX audio clip here in the Inspector

    public void PlaySound()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
        else
        {
            if (audioSource == null)
            {
                Debug.LogError("Audio Source is not assigned to the button: " + gameObject.name);
            }
            if (clickSound == null)
            {
                Debug.LogError("Click Sound is not assigned to the button: " + gameObject.name);
            }
        }
    }
}
