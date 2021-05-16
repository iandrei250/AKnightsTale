using UnityEngine;
namespace KnightTale.Combat
{
  public class Health : MonoBehaviour {
    [SerializeField] float health = 20f;
    bool isDead = false;
    public void TakeDamage(float damage){

      health = health - damage;
      if(health <= 0 ) health = 0;

      if(health == 0){
        Die();
      }

      print(health);
    }

    public bool GetIsDead(){
      return isDead;
    }

    public void Die(){
      if(isDead) return;
      isDead = true;
      GetComponent<Animator>().SetTrigger("die");
    }
  }
}
