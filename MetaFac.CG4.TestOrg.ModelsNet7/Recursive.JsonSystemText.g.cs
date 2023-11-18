#region Notices
// <auto-generated>
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
// </auto-generated>
// <information>
// This file was generated using MetaFac.CG4 tools and user supplied metadata.
// Generator: JsonSystemText.2.7
// Metadata : MetaFac.CG4.TestOrg.Schema(.Recursive)
// </information>
#endregion
#nullable enable
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8019 // Unnecessary using directive
using MetaFac.Mutability;
using MetaFac.CG4.Runtime;
using MetaFac.CG4.Runtime.JsonSystemText;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;
using System.Text.Json.Serialization;
using MetaFac.CG4.TestOrg.ModelsNet7.Recursive.Contracts;
using MetaFac.Memory;

namespace MetaFac.CG4.TestOrg.ModelsNet7.Recursive.JsonSystemText
{


    public abstract class EntityBase : IFreezable, IEntityBase
    {
        public static EntityBase Empty => throw new NotSupportedException();
        public const int EntityTag = 0;
        public EntityBase() { }
        public EntityBase(EntityBase? source) { }
        public EntityBase(IEntityBase? source) { }
        public void CopyFrom(IEntityBase? source) { }
        protected abstract int OnGetEntityTag();
        public int GetEntityTag() => OnGetEntityTag();
        public bool Equals(EntityBase? other) => true;
        public override int GetHashCode() => 0;

        public bool IsFreezable() => false;
        public bool IsFrozen() => false;
        public void Freeze() { }
        public bool TryFreeze() => true;
    }


    public sealed class Tree_Factory : IEntityFactory<ITree, Tree>
    {
        private static readonly Tree_Factory _instance = new Tree_Factory();
        public static Tree_Factory Instance => _instance;
        public Tree? CreateFrom(ITree? source) => (source is null) ? null : new Tree(source);
        public Tree Empty => new Tree();
    }
    public partial class Tree : EntityBase, ITree, IEquatable<Tree>
    {
        public new const int EntityTag = 1;
        protected override int OnGetEntityTag() => EntityTag;

        private Int32 field_Id;
        Int32 ITree.Id { get => field_Id; }
        public Int32 Id
        {
            get => field_Id;
            set => field_Id = value;
        }
        private Tree? field_A;
        ITree? ITree.A => field_A;
        public Tree? A
        {
            get => field_A;
            set => field_A = value;
        }
        private Tree? field_B;
        ITree? ITree.B => field_B;
        public Tree? B
        {
            get => field_B;
            set => field_B = value;
        }

        public Tree() : base()
        {
        }

        public Tree(Tree? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_Id = source.Id;
            field_A = source.A;
            field_B = source.B;
        }

        public Tree(ITree? source) : base(source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            field_Id = source.Id;
            field_A = Tree_Factory.Instance.CreateFrom(source.A);
            field_B = Tree_Factory.Instance.CreateFrom(source.B);
        }

        public void CopyFrom(ITree? source)
        {
            if (source is null) return;
            base.CopyFrom(source);
            field_Id = source.Id;
            field_A = Tree_Factory.Instance.CreateFrom(source.A);
            field_B = Tree_Factory.Instance.CreateFrom(source.B);
        }

        public bool Equals(Tree? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (!base.Equals(other)) return false;
            if (!Id.ValueEquals(other.Id)) return false;
            if (!A.ValueEquals(other.A)) return false;
            if (!B.ValueEquals(other.B)) return false;
            return true;
        }

        public override bool Equals(object? obj) => obj is Tree other && Equals(other);

        public override int GetHashCode()
        {
            HashCode hc = new HashCode();
            hc.Add(base.GetHashCode());
            hc.Add(Id.CalcHashUnary());
            hc.Add(A.CalcHashUnary());
            hc.Add(B.CalcHashUnary());
            return hc.ToHashCode();
        }
    }


}
