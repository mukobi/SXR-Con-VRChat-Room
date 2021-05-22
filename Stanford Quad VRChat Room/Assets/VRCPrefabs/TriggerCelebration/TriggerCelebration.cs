
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

/// <summary>
/// Plays a celebration particle and audio effect when a player enters the trigger area.
/// </summary>
public class TriggerCelebration : UdonSharpBehaviour
{
    private AudioSource audioSource;
    private ParticleSystem particles;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        particles = GetComponent<ParticleSystem>();
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "Celebrate");
    }

    public void Celebrate()
    {
        if (audioSource)
            audioSource.Play();
        if (particles)
            particles.Play();
    }
}
