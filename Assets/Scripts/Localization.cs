using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localization {
    public enum Key {
        TutorialSlide01Headline,
        TutorialSlide02Headline,
        TutorialSlide03Headline,
        TutorialSlide04Headline,
        TutorialSlide05Headline
    }

    public static string StringFor(Key key) {
        bool isEnglish = Application.systemLanguage != SystemLanguage.German;

        switch (key) {
            case Key.TutorialSlide01Headline:
                return isEnglish ?
                    "English Title 01" :
                    "Deutscher Titel 01";
            case Key.TutorialSlide02Headline:
                return isEnglish ?
                    "English Title 02" :
                    "Deutscher Titel 02";
            case Key.TutorialSlide03Headline:
                return isEnglish ?
                    "English Title 03" :
                    "Deutscher Titel 03";
            case Key.TutorialSlide04Headline:
                return isEnglish ?
                    "English Title 04" :
                    "Deutscher Titel 04";
            case Key.TutorialSlide05Headline:
                return isEnglish ?
                    "English Title 05" :
                    "Deutscher Titel 05";
            default:
                return "Error: String for key not found";
        }
    }
}

