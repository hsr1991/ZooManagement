using System;

namespace Zoo_Management.Models.Request
{
    public class SearchRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public virtual string Filters => "";
    }
    
    public class AnimalSearchRequest : SearchRequest
    {

      public string Name { get; set; }
      public int? Age { get; set; }
      public string Classification { get; set; }
      public string SpeciesType { get; set; }
      public string Sex { get; set; }
      public DateTime? DateAcquired { get; set; }

        
    }

  

    // public class FeedSearchRequest : PostSearchRequest
    // {
    //     public int? LikedBy { get; set; }
    //     public int? DislikedBy { get; set; }
    //     public override string Filters
    //     {
    //         get
    //         {
    //             var filters = "";

    //             if (PostedBy != null)
    //             {
    //                 filters += $"&postedBy={PostedBy}";
    //             }
                
    //             if (LikedBy != null)
    //             {
    //                 filters += $"&likedBy={LikedBy}";
    //             }
                
    //             if (DislikedBy != null)
    //             {
    //                 filters += $"&dislikedBy={DislikedBy}";
    //             }
                
    //             return filters;
    //         }
    //     }
    // }
}