using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{

    enum Scene {
        Home, ARSession, Tutorial, Credits
    }

    private static float defaultTransitionTime = 0.5f;

    private string SceneName(Scene scene)
    {
        switch (scene)
        {
            case Scene.Home: return "Home";
            case Scene.ARSession: return "Start_Game";
            case Scene.Tutorial: return "AppIntro";
            case Scene.Credits: return "Credits";
        }
        return "";
    }

    private Scene SceneFromSystemScene(UnityEngine.SceneManagement.Scene systemScene)
    {
        foreach (Scene scene in Scene.GetValues(typeof(Scene)))
        {
            if (systemScene.name == SceneName(scene))
            {
                return scene;
            }
        }
        return Scene.Home;
    }

    private Scene currentScene {
        get { return SceneFromSystemScene(SceneManager.GetActiveScene()); }
    }


    // MARK: -

    private float TransitionOutTime(Scene toScene) {
        Scene fromScene = currentScene;
        switch (fromScene) {
            case Scene.Home:
                switch (toScene) {
                    case Scene.ARSession: return defaultTransitionTime;
                }
                break;

            case Scene.ARSession:
                return defaultTransitionTime;
        }

        return defaultTransitionTime;
    }

    public Animator transition;

    // MARK: -

    public void LoadHomeScene()
    {
        Debug.Log($"LoadHomeScene()");
        StartCoroutine(LoadScene(Scene.Home));
    }

    public void LoadARScene() {
        Debug.Log($"LoadARScene()");
        StartCoroutine(LoadScene(Scene.ARSession));
    }

    public void LoadTutorial()
    {
        Debug.Log($"LoadAppIntroScene()");
        StartCoroutine(LoadScene(Scene.Tutorial));
    }

    public void LoadCreditsScene() {
        StartCoroutine(LoadScene(Scene.Credits));
    }

    IEnumerator LoadScene(Scene scene) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(TransitionOutTime(scene));

        if (currentScene != Scene.Home) {
            SceneManager.UnloadSceneAsync(SceneName(currentScene));
        }

        Screen.orientation = ScreenOrientation.Portrait;

        SceneManager.LoadSceneAsync(SceneName(scene));
    }
}
