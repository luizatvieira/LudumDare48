using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i 
    {
        get{
            if ( _i == null ) 
            {
                _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            }
            return _i;
        }
    }

    public void DestroyGameObject( GameObject soundGameObject  )
    {
        StartCoroutine(DestroySound(soundGameObject));
    }

    private IEnumerator DestroySound( GameObject soundGameObject )
    {
        yield return new WaitForSeconds(2);
        Destroy(soundGameObject);
    }

    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }

    public SoundAudioClip[] soundAudioClipArray;
}