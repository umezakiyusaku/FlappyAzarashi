using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzarashiController : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    float angle;
    bool isDead;
    public float maxHeight;
    public float flapVelocity;
    public float relativeVelocityX;
    public GameObject sprite;

    public bool IsDead() {
        return isDead;
    }
    // Start is called before the first frame update
    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        animator = sprite.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && transform.position.y < maxHeight) {
            Flap();

        }
        ApplyAngle();
        animator.SetBool("flap", angle >= 0f && !isDead);
        
    }
    public void Flap() {
        if (isDead) return;
        rb2d.velocity = new Vector2(0f, flapVelocity);
    }
    void ApplyAngle() {
        float targetAngle;
        if (isDead) {
            targetAngle = 180f;
        } else {
            targetAngle = Mathf.Atan2(rb2d.velocity.y, relativeVelocityX) * Mathf.Rad2Deg;
        }
        angle = Mathf.Lerp(angle, targetAngle, Time.deltaTime * 10f);
        sprite.transform.localRotation = Quaternion.Euler(0f, 0f,angle);

    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (isDead) return;
        isDead = true;
    }
}
