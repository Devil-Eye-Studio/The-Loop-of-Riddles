using UnityEngine;

public class ButtonAudio : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pressButtonAudio;
    [SerializeField] private AudioClip hoverButtonAudio;

    public void PressButton()
    {
        audioSource.PlayOneShot(pressButtonAudio);
    }

    public void HoverButton()
    {
        audioSource.PlayOneShot(hoverButtonAudio);
    }
}
