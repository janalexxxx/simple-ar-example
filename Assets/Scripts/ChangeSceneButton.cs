using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(BoxCollider2D))]
public class ChangeSceneButton : MonoBehaviour, IPointerClickHandler
{
    public SceneTransitionManager.Scene currentScene;
    public SceneTransitionManager.Scene sceneToLoad;

    private BoxCollider2D _boxCollider2D;
    private RectTransform _rectTransform;

    void Start() {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _rectTransform = GetComponent<RectTransform>();
        
        _boxCollider2D.isTrigger = true;
        _boxCollider2D.size = new Vector2(_rectTransform.rect.width, _rectTransform.rect.height);
    }

    // Event Handlers

    public void OnPointerClick(PointerEventData eventData) {
        ChangeScene();
    }

    // Private Helpers

    private void ChangeScene() {
        switch (currentScene) {
            case SceneTransitionManager.Scene.Tutorial:
                StorageManager.SetTutorialAsShown();
                break;
            default:
                break;
        }

        SceneTransitionManager.LoadScene(sceneToLoad);
    }
}
