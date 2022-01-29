using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class TouchManager : MonoBehaviour
{
    private GameManager _gameManager;

    void Start() {
        _gameManager = GameManager.instance;
    }

    void OnEnable() {
        LeanTouch.OnFingerDown += HandleFingerDown;
        LeanTouch.OnFingerUpdate += HandleFingerUpdate;
        LeanTouch.OnFingerUp += HandleFingerUp;
        LeanTouch.OnFingerTap += HandleFingerTap;
        LeanTouch.OnGesture += HandleGesture;
        LeanTouch.OnFingerSwipe += HandleFingerSwipe;
    }

    void OnDisable() {
        LeanTouch.OnFingerDown -= HandleFingerDown;
        LeanTouch.OnFingerUpdate -= HandleFingerUpdate;
        LeanTouch.OnFingerUp -= HandleFingerUp;
        LeanTouch.OnFingerTap -= HandleFingerTap;
        LeanTouch.OnGesture -= HandleGesture;
        LeanTouch.OnFingerSwipe -= HandleFingerSwipe;
    }

    private void HandleFingerDown(LeanFinger finger) {
        // print($"Finger down at {finger.ScreenPosition}");
    }

    private void HandleFingerUpdate(LeanFinger finger) {
        // print($"Finger update at {finger.ScreenPosition}");
    }

    private void HandleFingerUp(LeanFinger finger) {
        // print($"Finger up at {finger.ScreenPosition}");
    }

    private void HandleFingerTap(LeanFinger finger) {
        // print($"Tap at {finger.ScreenPosition}");
        
        _gameManager.OnTap(finger);
    }

    private void HandleFingerSwipe(LeanFinger finger) {
        print($"Swipe at {finger.ScreenPosition}");
    }

    private void HandleGesture(List<LeanFinger> fingers) {
        float pinchValue = LeanGesture.GetPinchScale(fingers);
        float rotationValue = LeanGesture.GetTwistRadians(fingers);
        Vector2 touchCenter = LeanGesture.GetScreenCenter(fingers);

        print($"Gesture at {touchCenter} || Pinch {pinchValue} || Rotation {rotationValue}");
    }
}
