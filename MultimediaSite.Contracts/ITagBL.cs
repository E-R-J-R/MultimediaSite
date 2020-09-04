using System.Collections.Generic;

namespace MultimediaSite.Contracts
{
    public interface ITagBL
    {
        List<string> GetContentTags(int tagContentId, string tagContentType);
             
    }
}
