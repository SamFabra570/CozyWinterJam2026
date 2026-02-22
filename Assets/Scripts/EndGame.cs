using System;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject finalBackground;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController.Instance.freezePlayer = true;
        finalBackground.SetActive(true);
    }
}
