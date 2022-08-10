namespace TimedAssignment.Data.Entities
{
    public class PostEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public List<CommentEntity> Comments { get; set; }
    }
}