using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Common
{
    public class CharacterControllerEntityRegistrator : MonoEntityRegistrator
    {
        public override void Regiser(Entity entity)
        {
            entity.AddCharacterController(GetComponent<CharacterController>());
        }
    }
}