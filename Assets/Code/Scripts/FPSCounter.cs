using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI FPSCounterText;
    
    private void Start()
    {
        InvokeRepeating("CountFPS", 0.5f, 0.5f);
    }

    private void CountFPS()
    {
        int fps = Mathf.RoundToInt(1f / Time.deltaTime);
        FPSCounterText.text = "FPS: " + fps.ToString();
    }
}
