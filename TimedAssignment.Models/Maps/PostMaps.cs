using AutoMapper;
using TimedAssignment.Data.Entities;
using TimedAssignment.Models.Post;

namespace TimedAssignment.Models.Maps
{
    public class PostMaps : Profile
    {
        public PostMaps()
        {
            CreateMap<PostEntity, PostDetail>();
            CreateMap<PostEntity, PostListItem>();
        }
    }
}