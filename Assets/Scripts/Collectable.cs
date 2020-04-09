using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour {
    public Transform body = null;

    public float bobSize = 0.4f;
    public float bobSpeed = 5.0f;
    public float spinSpeed = 100f;

    public float twist = 1;
    public float churn = 1;

    public AudioSource humSource;
    public AudioSource collectSource;
    public AudioSource activateSource;
    public bool active = false;

    CapsuleCollider trigger;

    protected virtual void Awake() {
        trigger = GetComponent<CapsuleCollider>();
    }

    protected virtual void Start() {
        
    }

    protected virtual void Update() {
        Vector3 p = body.localPosition;
        p.y = Mathf.Sin((Time.time*bobSpeed+transform.position.y*churn))*bobSize;
        body.localPosition = p;

        Quaternion r = Quaternion.Euler(0, (Time.time*spinSpeed+transform.position.y*twist)*180/Mathf.PI, 0);
        body.localRotation = r;
    }

    protected void Activate() {
        active = true;
        body.gameObject.SetActive(true);
        humSource.Play();
        // activateSource.Play();
        trigger.enabled = true;
    }

    protected void Deactivate() {
        active = false;
        body.gameObject.SetActive(false);
        humSource.Stop();
        trigger.enabled = false;
    }

    public virtual void Collect() {
        Debug.Log("Collecting!");
        collectSource.Play();
        Deactivate();
    }
}
