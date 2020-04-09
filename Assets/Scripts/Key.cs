using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Collectable {
    public Color color;
    MeshRenderer bodyRenderer;

    protected override void Awake() {
        base.Awake();
        
        bodyRenderer = body.GetComponentInChildren<MeshRenderer>();
        bodyRenderer.material.color = color;
    }

    protected override void Start() {
        base.Start();
    }

    protected override void Update() {
        base.Update();
    }
}
