namespace razorApp.ViewModels
{
    public class CategoryWithCoursesViewModel
    {
        public int CategoryId { get; set; }
        public string? Category { get; set; }

        public List<CourseViewModel> Courses { get; set; } = new List<CourseViewModel>();
    }
}
