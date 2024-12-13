using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = tr.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = tr.position;
    }
}
