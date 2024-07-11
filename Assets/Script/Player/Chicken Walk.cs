using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenWalk : MonoBehaviour
{
    public float speed = 5f;
    public float changeInterval = 2f;
    private Vector3 movementDirection;

    public float minX = -10f;
    public float maxX = 10f;
    public float minZ = -10f;
    public float maxZ = 10f;


    void Start()
    {
        StartCoroutine(ChangeMovement());
    }

    void Update()
    {
        Vector3 newPosition = transform.position + movementDirection * speed * UnityEngine.Time.deltaTime;

        // Clamp the position to stay within the boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

        // Apply the new position
        transform.position = newPosition;
    }

    IEnumerator ChangeMovement()
    {
        while (true)
        {

            float randomX = Random.Range(-1f, 1f);
            float randomZ = Random.Range(-1f, 1f);
            movementDirection = new Vector3(randomX, 0, randomZ).normalized;
            speed = Random.Range(1f, 10f);
            yield return new WaitForSeconds(changeInterval);
        }
    }
}
