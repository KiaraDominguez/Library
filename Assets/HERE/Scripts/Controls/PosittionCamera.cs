using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosittionCamera : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float xpos;
    [SerializeField] float ypos;
    [SerializeField] float zpos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(xpos, ypos, zpos);
    }
}
