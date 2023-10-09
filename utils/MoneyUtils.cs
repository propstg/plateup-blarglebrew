using HarmonyLib;
using Kitchen;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.Entities;
using UnityEngine;

namespace BlargleBrew.utils {

    class MoneyPopupUtil {

        public static void CreateMoneyPopup(EntityManager entityManager, GenericSystemBase genericSystemBase, int money, int idForAccounting, Vector3 position) {
            FieldInfo field = genericSystemBase.GetType().GetField("ECBs", BindingFlags.Instance | BindingFlags.NonPublic);
            Dictionary<ECB, EntityCommandBufferSystem> ecbs = (Dictionary<ECB, EntityCommandBufferSystem>)field.GetValue(genericSystemBase);

            EntityCommandBuffer buffer = ecbs[ECB.End].CreateCommandBuffer();
            Entity entity = buffer.CreateEntity();
            buffer.AddComponent(entity, new CMoneyPopup() { Change = money });
            buffer.AddComponent(entity, new CPosition(position));
            buffer.AddComponent(entity, new CLifetime(1f));
            buffer.AddComponent(entity, new CRequiresView() { Type = ViewType.MoneyPopup });
            MoneyTracker.AddEvent(new EntityContext(entityManager, buffer), idForAccounting, money);
        }
    }

    [HarmonyPatch(typeof(MoneyPopupView), "UpdateData")]
    class MoneyPopupView_DoubleNegativeFixerPatch {

        public static void Postfix(TextMeshPro ___Value) {
            if (___Value.text.StartsWith("--")) {
                ___Value.text = ___Value.text.Substring(1);
            }
        }
    }
}
