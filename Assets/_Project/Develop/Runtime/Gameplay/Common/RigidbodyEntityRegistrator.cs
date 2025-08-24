using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Common
{
    public class RigidbodyEntityRegistrator : MonoEntityRegistrator
    {
        public override void Regiser(Entity entity)
        {
            entity.AddComponent(new RigidbodyComponent() { Value = GetComponent<Rigidbody>() });
        }
    }
}
