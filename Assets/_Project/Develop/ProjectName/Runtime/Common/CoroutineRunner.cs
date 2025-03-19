using UnityEngine;

namespace ProjectName.Runtime.Common
{
  public class CoroutineRunner : MonoBehaviour
  {
    private void Awake()
    {
      DontDestroyOnLoad(gameObject);
    }
  }
}