using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererScript : MonoBehaviour
{
    public LineRenderer line;
    public Transform pos1;
    public Transform pos2;

    // Start is called before the first frame update
    void Start()
    {
        line.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (pos2 == null)
        {
            pos2 = pos1;
        }
        line.SetPosition(0, pos1.position);
        line.SetPosition(1, pos2.position);
    }
}
