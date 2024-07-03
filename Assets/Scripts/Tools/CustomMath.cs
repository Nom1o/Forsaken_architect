using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMath
{
  public static float Normalize(float value, float min, float max, float neededMax)
  {
    if (min == max)
    {
      throw new ArgumentException("����������� � ������������ �������� �� ������ ���� �����.");
    }

    return ((value - min) / (max - min)) * neededMax;
  }

}
