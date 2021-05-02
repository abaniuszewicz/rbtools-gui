namespace RBTools.Application.Models
{
    public interface IDeepCopy<T>
    {
        public T DeepCopy();
    }
}
