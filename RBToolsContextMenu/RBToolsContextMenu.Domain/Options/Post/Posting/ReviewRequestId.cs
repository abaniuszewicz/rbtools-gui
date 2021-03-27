using System;
using System.Globalization;

namespace RBToolsContextMenu.Domain.Options.Post.Posting
{
    public class ReviewRequestId : RbtOption, IHasLongForm, IHasShortForm, IHasValue
    {
        public string LongForm { get; } = "review-request-id";
        public string ShortForm { get; } = "r";
        public string Value { get; }
        
        public ReviewRequestId(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be a positive number");

            Value = id.ToString(CultureInfo.InvariantCulture);
        }
    }
}