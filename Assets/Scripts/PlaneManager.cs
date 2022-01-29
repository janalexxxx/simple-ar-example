using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;

public class PlaneManager : MonoBehaviour
{
    public ARPlaneManager planeManager;
    private GameManager _gameManager;

    void Start() {
        _gameManager = GameManager.instance;
    }

    void OnEnable() {
        // planeManager.planeAdded += OnPlaneAdded;
        // planeManager.planeUpdated += OnPlaneUpdated;
        // planeManager.planeRemoved += OnPlaneRemoved;
        planeManager.planesChanged += OnPlanesChanged;
    }

    void OnDisable() {
        // planeManager.planeAdded -= OnPlaneAdded;
        // planeManager.planeUpdated -= OnPlaneUpdated;
        // planeManager.planeRemoved -= OnPlaneRemoved;
        planeManager.planesChanged -= OnPlanesChanged;
    }

    // private void OnPlaneAdded(ARPlaneAddedEventArgs eventArgs) {
    //     // Call gameManager when needed
    // }

    // private void OnPlaneUpdated(ARPlaneUpdatedEventArgs eventArgs) {
    //     // Call gameManager when needed
    // }

    // private void OnPlaneRemoved(ARPlaneRemovedEventArgs eventArgs) {
    //     // Call gameManager when needed
    // }

    private void OnPlanesChanged(ARPlanesChangedEventArgs eventArgs) {
        foreach(ARPlane plane in eventArgs.added) {
            _gameManager.OnPlaneAdded(plane);
        }

        foreach(ARPlane plane in eventArgs.updated) {
            _gameManager.OnPlaneUpdated(plane);
        }

        foreach(ARPlane plane in eventArgs.removed) {
            _gameManager.OnPlaneRemoved(plane);
        }
    }
}
