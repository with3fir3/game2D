using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EBAC.Core.Singleton
{
   public class Singleton<t> : MonoBehaviour where t : MonoBehaviour
   {
    public static t instance;

      private void Awake()
      {
        if (instance == null)
            instance = GetComponent<t>();
        else
            Destroy(gameObject);
      }







   }
}

