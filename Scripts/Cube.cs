using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Vector3 _desiredPos;

    public void OnSpawn(float speed, float distance)
    {
        Vector3 direction = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f)).normalized;

        _desiredPos = transform.position + direction * distance;
        StartCoroutine(MovingCoroutine(speed, direction));
    }

    private IEnumerator MovingCoroutine(float speed, Vector3 direction)
    {
        while (Vector3.Distance(transform.position, _desiredPos) > 0.1f)
        {
            yield return new WaitForEndOfFrame();
            transform.Translate(direction * speed * Time.deltaTime);
        }
        
        Destroy(gameObject);
    }
}
