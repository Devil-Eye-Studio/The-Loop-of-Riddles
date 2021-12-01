using UnityEngine;
using TMPro;

public class Note : MonoBehaviour
{
    
    [SerializeField] private NotesFilling noteData;
    [SerializeField] private AudioClip pickUpAudio;
    private AudioSource audioSource;
    private GameObject canvasObject;

    public bool isPickedUp;

    void Start()
    {
        canvasObject = FindObjectOfType<Canvas>().gameObject;
        audioSource = GetComponent<AudioSource>();
    }

    public void MakeNote()
    {
        canvasObject.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = noteData.noteTitle;
        canvasObject.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = noteData.noteText;
        canvasObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Open", true);
        audioSource.PlayOneShot(pickUpAudio);
    }
    public void CloseNote()
    {
        canvasObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Open", false);
    }
}
