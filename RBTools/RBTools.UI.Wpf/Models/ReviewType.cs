namespace RBTools.UI.Wpf.Models
{
    public class ReviewType
    {
        public string Display { get; private set; }
        public bool IsUpdate { get; private set; }
        public bool IsPostCommit { get; private set; }

        public static ReviewType PreCommitNew { get; } = new ReviewType() { Display = "Pre-commit new", IsUpdate = false, IsPostCommit = false };
        public static ReviewType PreCommitUpdate { get; } = new ReviewType() { Display = "Pre-commit update", IsUpdate = true, IsPostCommit = false };
        public static ReviewType PostCommitNew { get; } = new ReviewType() { Display = "Post-commit new", IsUpdate = false, IsPostCommit = true };
        public static ReviewType PostCommitUpdate { get; } = new ReviewType() { Display = "Post-commit update", IsUpdate = true, IsPostCommit = true };

        private ReviewType()
        {
        }
    }
}
