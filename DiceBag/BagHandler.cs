using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kingmaker;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.PubSubSystem;
using ModMaker;
using ModMaker.Utility;
using System.Reflection;

namespace WrathLessRandom.DiceBag
{
    public class BagHandler : IModEventHandler, IUnitHandler, IAreaLoadingStagesHandler
    {
        public int Priority => 100;
        public static Dictionary<UnitEntityData, Bag> Units = new Dictionary<UnitEntityData, Bag>();

        public void HandleModDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public void HandleModEnable()
        {
            EventBus.Subscribe(this);
        }

        public void HandleUnitDeath(UnitEntityData unit)
        {
            if (Units.ContainsKey(unit))
                Units.Remove(unit);
        }

        public void HandleUnitDestroyed(UnitEntityData unit)
        {
            if (Units.ContainsKey(unit))
                Units.Remove(unit);
        }

        public void HandleUnitSpawned(UnitEntityData unit)
        {
            if (!Units.ContainsKey(unit))
                Units.Add(unit, new Bag(new List<int>() {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 0));
        }

        public void OnAreaLoadingComplete()
        {
            Units.Clear();
            foreach(UnitEntityData unit in Game.Instance.State.Units)
            {
                if (!Units.ContainsKey(unit))
                    Units.Add(unit, new Bag(new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 0));
            }
        }

        public void OnAreaScenesLoaded()
        {
            Main.Mod.Debug(MethodBase.GetCurrentMethod());
        }
    }
}
