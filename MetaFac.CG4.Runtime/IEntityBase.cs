namespace MetaFac.CG4.Runtime
{
    public interface IEntityFactory<TInterface, TConcrete>
    {
        TConcrete? CreateFrom(TInterface source);
        TConcrete Empty { get; }
    }
    public interface IEntityBase
    {
        int GetEntityTag();
    }
}