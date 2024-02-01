using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DangerZone : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float destroyZone;
    // Start is called before the first frame update
    void Start()
    {
        destroyZone = 0.5f;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.color = Color.red;
        if (Vector3.Distance(gameObject.transform.position, collision.transform.position) <= destroyZone)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = Color.white;
    }
}
