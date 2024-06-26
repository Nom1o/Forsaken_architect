using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatedRock : MonoBehaviour
{

  [SerializeField] private float duration = 2f;
  [SerializeField] private GameObject destroyParticle;
  private float durationCount = 0f;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    durationCount += Time.deltaTime;
    if (durationCount >= duration)
    {
      RockDestroy();
    }

  }

  private void RockDestroy()
  {
    Instantiate(destroyParticle,transform.position, destroyParticle.transform.rotation);
    Destroy(gameObject);
  }
}
