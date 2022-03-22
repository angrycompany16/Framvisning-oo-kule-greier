using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPbar : MonoBehaviour
{
    [SerializeField] Damageable damageable;

    [SerializeField] Color healthActive;
    [SerializeField] Color healthLost;

    [SerializeField] GameObject parentHP;
    [SerializeField] GameObject HPbit;

    List<GameObject> HPbits = new List<GameObject>();
    
    void Start() {
        GenerateHPBar();
    }

    void GenerateHPBar() {
        for (int i = 1; i < damageable.maxHealth + 1; i++)
        {
            GameObject currentHPbit = Instantiate(
                HPbit, 
                parentHP.transform,
                false
            );
            HPbits.Add(currentHPbit);
        }
    }

    public void UpdateHPBar(int healthLost, int currentHealth) {
        for (int i = currentHealth + healthLost; i > currentHealth; i--)
        {
            HPbits[i - 1].GetComponent<Image>().enabled = false;
        }
    }
}
