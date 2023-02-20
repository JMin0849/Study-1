using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float moveSpeed = 5f;
    private Vector2 moveInput;
    public Rigidbody2D theRB;
    public Transform gunHand;
    public Animator anim;
    public Transform firePoint;
    public GameObject bulletToFire;
    public float timeBetweenshots=1;
    public float shotCounter;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize(); // 정규화 대각선 값 속도 같게만듦
        theRB.velocity = moveInput * moveSpeed;

        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        gunHand.rotation = Quaternion.Euler(0, 0, angle);

        if(mousePos.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            gunHand.localScale = new Vector3(-1, -1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            gunHand.localScale = Vector3.one;
        }

        if(moveInput != Vector2.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
            shotCounter = timeBetweenshots;
        }

        if (Input.GetMouseButton(0))
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
                shotCounter = timeBetweenshots;
            }
        }
    }

}
