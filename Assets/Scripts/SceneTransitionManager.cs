using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager
{
    public enum Scene {
        Home, Tutorial, Credits, Game, OpenSettings
    }


    // Public Methods

    public static void LoadScene(Scene scene) {
        SceneManager.LoadSceneAsync(SceneName(scene));
    }

    // Helper Methods

    private static string SceneName(Scene scene)
    {
        switch (scene)
        {
            case Scene.Home: return "Home";
            case Scene.Game: return "Game";
            case Scene.Tutorial: return "Tutorial";
            case Scene.Credits: return "Credits";
            case Scene.OpenSettings: return "OpenSettings";
        }
        return "";
    }
}
