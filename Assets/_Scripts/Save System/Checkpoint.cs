using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private float[] position;

    private GameObject savingText;

    private void Awake()
    {
        savingText = GameObject.Find("Saving Text");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            savingText.GetComponent<Animator>().SetTrigger("Save");
            position = new float[3];
            position[0] = other.transform.position.x;
            position[1] = other.transform.position.y;
            position[2] = other.transform.position.z;
            PlayerPrefs.SetFloat("PositionX",position[0]);
            PlayerPrefs.SetFloat("PositionY",position[1]);
            PlayerPrefs.SetFloat("PositionZ",position[2]);
        }
    }
}
