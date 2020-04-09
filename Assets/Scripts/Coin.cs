using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectable {

    public static List<Coin> manifest = new List<Coin>();

    protected override void Awake() {
        base.Awake();
        manifest.Add(this);
    }

    public override void Collect() {
        base.Collect();

        Debug.Log("Collecting!");
        collectSource.Play();
        Deactivate();
    }

    static void ActivateRandomCoin(Coin excludedCoin = null) {
        int index = Mathf.RoundToInt(Random.Range(0, manifest.Count));
        if (manifest[index] != excludedCoin) manifest[index].Activate();
        else ActivateRandomCoin(excludedCoin);
    }
}
