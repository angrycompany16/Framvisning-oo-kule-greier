using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float moveSlowness = 20;

    [SerializeField] Transform target;

    void FixedUpdate()
    {
        float diffX = (target.position.x - transform.position.x) / moveSlowness;
        float diffY = (target.position.y - transform.position.y) / moveSlowness;

        Vector3 position = transform.position;

        position.x += diffX;
        position.y += diffY;

        transform.position = position;
    }

    public IEnumerator Shake(float duration, float magnitude) {
        float t = 0;
        while (t < duration) {
            t += Time.deltaTime;
            
            float shakeX = Random.Range(-1f, 1f) * magnitude / 10;
            float shakeY = Random.Range(-1f, 1f) * magnitude / 10;

            transform.position += new Vector3(shakeX, shakeY, 0f);

            yield return null;
        }
    }
}
