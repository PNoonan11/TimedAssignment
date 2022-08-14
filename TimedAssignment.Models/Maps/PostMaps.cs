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

            CreateMap<PostCreate, PostEntity>()
                .ForMember(post => post.PostCreatedTimeDate, opt => opt.MapFrom(scr => DateTimeOffset.Now));
        }
    }
}