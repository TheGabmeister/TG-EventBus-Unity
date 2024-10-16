using UnityEngine;

namespace EventBus
{ 
    // Player Events
    public struct E_Player_Spawned : IEvent { }
    public struct E_Player_Died : IEvent { }
    public struct E_Player_Damaged : IEvent { public int value; }

    // Enemy Events
    public struct E_Enemy_Spawned : IEvent { public EnemySO value; }
    public struct E_Enemy_Died : IEvent { public EnemySO value; }

    // GameManager Events 
    public struct E_Game_ReachedFinishLine : IEvent { }
    public struct E_Game_StartGame : IEvent { }
    public struct E_Game_RestartGame : IEvent { }

    // MusicManager Events
    public struct E_Music_ChangeMusic : IEvent { public AudioClip value; }
    public struct E_Music_ToggleMusicPause : IEvent { public bool value; }
    public struct E_Music_ToggleMusicPlay : IEvent { public bool value; }

    // Sound Effects Manager
    public struct E_SFX_Play : IEvent { public AudioClip value; }

    // Item Events
    public struct E_Item_Obtained : IEvent { public ItemSO value; }
    public struct E_Item_Used : IEvent { public ItemSO value; }

}
