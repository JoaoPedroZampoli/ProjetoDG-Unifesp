using UnityEngine;

public class AtaqueJogador : MonoBehaviour
{

    [SerializeField]
    private Transform pontoAtaqueDireita;

    [SerializeField]
    private Transform pontoAtaqueEsquerda;

    [SerializeField]
    private float raioAtaque;

    [SerializeField]
    private LayerMask layersAtaque;

    [SerializeField]
    private PlayerController player;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Atacar();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        if(this.pontoAtaqueDireita != null)
        {
            Gizmos.DrawWireSphere(this.pontoAtaqueDireita.position, this.raioAtaque); 
        }
        if(this.pontoAtaqueEsquerda != null)
        {
            Gizmos.DrawWireSphere(this.pontoAtaqueEsquerda.position, this.raioAtaque);
        }

        //Destaca área usada no momento
        Transform pontoAtaque;
        if(this.player.direcaoMovimento == DirecaoMovimento.Direita)
        {
            pontoAtaque = this.pontoAtaqueDireita;
        }
        else
        {
            pontoAtaque = this.pontoAtaqueEsquerda;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pontoAtaque.position, this.raioAtaque);
    }

    private void Atacar()
    {
        Transform pontoAtaque;
        if(this.player.direcaoMovimento == DirecaoMovimento.Direita)
        {
            pontoAtaque = this.pontoAtaqueDireita;
        }
        else
        {
            pontoAtaque = this.pontoAtaqueEsquerda;
        }

        Collider2D[] collidersInimigo = Physics2D.OverlapCircleAll(pontoAtaque.position, this.raioAtaque, this.layersAtaque);
        if(collidersInimigo != null)
        {
            foreach(Collider2D colliderInimigo in collidersInimigo) //Ataca todos inimigos no raio
            {
               Debug.Log("Atacando objeto " + colliderInimigo.name);

                //Causar dano no inimigo
                Inimigo inimigo = colliderInimigo.GetComponent<Inimigo>();
                if(inimigo != null)
                {
                    inimigo.ReceberDano();
                } 
            }
            
        }
    }
}
