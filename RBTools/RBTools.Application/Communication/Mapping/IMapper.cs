namespace RBTools.Application.Communication.Mapping
{
    public interface IMapper<TFrom, TTo>
    {
        public TTo Map(TFrom from);
    }
}
