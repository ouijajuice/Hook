using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject harpoon;

    public Transform firePos;

    public AudioSource source;

    public GameObject harpoonHolder;

    public LineRendererScript lineRenderer;

    public bool loaded = true;
    public bool fleshLoaded = false;
    public bool noHarpoon = false;

    public GameObject currentFleshHarpoon;

    // Update is called once per frame
    void Update()
    {
        if (loaded)
        {
            harpoonHolder.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(harpoon, firePos.position, firePos.rotation);
                source.Play();
                harpoonHolder.SetActive(false);
                loaded = false;
            }
        }
        if (fleshLoaded)
        {
            harpoonHolder.SetActive(false);
            if (Input.GetMouseButtonDown(1))
            {
                fleshLoaded = false;
                loaded = true;
                Destroy(currentFleshHarpoon);
            }
        }
        if (currentFleshHarpoon == null)
        {
            if(Input.GetMouseButtonDown(1))
            {
                lineRenderer.pos2 = null;
                noHarpoon = true;
            }
        }
    }

    
}