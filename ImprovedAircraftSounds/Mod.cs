using Colossal.IO.AssetDatabase;
using Colossal.Logging;
using Game;
using Game.Input;
using Game.Modding;
using Game.SceneFlow;
using UnityEngine;

namespace ImprovedAircraftSounds
{
    public class Mod : IMod
    {
        public static ILog log = LogManager.GetLogger($"{nameof(ImprovedAircraftSounds)}.{nameof(Mod)}").SetShowsErrorsInUI(false);
       

        public void OnLoad(UpdateSystem updateSystem)
        {
            log.Info(nameof(OnLoad));

            if (GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
                log.Info($"Current mod asset at {asset.path}");

     
        }

        public void OnDispose()
        {
            log.Info(nameof(OnDispose));

        }
    }
}
