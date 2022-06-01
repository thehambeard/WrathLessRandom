using HarmonyLib;
using Kingmaker;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrathLessRandom.DiceBag
{
    class Patches
    {
        [HarmonyPatch(typeof(RuleRollDice), nameof(RuleRollDice.Roll))]
        public static class RuleRollDice_Roll_Patch
        {
            private static void Postfix(RuleRollDice __instance)
            {
                if (!BagHandler.Units.ContainsKey(__instance.Initiator)) return;
                if (__instance.DiceFormula.Dice != DiceType.D20) return;

                __instance.m_Result = BagHandler.Units[__instance.Initiator].Roll(); ;
            }
        }
    }
}
