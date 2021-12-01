using UnityEngine;

public class DetectButton : MonoBehaviour
{

    [SerializeField] SwitchArrows switchArrows;

    public void DetectingPosition()
    {
        switchArrows.buttonPosition = transform.position;
    }
}
