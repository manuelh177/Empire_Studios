using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    public GameObject obj;
    public bool activate;
    public bool activateOnSpawn;

    private void Start()
    {
        if (activateOnSpawn)
        {
            obj.SetActive(activate);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            obj.SetActive(activate);
    }
}
