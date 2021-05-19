using KnightTale.Sound;
using UnityEngine;
namespace KnightTale.Core
{
  public class Health : MonoBehaviour {
    [SerializeField] float health = 20f;

    float initialHealth;
    bool isDead = false;

    private void Awake() {
      initialHealth = health;
    }

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
      FindObjectOfType<AudioManager>().Play("DeathSound");
      GetComponent<ActionPrio>().CancelCurrentAction();
    }

    public float GetHealth(){
      return health;
    }

    public float GetMaxHealth(){
      return initialHealth;
    }
  }//end of class
}
