using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    
    [SerializeField] private float flickeringTime; // The time after which the light will begin to flicker
    private float usageflickeringTime; // The variable with which all calculations will be carried out 
    [SerializeField] private int flickeringMaxRandomValue; // The maximum value that the chance of flickering can get  
    [SerializeField] private int minimumFlickeringChance; // The minimum value of the number at which the flickering starts

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip flickeringAudio;

    [SerializeField] private Light lightSource;
    private bool isStartFlickering;

    private void Start()
    {
        usageflickeringTime = flickeringTime;

        //lightSource = GetComponent<Light>();
    }

    private void Update()
    {
        if (isStartFlickering)
        {
            usageflickeringTime -= Time.deltaTime;

            int flickerChance = Random.Range(0, flickeringMaxRandomValue);

            if (usageflickeringTime > 0 && isStartFlickering)
            {
                if (flickerChance < minimumFlickeringChance) lightSource.enabled = false; // If the chance of flickering is less than a minimum chance, then the light will be turned off
                else lightSource.enabled = true;
            }
            else
            {
                lightSource.enabled = true;
                isStartFlickering = false;
                Destroy(gameObject);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {           
            isStartFlickering = true;
            audioSource.PlayOneShot(flickeringAudio);
            gameObject.GetComponent<Collider>().enabled = false;
        } 
    }
}
