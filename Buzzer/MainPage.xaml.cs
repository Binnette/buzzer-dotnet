using System;
using Xamarin.Forms;
using Plugin.SimpleAudioPlayer;
using System.Reflection;

namespace Buzzer
{
    public enum SoundType
    {
        Sncf,
        Maff,
        Gmf,
        Xfiles,
        Mercuro,
        Spaceo,
        Cena,
        Bleu,
        Drama,
        Hallelujah,
        Fly,
        MotMagique
    }

    public partial class MainPage : ContentPage
	{
        ISimpleAudioPlayer[] players = new ISimpleAudioPlayer[Enum.GetNames(typeof(SoundType)).Length];
		public MainPage()
		{
            var soundCount = Enum.GetNames(typeof(SoundType)).Length;
            var player = CrossSimpleAudioPlayer.Current;
            
            for (int i= 0; i < soundCount; i++)
            {
                players[i] = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                players[i].Loop = false;
            }

            var assembly = typeof(App).GetTypeInfo().Assembly;
            players[(int)SoundType.Sncf].Load(assembly.GetManifestResourceStream("Buzzer.Audio.sncf.mp3"));
            players[(int)SoundType.Maff].Load(assembly.GetManifestResourceStream("Buzzer.Audio.maff.mp3"));
            players[(int)SoundType.Gmf].Load(assembly.GetManifestResourceStream("Buzzer.Audio.gmf.mp3"));
            players[(int)SoundType.Xfiles].Load(assembly.GetManifestResourceStream("Buzzer.Audio.xfiles.mp3"));
            players[(int)SoundType.Mercuro].Load(assembly.GetManifestResourceStream("Buzzer.Audio.mercu.mp3"));
            players[(int)SoundType.Spaceo].Load(assembly.GetManifestResourceStream("Buzzer.Audio.spaceo.mp3"));
            players[(int)SoundType.Cena].Load(assembly.GetManifestResourceStream("Buzzer.Audio.cena.mp3"));
            players[(int)SoundType.Bleu].Load(assembly.GetManifestResourceStream("Buzzer.Audio.bleu.mp3"));
            players[(int)SoundType.Drama].Load(assembly.GetManifestResourceStream("Buzzer.Audio.drama.mp3"));
            players[(int)SoundType.Hallelujah].Load(assembly.GetManifestResourceStream("Buzzer.Audio.hallelujah.mp3"));
            players[(int)SoundType.Fly].Load(assembly.GetManifestResourceStream("Buzzer.Audio.fly.mp3"));
            players[(int)SoundType.MotMagique].Load(assembly.GetManifestResourceStream("Buzzer.Audio.motmagique.mp3"));

            InitializeComponent();

            int j = 0;
            foreach (Button button in GridButtons.Children)
            {
                var sound = (SoundType)j;
                button.Clicked += (s, e) => OnSoundButton(sound);
                j++;
            }
        }

        private void OnSoundButton(SoundType sound)
        {
            players[(int)sound]?.Play();
        }
    }
}
