using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Lean.Touch;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {
        get { return FindObjectOfType<GameManager>(); }
    }

    public Camera mainCamera;

    void Start() {
        Application.targetFrameRate = 30;
    }

    // Touch Events

    public void OnTap(LeanFinger finger) {
        print($"Tap detected at {finger.ScreenPosition}");

        Ray ray = mainCamera.ScreenPointToRay(finger.ScreenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100)) {
            GameObject hitGameObject = hit.collider.gameObject;
            print($"GameObject called {hit.collider.gameObject.name} hit");
        } else {
            print("No gameObject found");
        }
    }

    // Tracked Image Events

    public void OnTrackedImageAdded(ARTrackedImage trackedImage) {
        print($"{trackedImage.referenceImage.name} has been added");
    }

    public void OnTrackedImageRemoved(ARTrackedImage trackedImage) {
        print($"{trackedImage.referenceImage.name} has been removed");
    }

    public void OnTrackedImageUpdate(ARTrackedImage trackedImage) {
        print($"{trackedImage.referenceImage.name} has been updated || Tracking State {trackedImage.trackingState}");
    }

    // Plane Detection Events

    public void OnPlaneAdded(ARPlane plane) {
        print($"Plane with id {plane.trackableId} added");
    }

    public void OnPlaneRemoved(ARPlane plane) {
        print($"Plane with id {plane.trackableId} removed");
    }

    public void OnPlaneUpdated(ARPlane plane) {
        print($"Plane with id {plane.trackableId} updated");
    }

    public void TriggerCloseButton() {
        print($"Implement: End the game. Open the menu again.");
    }
}
