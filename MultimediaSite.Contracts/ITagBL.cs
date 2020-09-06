using System.Collections.Generic;
using MultimediaSite.Core.DTO;

namespace MultimediaSite.Contracts
{
    public interface ITagBL
    {
        List<string> GetContentTags(int tagContentId, string tagContentType);
        List<TagDTO> GetTagList();          
    }
}
