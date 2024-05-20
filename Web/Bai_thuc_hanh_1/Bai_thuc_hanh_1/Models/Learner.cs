namespace Bai_thuc_hanh_1.Models
{
    public class Learner
    {
        public Learner() 
        {
            Enrollments = new HashSet<Enrollment>();
        }
        public int LearnerId { get; set; }  
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int MajorID { get; set; }
        public virtual Major? Major { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        //
    }
}
