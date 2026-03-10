using System;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject finalBackground;
    public GameObject bonfireCanvas;

    private void OnTriggerEnter(Collider other)
    {
        finalBackground.SetActive(true);
        bonfireCanvas.SetActive(true);
        PlayerController.Instance.freezePlayer = true;
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
