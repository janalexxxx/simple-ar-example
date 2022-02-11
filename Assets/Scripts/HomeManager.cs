using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

#if UNITY_ANDROID
using UnityEngine.Android;
#endif

#if UNITY_IOS
using NativeCameraNamespace;
#endif

public class HomeManager : MonoBehaviour
{
    public ARSession arSession;

    private bool _didTriggerCameraPermissionRequestAtStart;
    private bool _didPressStartButton;

    public void Start() {
        Application.targetFrameRate = 30;
        
        arSession.gameObject.SetActive(false);
        _didTriggerCameraPermissionRequestAtStart = StorageManager.didTriggerCameraPermissionRequest;
        print($"_didTriggerCameraPermissionRequestAtStart {_didTriggerCameraPermissionRequestAtStart}");
        print($"didShowTutorial {StorageManager.didShowTutorial}");

        if (!StorageManager.didShowTutorial) {
            ShowTutorial();
        } else if (!_didTriggerCameraPermissionRequestAtStart) {
            StartCoroutine(StartGameWhenCameraPermissionIsGranted());
        }
    }

    // Event Handlers

    public void OnStartGameButtonPressed() {
        print("Unity: OnStartGameButtonPressed");
        if (!StorageManager.didTriggerCameraPermissionRequest) {
            print("Unity: TriggerPermissionRequest");
            TriggerPermissionRequest();
        } else {
            if (IsCameraPermissionGranted()) {
                StartGame();
            } else {
                ShowOpenSettingsScene();
            }
        }
    }

    // Private Helpers

    private IEnumerator StartGameWhenCameraPermissionIsGranted() {
        if (_didTriggerCameraPermissionRequestAtStart) {
            yield return null;
        }

        print($"CheckIfCameraPermissionIsGranted {IsCameraPermissionGranted()}");

        while (!IsCameraPermissionGranted()) {
            print("Checking if camera permission is granted");
            yield return new WaitForSeconds(.5f);
        }

        StartGame();
    }

    private void TriggerPermissionRequest() {
        arSession.gameObject.SetActive(true);
        StorageManager.SetCameraPermissionRequestAsTriggered();
    }

    private void StartGame() {
        SceneTransitionManager.LoadScene(SceneTransitionManager.Scene.Game);
    }
    private void ShowOpenSettingsScene() {
        SceneTransitionManager.LoadScene(SceneTransitionManager.Scene.OpenSettings);
    }

    private void ShowTutorial() {
        SceneTransitionManager.LoadScene(SceneTransitionManager.Scene.Tutorial);
    }

    private bool IsCameraPermissionGranted() {
        #if UNITY_ANDROID
        return Permission.HasUserAuthorizedPermission(Permission.Camera);
        #endif

        #if UNITY_IOS
        return NativeCamera.CheckPermission() == NativeCamera.Permission.Granted;
        #endif
    }
}
