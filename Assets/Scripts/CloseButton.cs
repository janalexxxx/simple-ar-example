using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CloseButton : MonoBehaviour, IPointerClickHandler
{
    public SceneTransitionManager sceneTransitionManager;
    public bool isAppIntro = false;

    public UnityEvent OnBeforeClose;

    public virtual void OnPointerClick(PointerEventData eventData) {
        print("CloseButton.OnPointerClick");
        Close();
    }

    private void Close() {
        OnBeforeClose.Invoke();

        if (GameManager.instance != null) {
            GameManager.instance.TriggerCloseButton();
        }
        if (isAppIntro) {
            PlayerPrefs.SetInt(PlayerPrefsKey.DidAppIntroShow, 1);
        }

        sceneTransitionManager.LoadHomeScene();
    }
}
