using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Titres
{
    public class DestroyZone : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(collision.collider.gameObject);
        }
    }
}
