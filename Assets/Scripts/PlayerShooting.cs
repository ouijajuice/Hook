using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject harpoon;

    public Transform firePos;

    public AudioSource source;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(harpoon,firePos.position, firePos.rotation);
            source.Play();
        }
    }
}
