using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public List<Key> keys = new List<Key>();
    public int coinCount = 0;

    void Start() {
        
    }

    void Update() {
        
    }

    void CollectKey(Key key) {
        key.Collect();
        keys.Add(key);
    }

    void CollectCoin(Coin coin) {
        coin.Collect();
        coinCount++;
    }

    bool TryOpenDoor(Door door) {
        Key key;
        if (door.TryOpen(keys, out key)) {
            keys.Remove(key);
            return true;
        }
        else return false;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Key") {
            CollectKey(other.GetComponent<Key>());
        }
        if (other.tag == "Coin") {
            CollectCoin(other.GetComponent<Coin>());
        }
        if (other.tag == "Door") {
            TryOpenDoor(other.GetComponent<Door>());
        }
    }
}
