using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private float timeLength = 5f;
    [SerializeField] private Transform clockHourHandTransform;
    [SerializeField] private Transform clockMinuteHandTransform;
    private float day;

    private void Update()
    {
        day += Time.deltaTime / timeLength;
        float dayNormalized = day % 1f;

        float rotationDegreesPerDay = 360f;
        clockHourHandTransform.eulerAngles = new Vector3(0, 0, dayNormalized * rotationDegreesPerDay / 2f);

        float hoursPerDay = 24f;
        clockMinuteHandTransform.eulerAngles = new Vector3(0, 0, dayNormalized * rotationDegreesPerDay * hoursPerDay / 4f);
    }

}
