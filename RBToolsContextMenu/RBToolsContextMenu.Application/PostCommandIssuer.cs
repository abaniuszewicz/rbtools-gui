using RBToolsContextMenu.Application.Communication.DTO;
using RBToolsContextMenu.Application.Communication.Mapping;

namespace RBToolsContextMenu.Application
{
    public class PostCommandIssuer : CommandIssuer
    {
        public PostCommandIssuer(RbtPostDto dto) 
            : base(dto.AsPostCommand())
        {
        }
    }
}