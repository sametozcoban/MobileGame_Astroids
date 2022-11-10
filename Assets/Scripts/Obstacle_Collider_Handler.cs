using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle_Collider_Handler : MonoBehaviour
{
    bool gameOver = false;
    public void OnTriggerEnter(Collider other)
    {
        gameOver = true;
        if (gameOver)
        {
            Player_Health _health = other.GetComponent<Player_Health>();
            if(_health == null) { return; }
            _health.Crash();
            //Buradan Gameoverhandler sınıfına gidip buttonları aktif hale getirilmeli.
        }
    }
    private void OnBecameInvisible()
  {
    Destroy(gameObject);
  }
}
