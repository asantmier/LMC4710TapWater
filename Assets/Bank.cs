using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public TextMeshProUGUI waterCounter;
    public TextMeshProUGUI quenchCounter;

    public int water = 0;
    public int quench = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateNumbers();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateNumbers();
    }

    void UpdateNumbers()
    {
        waterCounter.text = water.ToString();
        quenchCounter.text = quench.ToString();
    }
}
