using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.InputSystem;

public class EnemyBullet : MonoBehaviour
{
  private Transform playerTransform;
  [SerializeField] float bulletSpeed;
  private Rigidbody2D rb;
  private Vector2 target, direction;
  private void Awake()
  {
    playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    rb = GetComponent<Rigidbody2D>();
  }

  private void Start()
  {
    target = new Vector2(playerTransform.position.x, playerTransform.position.y + 0.5f);
    // ���������� ������ � ������� �������
    //transform.position = Vector2.MoveTowards(transform.position, target, bulletSpeed * Time.deltaTime);

    // ��������� ����������� ��������
    direction = target - (Vector2)transform.position;
    direction.Normalize();

    // ������������ ������ � ����������� ��������
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    transform.rotation = rotation;
  }
  void Update()
  {    
    

    rb.velocity = direction * bulletSpeed;
  }
}
