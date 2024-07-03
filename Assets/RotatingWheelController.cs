using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWheelController : MonoBehaviour
{
  public float force = 10f; // ������ ��������
  private Rigidbody2D rb;

  void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate()
  {
    // ��������� ������ � �������
    rb.AddTorque(force);
  }
}
