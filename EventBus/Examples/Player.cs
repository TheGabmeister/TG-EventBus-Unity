using UnityEngine;
using EventBus; 

public class Player : MonoBehaviour
{
    [SerializeField] AudioClip _dieSound;

    private void Start()
    {
        Bus<E_Player_Spawned>.Raise();
    }

    void Died()
    {
        Bus<E_Player_Died>.Raise();
    }

    void TakeDamage()
    {
        Bus<E_Player_Damaged>.Raise(new E_Player_Damaged { value = 5 });
        Bus<E_SFX_Play>.Raise(new E_SFX_Play { value = _dieSound });
    }   
}