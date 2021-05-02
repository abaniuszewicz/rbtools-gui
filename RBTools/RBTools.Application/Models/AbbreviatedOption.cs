using System;

namespace RBTools.Application.Models
{
    public class AbbreviatedOption : IEquatable<AbbreviatedOption>, IDeepCopy<AbbreviatedOption>
    {
        public string Abbreviation { get; set; }
        public string Value { get; set; }

        public AbbreviatedOption DeepCopy()
        {
            return new AbbreviatedOption { Abbreviation = Abbreviation, Value = Value };
        }

        public override bool Equals(object other)
        {
            return Equals(other as AbbreviatedOption);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 23 + Abbreviation?.GetHashCode() ?? 0;
                hash = hash * 23 + Value?.GetHashCode() ?? 0;
                return hash;
            }
        }

        public bool Equals(AbbreviatedOption other)
        {
            return other is not null
                && Abbreviation == other.Abbreviation
                && Value == other.Value;
        }
    }
}
