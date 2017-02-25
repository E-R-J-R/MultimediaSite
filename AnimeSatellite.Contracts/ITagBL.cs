using System.Collections.Generic;

namespace AnimeSatellite.Contracts
{
    public interface ITagBL
    {
        List<string> GetContentTags(int tagContentId, string tagContentType);
             
    }
}
