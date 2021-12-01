using UnityEngine;

[CreateAssetMenu(fileName = "New NoteData", menuName = "Note Data")]
public class NotesFilling : ScriptableObject
{
    public string noteTitle;

    [TextArea(5, 20)]
    public string noteText;
}
