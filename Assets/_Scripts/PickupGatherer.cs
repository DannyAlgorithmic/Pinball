using UnityEngine;

public class PickupGatherer : Publisher {
    private CircleCollider2D col;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            Subscriber sub = collision.GetComponent<Subscriber>();
            Add(sub);

            // Debug.Log("Added: " + sub.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            Subscriber sub = collision.GetComponent<Subscriber>();
            Remove(sub);

            // Debug.Log("Removed: " + sub.name);
        }
    }

}
