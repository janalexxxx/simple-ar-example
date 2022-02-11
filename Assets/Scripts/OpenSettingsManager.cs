using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettingsManager : MonoBehaviour
{
    public void DidTriggerOpenSettings() {
        NativeCamera.OpenSettings();
    }
}
