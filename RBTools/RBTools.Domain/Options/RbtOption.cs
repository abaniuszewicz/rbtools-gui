using System;
using RBTools.Domain.SeedWork;

namespace RBTools.Domain.Options
{
    public abstract class RbtOption : IRbtOption
    {
        public string Print()
        {
            return this switch
            {
                IHasShortForm form and IHasValue value => $"-{form.ShortForm} {CommandParameterEncoder.Encode(value.Value)}",
                IHasShortForm form => $"-{form.ShortForm}",
                IHasLongForm form and IHasValue value => $"--{form.LongForm} {CommandParameterEncoder.Encode(value.Value)}",
                IHasLongForm form => $"--{form.LongForm}",
                _ => throw new NotImplementedException("This option does not implement any members that could be used for printing."), // HACK: not really proud of this
            };
        }
    }
}