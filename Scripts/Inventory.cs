using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public int NumberOfItems { get; private set; }

    public UnityEvent<Inventory> OnItemCollected;
    public GameObject KairenNaviSuccess;

    public AudioClip kairenVoiceLine; // Assign in Inspector
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void ItemsCollected()
    {
        NumberOfItems++;
        OnItemCollected.Invoke(this);

        // Play voice line
        if (kairenVoiceLine != null)
        {
            audioSource.PlayOneShot(kairenVoiceLine);
        }

        // Show dialogue box
        if (KairenNaviSuccess != null)
        {
            KairenNaviSuccess.SetActive(true);
            StartCoroutine(HideDialogueAfterDelay());
        }
    }

    private IEnumerator HideDialogueAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        KairenNaviSuccess.SetActive(false);
    }
}
