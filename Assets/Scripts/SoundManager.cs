using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    public static AudioClip playerHit, fireSound, coinPickup, diamondPickup, foodPickup, fireExplosion, swordSwing, silence, thunder,
        click, clickEcho, rockSlide, levelUp, arrow, heroHurt,
        menu, introTheme, homeTheme, adventureTheme, battle, bossBattle, goodNight;
    static AudioSource audioSrc;
    static AudioClip audioClip;
    public SaveFile saveFile;
    public Slider volSlider;
    public Image volumeImage; 
    public Sprite lowVol, midVol, highVol;
    public float masterVolume;
    public bool isMute;


    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<SoundManager>().Length;
        if (numMusicPlayers != 1)
        {
            Destroy(this.gameObject);
        }
        // if more then one music player is in the scene
        //destroy ourselves
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        coinPickup = Resources.Load<AudioClip>("Audio/CoinPick");
        diamondPickup = Resources.Load<AudioClip>("Audio/DiamondPick");
        fireExplosion = Resources.Load<AudioClip>("Audio/FireExplosion");
        swordSwing = Resources.Load<AudioClip>("Audio/SwordSwing");
        arrow = Resources.Load<AudioClip>("Audio/Arrow");
        thunder = Resources.Load<AudioClip>("Audio/Thunder");
        silence = Resources.Load<AudioClip>("Audio/Silence");
        click = Resources.Load<AudioClip>("Audio/click");
        clickEcho = Resources.Load<AudioClip>("Audio/click");
        levelUp = Resources.Load<AudioClip>("Audio/LevelUp");
        introTheme = Resources.Load<AudioClip>("Audio/Intro");
        menu = Resources.Load<AudioClip>("Audio/Intro");
        homeTheme = Resources.Load<AudioClip>("Audio/Homestead");
        adventureTheme = Resources.Load<AudioClip>("Audio/Adventure1");
        battle = Resources.Load<AudioClip>("Audio/Battle");
        bossBattle = Resources.Load<AudioClip>("Audio/BossBattle");
        rockSlide = Resources.Load<AudioClip>("Audio/rockslide");
        goodNight = Resources.Load<AudioClip>("Audio/Goodnight");
        heroHurt = Resources.Load<AudioClip>("Audio/HeroHurt");
        audioSrc = GetComponent<AudioSource>();

        audioSrc.volume = masterVolume;
        volSlider.value = masterVolume;

        PlaySound("Intro");
    }

    private void Update()
    {
        float vol = audioSrc.volume;
        if (vol <= 0.3f)
        {
            volumeImage.sprite = lowVol;
        }else if ( vol <= 0.65f && vol > 0.30f)
        {
            volumeImage.sprite = midVol;
        }
        else
        {
            volumeImage.sprite = highVol;
        }
    }

    public void SetVolume()
    {
        masterVolume = volSlider.value;
        audioSrc.volume = masterVolume;
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "CoinPick":
                audioSrc.PlayOneShot(coinPickup);
                break;
            case "DiamondPick":
                audioSrc.PlayOneShot(diamondPickup);
                break;
            case "FireExplosion":
                audioSrc.PlayOneShot(fireExplosion);
                break;
            case "SwordSwing":
                audioSrc.PlayOneShot(swordSwing);
                break;
            case "HeroHurt":
                audioSrc.PlayOneShot(heroHurt);
                break;
            case "Arrow":
                audioSrc.PlayOneShot(arrow);
                break;
            case "Silence":
                audioSrc.PlayOneShot(silence);
                break;
            case "Thunder":
                audioSrc.PlayOneShot(thunder);
                break;
            case "Click":
                audioSrc.PlayOneShot(click);
                break;
            case "ClickEcho":
                audioSrc.PlayOneShot(clickEcho);
                break;
            case "LevelUp":
                audioSrc.PlayOneShot(levelUp);
                break;
            case "Intro":
                audioSrc.PlayOneShot(introTheme);
                break;
            case "RockSlide":
                audioSrc.PlayOneShot(rockSlide);
                break;
            case "Menu":
                audioSrc.Stop();
                audioSrc.PlayOneShot(menu);
                break;
            case "Home":
                audioSrc.Stop();
                audioSrc.PlayOneShot(homeTheme);
                break;
            case "Adventure1":
                audioSrc.Stop();
                audioSrc.PlayOneShot(adventureTheme);
                break;
            case "Battle":
                audioSrc.Stop();
                audioSrc.PlayOneShot(battle);
                break;
            case "BossBattle":
                audioSrc.Stop();
                audioSrc.PlayOneShot(bossBattle);
                break;
            case "GoodNight":
                audioSrc.Stop();
                audioSrc.PlayOneShot(goodNight);
                break;
        }
    }

}
