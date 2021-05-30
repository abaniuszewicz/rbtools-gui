using System.Collections.Generic;

namespace RBTools.Application.Communication.DTO
{
    public class RbtPostDto
    {
        #region Diff generation
        
        /// <summary>
        /// Paths that should be included in review.
        /// </summary>
        public IEnumerable<string> IncludePaths { get; set; }
        
        /// <summary>
        /// In case of post-commit review, revision or revision range.
        /// </summary>
        public string Revision { get; set; }

        #endregion
        
        #region Fields
        
        /// <summary>
        /// Description of what was changed in update of review request. Ignored for new requests.
        /// </summary>
        public string UpdateDescription { get; set; }
        
        /// <summary>
        /// Content for 'Description' field.
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Content for 'Summary' field.
        /// </summary>
        public string Summary { get; set; }
        
        /// <summary>
        /// Ids of bugs that were resolved.
        /// </summary>
        public IEnumerable<string> BugIds { get; set; }
        
        /// <summary>
        /// Names of groups that should perform review.
        /// </summary>
        public IEnumerable<string> TargetGroups { get; set; }
        
        /// <summary>
        /// Usernames of people that should perform review.
        /// </summary>
        public IEnumerable<string> TargetPeople { get; set; }
        
        /// <summary>
        /// Content for 'Testing done' field.
        /// </summary>
        public string TestingDone { get; set; }

        /// <summary>
        /// Specifies if summary, description and change description should be interpreted as Markdown-formatted text.
        /// </summary>
        public bool Markdown { get; set; }
        
        #endregion
        
        #region Posting
        
        /// <summary>
        /// Specifies whether browser should be automatically opened after posting review request.
        /// </summary>
        public bool OpenBrowser { get; set; }
        
        /// <summary>
        /// Specifies whether review request should be automatically published after posting.
        /// </summary>
        public bool Publish { get; set; }

        /// <summary>
        /// Specifies existing id of review request that should be updated by current post.
        /// </summary>
        public int? ReviewRequestId { get; set; }
        
        /// <summary>
        /// Specifies whether should automatically determine existing review to be updated by current post.
        /// </summary>
        public bool Update { get; set; }
        
        #endregion
        
        #region Repository
        
        /// <summary>
        /// Name of the repository.
        /// </summary>
        public string Repository { get; set; }
        
        #endregion
        
        #region Server
        
        /// <summary>
        /// Url of review board server that should be used.
        /// </summary>
        public string Server { get; set; }
        
        #endregion
        
        #region Subversion
        
        /// <summary>
        /// Specifies whether copied/moved/renamed files should be treated as new files.
        /// </summary>
        public bool SvnShowCopiesAsAdds { get; set; }
        
        #endregion
    }
}