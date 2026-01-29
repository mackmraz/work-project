namespace Project.Infrastructure.Sprockets
{
    public class Sprocket
    {
        public Sprocket()
        {
            Id = Guid.CreateVersion7();
        }

        public Guid Id { get; init; }
    }
}