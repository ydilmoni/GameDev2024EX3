using UnityEngine;

public class DestroyByTag : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger game over")]
    [SerializeField] string triggeringTag;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(triggeringTag))
        {
            Destroy(other.gameObject); 
        }
    }
}
