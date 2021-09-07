using Exiled.API.Enums;
using Exiled.API.Features;
using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;
using System;

namespace SCP096ChamberLock
{
    public class SCP096ChamberLock : Plugin<Config>
    {
        private static SCP096ChamberLock Singleton;

        static SCP096ChamberLock()
        {
        }
        public static SCP096ChamberLock Instance => Singleton;
        public override string Author { get; } = "TemmieGamerGuy";
        public override string Name { get; } = "SCP096ChamberLock";
        public override Version Version { get; } = new Version(1, 0, 2);
        public override PluginPriority Priority { get; } = PluginPriority.Medium;
        private Handlers.Player player;

        public void RegisterEvents()
        {
            player = new Handlers.Player();
            Player.Spawning += player.OnSpawning;
        }

        public void UnregisterEvents()
        {
            Player.Spawning -= player.OnSpawning;
            player = null;
        }
        public override void OnEnabled()
        {
            Singleton = this;
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }
    }
}
