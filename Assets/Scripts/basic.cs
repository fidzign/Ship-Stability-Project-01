﻿using UnityEngine;
using System.Collections;

public class basic : MonoBehaviour
{

  public float NextTime = 0f;
  public float Timer = 0.5f;
  public int Counter = 10;
  public int MinHeight = 1;
  public int MaxHeight = 10;
  public float HorizontalSpacing = 2f;
  public float VerticalSpacing = 1f;
  void Update()
  {
      if (Counter > 0 && Time.fixedTime > NextTime)
      {
          NextTime = Time.fixedTime + Timer;
          for (int j = 10; j > 0; j--)
          {
              int randomNumber = Random.Range(MinHeight, MaxHeight);
              for (int i = 0; i < randomNumber; i++)
              {
                  GameObject box =
              GameObject.CreatePrimitive(PrimitiveType.Cube);
                  box.transform.position =
                   new Vector3(Counter * HorizontalSpacing,
                    i * VerticalSpacing,
                    j * HorizontalSpacing);
              }
          }
          Counter--;
      }


  }
}
