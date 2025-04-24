using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    public Image hpBarImage;

    public Sprite fullHP;
    public Sprite halfHP;
    public Sprite lessHP;
    public Sprite lowHP;

    public GameObject kairenNaviDialogue;
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
    void Start()
    {
        currentHP = maxHP;
        UpdateHPUI();

        if (kairenNaviDialogue != null)
            kairenNaviDialogue.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit an enemy!");
            TakeDamage(25);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateHPUI();

        if (currentHP <= 0)
        {
            Debug.Log("Player defeated!");
            // Trigger game over or respawn here
        }
    

        // Play voice line
        if (kairenVoiceLine != null)
        {
            audioSource.PlayOneShot(kairenVoiceLine);
        }

        if (kairenNaviDialogue != null)
        {
            kairenNaviDialogue.SetActive(true);
            Invoke("HideDialogue", 3f);
        }

        if (currentHP <= 0)
        {
            Debug.Log("Player is dead.");
            // Handle death
        }
    }

    void UpdateHPUI()
    {
        float percent = (float)currentHP / maxHP;

        if (percent > 0.75f)
            hpBarImage.sprite = fullHP;
        else if (percent > 0.5f)
            hpBarImage.sprite = halfHP;
        else if (percent > 0.25f)
            hpBarImage.sprite = lessHP;
        else
            hpBarImage.sprite = lowHP;
    }

    void HideDialogue()
    {
        if (kairenNaviDialogue != null)
            kairenNaviDialogue.SetActive(false);
    }
}
