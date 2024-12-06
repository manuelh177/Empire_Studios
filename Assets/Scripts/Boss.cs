using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Animator animator;
    private bool onScreen = false;
    private Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float onScreenX = cam.WorldToViewportPoint(transform.position).x;
        onScreen = 0 <= onScreenX && onScreenX <= 1;
        animator.SetBool("See_Player", onScreen);
    }
}
