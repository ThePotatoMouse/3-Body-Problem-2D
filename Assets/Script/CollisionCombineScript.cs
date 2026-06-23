using UnityEngine;

public class CollisionCombineScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null && collision.gameObject.CompareTag("body"))
        {
            Rigidbody2D rbSelf = GetComponent<Rigidbody2D>();
            Rigidbody2D rbOther = collision.gameObject.GetComponent<Rigidbody2D>();

            if(rbSelf != null && rbOther != null && rbSelf.mass >= rbOther.mass)
            {
                rbSelf.linearVelocity = ((rbOther.mass * rbOther.linearVelocity) + (rbSelf.mass * rbSelf.linearVelocity)) / (rbSelf.mass + rbOther.mass);//perfect inellastic collision calculation
                rbSelf.mass += rbOther.mass;
                float size = Mathf.Pow((Mathf.Pow(collision.gameObject.transform.localScale.x, 3f) + Mathf.Pow(transform.localScale.x, 3f)), 1f/3f);
                transform.localScale = new Vector3(size,size,size);
                Destroy(collision.gameObject);
            }
        }
    }
}
