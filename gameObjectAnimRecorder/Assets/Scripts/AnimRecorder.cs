using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

public class AnimRecorder : MonoBehaviour
{
    [SerializeField] private AnimationClip _animClip;
    [SerializeField] private bool _recordAnim = false;
    private GameObjectRecorder _gameObjectRecorder;

    void Start()
    {
        _gameObjectRecorder = new GameObjectRecorder(gameObject);
        _gameObjectRecorder.BindComponentsOfType<Transform>(gameObject, true);
    }

    void LateUpdate()
    {
        if (_animClip == null)
        {
            return;
        }
        _gameObjectRecorder.TakeSnapshot(Time.deltaTime);
    }

    private void OnDisable()
    {
        if (_animClip == null)
        {
            return;
        }
        if (_gameObjectRecorder.isRecording)
        {
            _gameObjectRecorder.SaveToClip(_animClip);
        }
    }
}