using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    public float swayCounter = 0f;
    public float swayMagnitude = .1f;
    public float counterMultiplier = 1f;
    public float amountMultiplier = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        float addAmount = Mathf.Sin(0.01f * swayCounter) * swayMagnitude * Time.deltaTime;
        transform.localPosition += Vector3.up * (addAmount * amountMultiplier);
        swayCounter += 1 * counterMultiplier;
    }
}
