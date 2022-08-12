using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    
    private GameObject currentBackground;
    private GameObject nextBackground;
    private float backgroundLength;
    private float topOfScreen;
    private float bottomOfScreen;
    public bool nextBackgroundMade = false;

    void Start()
    {
        this.nextBackgroundMade = false;
        currentBackground = this.gameObject;
        backgroundLength = currentBackground.gameObject.GetComponent<RectTransform>().rect.height;
        topOfScreen = -(backgroundLength / 2) + (Screen.height);
        bottomOfScreen = -(backgroundLength / 2) - (Screen.height / 2);

        LeanTween.moveLocalY(currentBackground.gameObject, bottomOfScreen, 20).setDestroyOnComplete(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (this.currentBackground.transform.position.y < topOfScreen && !nextBackgroundMade)
        {
            BackgroundManager.backgroundManager.AddBackground(currentBackground, backgroundLength);
            this.nextBackgroundMade = true;
        }
    }
}
