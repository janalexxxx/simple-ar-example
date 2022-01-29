using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Events;

public class TrackedImageManager : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    // public GameManager gameManager;

    public UnityEvent<ARTrackedImage> OnTrackedImageAdded;
    public UnityEvent<ARTrackedImage> OnTrackedImageUpdated;
    public UnityEvent<ARTrackedImage> OnTrackedImageRemoved;

    private GameManager _gameManager;

    void Start() {
        _gameManager = GameManager.instance;
    }

    void OnEnable() {
        trackedImageManager.trackedImagesChanged += OnChanged;
    }

    void Disable() {
        trackedImageManager.trackedImagesChanged -= OnChanged;
    }

    private void OnChanged(ARTrackedImagesChangedEventArgs eventArgs) {
        foreach(ARTrackedImage trackedImage in eventArgs.added) {
            // gameManager.OnTrackedImageAdded(trackedImage);
            // OnTrackedImageAdded.Invoke(trackedImage);
            _gameManager.OnTrackedImageAdded(trackedImage);
        }

        foreach(ARTrackedImage trackedImage in eventArgs.updated) {
            // gameManager.OnTrackedImageUpdate(trackedImage);
            // OnTrackedImageUpdated.Invoke(trackedImage);
            _gameManager.OnTrackedImageUpdate(trackedImage);
        }

        foreach(ARTrackedImage trackedImage in eventArgs.removed) {
            // gameManager.OnTrackedImageRemoved(trackedImage);
            // OnTrackedImageRemoved.Invoke(trackedImage);
            _gameManager.OnTrackedImageRemoved(trackedImage);
        }
    }
}
