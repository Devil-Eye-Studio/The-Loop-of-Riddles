using UnityEngine;

public class SwitchArrows : MonoBehaviour
{

    public Vector3 buttonPosition;

    [SerializeField] private Transform startButton;

    private void Start()
    {
        buttonPosition = startButton.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(buttonPosition.x, buttonPosition.y, 0), 5 * Time.deltaTime);
    }
}
