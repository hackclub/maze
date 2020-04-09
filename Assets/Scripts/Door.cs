using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    public Color color = Color.white;

    public Transform body;

    public AudioSource openSource;
    public AudioSource rejectSource;

    MeshRenderer bodyRenderer;
    BoxCollider bodyCollider;
    BoxCollider trigger;

    bool open = false;
    float openProgress = 0;
    float openDistance = 2.9f;
    float openSpeed = 1;
    Vector3 openDirection = Vector3.up;

    void Awake() {
        bodyRenderer = body.GetComponentInChildren<MeshRenderer>();
        bodyRenderer.material.color = color;

        trigger = GetComponent<BoxCollider>();
    }

    void Start() {
        
    }

    void Update() {
        if (open) openProgress += openSpeed*Time.deltaTime;
        else openProgress -= openSpeed*Time.deltaTime;
        openProgress = Mathf.Clamp01(openProgress);

        body.transform.localPosition = openDirection*openDistance*openProgress;
    }

    public void Open() {
        open = true;
        trigger.enabled = false;
        openSource.Play();
    }

    public bool TryOpen(List<Key> keys, out Key key) {
        for (int i = 0; i < keys.Count; i++) {
            if (keys[i].color == color) {
                Open();
                key = keys[i];
                return true;
            }
        }
        rejectSource.Play();
        key = null;
        return false;
    }
}
