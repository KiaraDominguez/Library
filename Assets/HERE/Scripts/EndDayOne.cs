using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDayOne : MonoBehaviour
{
    public static int score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score == 3)
        {
            Debug.Log("Fin");
        }
    }
}
