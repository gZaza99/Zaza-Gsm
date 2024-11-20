using Android.Media;
using Xamarin.Forms;
using Android.Content.Res;

[assembly: Dependency(typeof(ZazaGSM_Moblie.Droid.SoundPlayer))]
namespace ZazaGSM_Moblie.Droid
{
    public class SoundPlayer : Views.ISoundPlayer
    {
        private MediaPlayer _player;
        public SoundPlayer() { }
        public async void Play(string relativePath)
        {
            if (_player is null)
                _player = new MediaPlayer();
            // CODE FROM CHATGPT ---------------
            int resId = Android.App.Application.Context.Resources.GetIdentifier(
                    relativePath.Replace(".mp3", ""),
                    "raw",
                    Android.App.Application.Context.PackageName
                );
            _player.Prepared += (sender, e) =>
            {
                _player.Start();
                _player.Dispose();
                _player = null;
            };
            await _player.SetDataSourceAsync(Android.App.Application.Context, Android.Net.Uri.Parse("android.resource://" + Android.App.Application.Context.PackageName + "/" + resId));
            // ---------------------------------
            _player.PrepareAsync();
        }
    }
}