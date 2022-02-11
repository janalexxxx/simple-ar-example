using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DanielLochner.Assets.SimpleScrollSnap;

public class TutorialManager : MonoBehaviour
{
    public Text slide01Headline;
    public Text slide02Headline;
    public Text slide03Headline;
    public Text slide04Headline;
    public Text slide05Headline;
    public SimpleScrollSnap simpleScrollSnap;

    public void Start() {
        Application.targetFrameRate = 90;
        LocalizeText();
    }
    
    // Simple Scroll Snap Events

    public void OnPanelChanged() {
        int selectedPanel = simpleScrollSnap.CurrentPanel;
        print($"Changed to panel number {selectedPanel}");
    }

    // Helper Methods

    private void LocalizeText() {
        slide01Headline.text = Localization.StringFor(Localization.Key.TutorialSlide01Headline);
        slide02Headline.text = Localization.StringFor(Localization.Key.TutorialSlide02Headline);
        slide03Headline.text = Localization.StringFor(Localization.Key.TutorialSlide03Headline);
        slide04Headline.text = Localization.StringFor(Localization.Key.TutorialSlide04Headline);
        slide05Headline.text = Localization.StringFor(Localization.Key.TutorialSlide05Headline);
    }
}