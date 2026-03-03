using UnityEngine;

public class VoicelineManager : MonoBehaviour
{
    [Header("Pickup Voicelines")]
    public AudioClip[] pickupVoicelines;

    [Header("Death Voicelines")]
    public AudioClip[] deathVoicelines;

    [Header("Jump Voicelines")]
    public AudioClip[] jumpVoicelines;

    // Add more categories here as needed...

    private AudioSource audioSource;
    private int lastIndex = -1;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayPickupVoiceline()
    {
        PlayRandom(pickupVoicelines);
    }

    public void PlayDeathVoiceline()
    {
        PlayRandom(deathVoicelines);
    }

    private void PlayRandom(AudioClip[] clips)
    {
        if (clips == null || clips.Length == 0) return;

        int index;
        do { index = Random.Range(0, clips.Length); }
        while (clips.Length > 1 && index == lastIndex);

        lastIndex = index;
        audioSource.PlayOneShot(clips[index]);
    }
}