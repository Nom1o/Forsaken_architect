using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class ProjectileController : MonoBehaviour
{
  [SerializeField] private float speed, turnSpeed, duration;
  private float durationCount = 0f;
  private Vector2 worldPosition, direction;
  private Rigidbody2D rb;
  private Vector2 target;
  // Start is called before the first frame update

  private void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
  }
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {
    durationCount += Time.deltaTime;
    if(durationCount >= duration)
    {
      Explode();
    }


    target = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    // ���������� ������ � ������� �������
    transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

    // ��������� ����������� ��������
    Vector2 direction = target - (Vector2)transform.position;
    direction.Normalize();

    // ������������ ������ � ����������� ��������
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);

    rb.velocity = direction * speed;
  }

  private void Explode()
  {
    Destroy(gameObject);
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    Explode();
  }

}
