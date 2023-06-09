﻿using MetaFac.CG4.Attributes;

namespace MetaFac.CG4.ModelReader.Tests.LifeCycle
{
    [Entity(1)]
    public interface IEntity1
    {
        [Member(1)]
        public bool State0_Active { get; }

        [Member(2, ModelState.Reserved, "For future use")]
        public bool State1_Reserved { get; }

        [Member(3, ModelState.Deprecated, "Not used anymore")]
        public bool State2_Deprecated { get; }

        [Member(4, ModelState.Deleted, "RIP")]
        public bool State3_Deleted { get; }
    }
}