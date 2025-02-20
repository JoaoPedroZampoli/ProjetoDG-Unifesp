using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField]
    private int vidas;

    [SerializeField]
    private Animator animator;

    public void ReceberDano()
    {
        this.vidas--;
        Debug.Log(this.name + " recebeu dano. Vida: " + this.vidas);
        if(this.vidas==0)
        {
            //Derrotado
            this.animator.SetBool("Morte", true);
            GameObject.Destroy(this.gameObject, 0.6f);
        }
        else
        {
            //Recebeu dano
            this.animator.SetTrigger("Dano");
        }
    }
}
