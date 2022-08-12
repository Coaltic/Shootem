using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    static public BackgroundManager backgroundManager;
    public GameObject backgroundPrefab;
    private GameObject newBackground;

    void Start()
    {
        backgroundManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddBackground(GameObject currentBackground, float backgroundLength)
    {
        newBackground = Instantiate(backgroundPrefab, currentBackground.transform.parent);
        newBackground.transform.position = new Vector2(960f, currentBackground.transform.position.y + backgroundLength);
    }
}
