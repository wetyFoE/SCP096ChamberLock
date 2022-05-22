using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;

namespace SCP096ChamberLock.Handlers
{
    class Player
    {
        public void OnSpawning(SpawningEventArgs ev)
        {
            Timing.RunCoroutine(Wait(ev));
        }

        public IEnumerator<float> Wait(SpawningEventArgs ev)
        {
            if (ev.RoleType == RoleType.Scp096)
            {
                Door door = Door.List.First(x => x.Nametag == "096");
                door.ChangeLock(Exiled.API.Enums.DoorLockType.AdminCommand);
                yield return Timing.WaitForSeconds(0.5f);
                ev.Player.Position = (Room.List.First(y => y.Type == Exiled.API.Enums.RoomType.Hcz096).Position + UnityEngine.Vector3.up * 1.5f);
                yield return Timing.WaitForSeconds(SCP096ChamberLock.Instance.Config.WaitTime);
                door.IsOpen = true;
                door.ChangeLock(Exiled.API.Enums.DoorLockType.None);
            }
            
        }
    }
}
