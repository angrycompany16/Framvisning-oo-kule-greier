using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbar : MonoBehaviour
{
    [SerializeField] Damageable damageable;

    [SerializeField] Color healthActive;
    [SerializeField] Color healthLost;

    [SerializeField] float spacing;
    [SerializeField] float width = 1.2f;

    [SerializeField] GameObject parentHP;
    [SerializeField] GameObject HPbit;

    List<GameObject> HPbits = new List<GameObject>();
     
    void Start() {
        GenerateHPBar();
    }

    void GenerateHPBar() {
        float n = damageable.maxHealth;
        float actualWidth = width - (n - 1) * spacing;
        
        for (int i = 1; i < damageable.maxHealth + 1; i++)
        {
            float x_0 = -width / 2;
            float bitWidth = actualWidth / n;
            float posX = x_0 + (bitWidth / 2) + (i - 1) * (bitWidth + spacing);
            GameObject currentHPbit = Instantiate(
                HPbit, 
                parentHP.transform,
                false
            );

            Vector3 pos = currentHPbit.transform.localPosition;
            pos.x = posX;
            currentHPbit.transform.localPosition = pos;

            Vector3 scale = currentHPbit.transform.localScale;
            scale.x = bitWidth;
            currentHPbit.transform.localScale = scale;
            HPbits.Add(currentHPbit);
        }
    }

    public void UpdateHPBar(int healthLost, int currentHealth) {
        for (int i = currentHealth + healthLost; i > currentHealth; i--)
        {
            HPbits[i - 1].SetActive(false);
        }
    }
}
