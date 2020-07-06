using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopLeft : MonoBehaviour
{
    public EmployeeBar Coder, Art, QA;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool isDone()
    {
        bool done = true;
        if (Coder.CurrentValue > 0)
            done = false;
        if (Art.CurrentValue > 0)
            done = false;
        if (QA.CurrentValue > 0)
            done = false;
        return done;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
